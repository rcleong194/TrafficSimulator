using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Could potentially make a class/interface that both car and person would inherit from. Would rather not though, looks like objects would need different functionality if it was expanded.
public class person : MonoBehaviour
{
    public float speed;
    public float lowerSpeed = .5f;
    public float upperSpeed =1.5f;
    private float constSpeed;
    public Transform[] travelPoints;

    [SerializeField] private int travelPoint = 0;
    void Start()
    {
        speed = Random.Range(lowerSpeed, upperSpeed);
        constSpeed = speed;
    }

    void Update()
    {
        walk();
    }

    public void walk()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, travelPoints[travelPoint].position, step);
    }

    public void stop()
    {
        speed = 0;
    }

    public void start()
    {
        speed = constSpeed;
    }
}
