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

    private void Start()
    {
        controller = transform.parent.GetComponent<trafficObstacle>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "car":
                Debug.Log("trigger actived");
                car car = collision.GetComponent<car>();
                car.atObstacle = true;
                car.speed = 0;
                controller.order.Enqueue(car);
                break;
            default:
                break;
        }
    }
}
