using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class trafficObstacle : MonoBehaviour
{
    [SerializeField] protected int numPoints = 4;

    public Queue<GameObject> order = new Queue<GameObject>();
    public GameObject pointPrefab;
    protected GameObject moving;
    protected bool dequeing;

    protected virtual void Update()
    {
        if (order.Count > 0 && !dequeing)
        {
            StartCoroutine(QueueCheck());
        }
    }
    
    //Adds a number of points to an object using context menu
    [ContextMenu("Add Points")]
    void addPoints()
    {
        for (int i = 0; i < numPoints; i++)
        {
            GameObject.Instantiate(pointPrefab,transform,false);
        }
    }

    public abstract IEnumerator QueueCheck();
}
