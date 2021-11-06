using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class trafficObstacle : MonoBehaviour
{
    public int numPoints = 4;
    public float pointSize = 0.2f;

    public Queue<GameObject> order = new Queue<GameObject>();
    protected GameObject moving;
    protected bool dequeing;

    protected virtual void Update()
    {
        if (order.Count > 0 && !dequeing)
        {
            StartCoroutine(QueueCheck());
        }
    }

    [ContextMenu("Add Points")]
    void addPoints()
    {
        for (int i = 0; i < numPoints; i++)
        {
            GameObject point = new GameObject("point");

            point.AddComponent<BoxCollider2D>();
            point.AddComponent<point>();
            point.GetComponent<BoxCollider2D>().isTrigger = true;
            point.transform.localScale = new Vector3(pointSize, pointSize, pointSize);
            point.tag = "trafficObstacle";
            point.transform.parent = this.transform;
            point.transform.localPosition = new Vector3(0, 0, 0);
            point.layer = 2;

        }
    }

    public abstract IEnumerator QueueCheck();
}
