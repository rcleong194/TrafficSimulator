using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour, vehcile
{

    public float speed;
    public float maxSpeed;
    public float carBufferDistance = 1f;
    public Transform[] travelPoints;
    public Transform raycastPos;

    [SerializeField]private int travelPoint = 0;

    void Start()
    {
        speed = maxSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(raycastPos.position, raycastPos.right, carBufferDistance);
        Debug.DrawRay(transform.position, transform.right, Color.green);
        if (ray.collider != null)
        {
            switch (ray.collider.tag)
            {
                case "car":
                    speed = ray.collider.GetComponent<car>().speed;
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

    public void drive()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, travelPoints[travelPoint].position, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, travelPoints[travelPoint].position) < 0.001f)
        {
            if (travelPoint + 1 > travelPoints.Length - 1)
                travelPoint = 0;
            else
                travelPoint++;

            transform.right = travelPoints[travelPoint].position - transform.position;
        }
    }

}
