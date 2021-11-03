using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class trafficObstacle : MonoBehaviour
{
    public enum obstacleType
    {
        stop
    }

    public obstacleType obType;
    public int numPoints = 4;
    public float pointSize = 0.2f;

    public Queue<car> order = new Queue<car>();
    protected car movingCar;
    protected bool dequeing;

    protected virtual void Update()
    {
        
    }

    [ContextMenu("Add Points")]
    void addPoints()
    {
        for (int i = 0; i < numPoints; i++)
        {
            GameObject point = new GameObject("point");
            
            point.AddComponent<BoxCollider2D>();
            point.GetComponent<BoxCollider2D>().isTrigger = true;
            point.transform.localScale = new Vector3(pointSize, pointSize, pointSize);
            point.tag = "trafficObstacle";
            point.transform.parent = this.transform;
            point.transform.localPosition = new Vector3(0, 0, 0);

        }
    }

    public abstract IEnumerator QueueCheck();
}
