using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{

    public float boatHp = 2500.0f;
    public float boatDmg = 1.0f;

    public int boatworth = 1000;

    public refrence_varables rv;
    public List<GameObject> fireSystem;

    private float hp;

    // Start is called before the first frame update
    void Start()
    {
        rv = GameObject.Find("Main Camera").GetComponent<refrence_varables>();  
        
        foreach( Transform part in transform)
        {
            if (part.gameObject.GetComponentInChildren<ParticleSystem>() != null)
            {
                fireSystem.Add(part.gameObject);
            }
        }

        hp = boatHp;
    }

    // Update is called once per frame
    void Update()
    {  
        transform.Translate(Vector3.forward * Time.deltaTime * rv.boatSpeed);


        if ( boatHp > 0 && boatHp <= (hp * 0.5f))
        {
            for (int i = 0; i < fireSystem.Count; i++)
            {
                if (fireSystem[i] != null)
                {
                    fireSystem[i].SetActive(true);
                }
            }
        }

        if (boatHp < 0)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < -225 || transform.position.x > 225)
        {
            // add boat count
            Destroy(gameObject);
            rv.boatCount -= 1;
        }
    }
}
