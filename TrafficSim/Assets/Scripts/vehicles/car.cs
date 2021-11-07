using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour, vehicle
{

    [SerializeField] protected float speed;
    [SerializeField] protected float maxSpeed;
    [SerializeField] protected float carBufferDistance = 1f;
    public Transform[] travelPoints;
    public Transform raycastPos;

    private int travelPoint = 0;
    public bool atObstacle = false;

    void Start()
    {
        speed = maxSpeed;
    }

    protected virtual void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(raycastPos.position, raycastPos.right, carBufferDistance);
        Debug.DrawRay(transform.position, transform.right, Color.green);
        if (!atObstacle)
        {
            if (ray.collider != null)
            {
                //Add to case for more tag types.
                switch (ray.collider.tag)
                {
                    case "car":
                        speed = ray.collider.GetComponent<car>().speed;
                        if (ray.distance < carBufferDistance)
                            speed = speed / 2;
                        drive();
                        break;
                    default:
                        drive();
                        break;
                }
            }
            else
            {
                speed = maxSpeed;
                drive();
            }
        }
    }

    public virtual void drive()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, travelPoints[travelPoint].position, step);
        if (Vector3.Distance(transform.position, travelPoints[travelPoint].position) < 0.001f)
        {
            if (travelPoint + 1 > travelPoints.Length - 1)
                travelPoint = 0;
            else
                travelPoint++;

            transform.right = travelPoints[travelPoint].position - transform.position;
        }
    }

    public virtual void stop()
    {
        speed = 0;
    }

    public virtual void start()
    {
        speed = maxSpeed;
    }

}
