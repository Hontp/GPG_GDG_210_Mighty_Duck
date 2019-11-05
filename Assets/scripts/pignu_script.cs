using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pignu_script : MonoBehaviour
{
    public int base_points_worth;
    public int point_worth;

    public int health;
    public GameObject partical_effect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameObject X;
            Destroy(gameObject, 0.1f);
            X = Instantiate(partical_effect, transform);
            X.transform.parent = null;
        }
    }
}
