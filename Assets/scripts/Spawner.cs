using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] spwanPoints = new GameObject[3];
    public float spawnTime = 3;

    public refrence_varables rv;

    public GameObject duck = null;
    public GameObject fatDuck = null;
    public GameObject spaceTimeDuck = null;
    public GameObject explodingDuck = null;
    public GameObject forceDuck = null;

    
    private bool isSpawned = false;
    private float timePassed;

    private bool spawnFatDuck = false;
    private bool spawnTimeDuck = false;
    private bool spawnexpDuck = false;
    private bool spawnforceDuck = false;

#if UNITY_EDITOR
    [SerializeField]
    private float populationCount = 0;
#endif

    private void Start()
    {
        rv = GameObject.Find("Main Camera").GetComponent<refrence_varables>();

#if UNITY_EDITOR
        populationCount = rv.populationCount;
#endif
    }


    void Update()
    {
        int spwanIndex = 0;

        spwanIndex = Random.Range(0, 5);

        timePassed += Time.deltaTime;

        if (timePassed >= spawnTime)
        {
            isSpawned = false;
        }

        if (!isSpawned && (rv.populationCount < rv.populationCap))
        {

            float chance = Random.Range(0.0f, 4.0f);

            if (chance <= 0.27f)
            { 
                spawnFatDuck = true;
            }
            else
            {
                spawnFatDuck = false;
            }

            if (chance < 0.1f)
            {
                spawnTimeDuck = true;
            }
            else
            {
                spawnTimeDuck = false;
            }

            if (chance < 0.2f)
            {
                spawnexpDuck = true;
            }
            else
            {
                spawnexpDuck = false;
            }

            if (chance < 0.3f)
            {
                spawnforceDuck = true;
            }
            else
            {
                spawnforceDuck = false;
            }

            if (spawnFatDuck)
            {
                _ = Instantiate(fatDuck, spwanPoints[spwanIndex].transform.position, spwanPoints[spwanIndex].transform.rotation);

                rv.populationCount++;

                
                isSpawned = true;
                timePassed = 0;
            }        
            else
            {
                _ = Instantiate(duck, spwanPoints[spwanIndex].transform.position, spwanPoints[spwanIndex].transform.rotation);

                rv.populationCount++;

                isSpawned = true;
                timePassed = 0;
            }

            if(spawnTimeDuck)
            {
                _ = Instantiate(spaceTimeDuck, spwanPoints[spwanIndex].transform.position, spwanPoints[spwanIndex].transform.rotation);

                rv.populationCount++;

                isSpawned = true;
                timePassed = 0;
            }

            if (spawnexpDuck)
            {
                _ = Instantiate(explodingDuck, spwanPoints[spwanIndex].transform.position, spwanPoints[spwanIndex].transform.rotation);

                rv.populationCount++;

                isSpawned = true;
                timePassed = 0;
            }

            if (spawnforceDuck)
            {
                _ = Instantiate(forceDuck, spwanPoints[spwanIndex].transform.position, spwanPoints[spwanIndex].transform.rotation);

                rv.populationCount++;

                isSpawned = true;
                timePassed = 0;
            }
        }

#if UNITY_EDITOR
        populationCount = rv.populationCount;
#endif

    }
}
