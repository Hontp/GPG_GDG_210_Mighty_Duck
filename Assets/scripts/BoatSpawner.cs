using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawner : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject boat;

    public refrence_varables rv;

    private bool isSpawned = false;
    private float timePassed;

    // Start is called before the first frame update
    void Start()
    {
        rv = GameObject.Find("Main Camera").GetComponent<refrence_varables>();
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed >= rv.boatSpawnTime)
        {
            isSpawned = false;
        }

      
        if (!isSpawned && (rv.boatCount < rv.maxBoat))
        {

            _ = Instantiate(boat, spawnPoint.transform.position, spawnPoint.transform.rotation);

            rv.boatCount++;
            isSpawned = true;
            timePassed = 0;
           
        }
 
    }
}
