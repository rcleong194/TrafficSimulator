using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perdestrianCrossing : trafficObstacle
{
    Collider2D pedestrianZone;
    int numPersonOnZone = 0;
    bool isPersonOnZone = false;
    int numCarOnZone = 0;
    bool isCarOnZone = false;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "person")
        {
            numPersonOnZone++;
            isPersonOnZone = true;
        }

        if(collision.tag == "car")
        {
            numCarOnZone++;
            isCarOnZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "person")
        {
            if(--numPersonOnZone == 0)
                isPersonOnZone = false;
        }

        if (collision.tag == "car")
        {
            if (--numCarOnZone == 0)
                isCarOnZone = false;
        }
    }

    public override IEnumerator QueueCheck()
    {
        dequeing = true;
        while(order.Count >= 1)
        {
            yield return null;
            moving = order.Dequeue();
            if (moving.tag == "person")
            {
                person person = moving.GetComponent<person>();
                if (isCarOnZone)
                {
                    person.stop();
                    order.Enqueue(moving);
                }
                else
                {
                    person.start();
                }
            }
            if (moving.tag == "car")
            {
                car movingCar = moving.GetComponent<car>();
                if (isPersonOnZone || (order.Count > 0 && order.Peek().tag == "person"))
                {
                    movingCar.stop();
                    order.Enqueue(moving);
                }
                else
                {
                    movingCar.atObstacle = false;
                    movingCar.start();
                }   
            }
            
        }
        dequeing = false;
    }
}
