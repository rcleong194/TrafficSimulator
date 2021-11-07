using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPeople : MonoBehaviour
{
    public Transform travelPoint1;
    public GameObject person;
    public float lower = 8f;
    public float higher = 8f;
    void Start()
    {
        StartCoroutine(spawnPerson());
    }

    IEnumerator spawnPerson()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(lower, higher));
            GameObject gameobjectP = Instantiate(person);
            gameobjectP.transform.position = this.transform.position;
            person p = gameobjectP.GetComponent<person>();
            p.travelPoints[0] = travelPoint1;
        }
        
    }
}
