using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //speed = upperSpeed;
        constSpeed = speed;
    }

    // Update is called once per frame
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
