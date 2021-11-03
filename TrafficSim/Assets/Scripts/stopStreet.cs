using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopStreet : trafficObstacle
{
    public float timeToStop=2;

    protected override void Update()
    {
        base.Update();
        if(order.Count > 0 && !dequeing)
        {
            Debug.Log("starting coroutine");
            StartCoroutine(QueueCheck());
        }
    }


    public override IEnumerator QueueCheck()
    {
        dequeing = true;
        while(order.Count > 0)
        {
            yield return new WaitForSeconds(timeToStop);
            movingCar = order.Dequeue();
            movingCar.atObstacle = false;
            movingCar.speed = movingCar.maxSpeed;
            
        }
        dequeing = false;
    }
}
