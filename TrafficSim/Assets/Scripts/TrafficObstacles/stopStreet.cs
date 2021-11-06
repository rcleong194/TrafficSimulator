using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopStreet : trafficObstacle
{
    public float timeToStop=2;

    public override IEnumerator QueueCheck()
    {
        dequeing = true;
        while(order.Count > 0)
        {
            yield return new WaitForSeconds(timeToStop);
            moving = order.Dequeue();
            car movingCar = moving.GetComponent<car>();
            movingCar.atObstacle = false;
            movingCar.speed = movingCar.maxSpeed;
        }
        dequeing = false;
    }
}
