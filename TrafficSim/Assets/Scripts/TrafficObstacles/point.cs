using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour
{
    private trafficObstacle controller;

    //Would use this if we expand the traffic obstacle class that may need to know which points will always need to go etc. 
    //Would have passed into the queue as a json object or something
    //Will not be used now as that functionality is not needed for this assignment. 
    public int pointPriority;
    public bool mustStop= true;

    private void Start()
    {
        controller = transform.parent.GetComponent<trafficObstacle>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        switch (collision.tag)
        {
            case "car":
                
                car car = collision.GetComponent<car>();
                car.atObstacle = true;
                if(mustStop)
                    car.speed = 0;
                controller.order.Enqueue(collision.gameObject);
                break;
            case "person":
                Debug.Log("trigger actived");
                person person = collision.GetComponent<person>();
                if (mustStop)
                    person.stop();
                controller.order.Enqueue(collision.gameObject);
                break;
            default:
                break;
        }
    }
}
