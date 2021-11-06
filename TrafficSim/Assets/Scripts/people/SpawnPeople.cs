using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPeople : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform travelPoint1;
    public GameObject person;
    public float lower = 8f;
    public float higher = 8f;
    void Start()
    {
        StartCoroutine(spawnPerson());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnPerson()
    {
        //yield return new WaitForSeconds(Random.Range(1f, 30f));
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(lower, higher));
            //yield return new WaitForSeconds(10);
            GameObject gameobjectP = Instantiate(person);
            gameobjectP.transform.position = this.transform.position;
            person p = gameobjectP.GetComponent<person>();
            p.travelPoints[0] = travelPoint1;
        }
        
    }
}
