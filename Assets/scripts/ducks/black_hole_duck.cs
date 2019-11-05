using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class black_hole_duck : MonoBehaviour
{
    float speed = 0;

    public int base_points_worth;
    public int point_worth;

    public bool fall = false;
   
    public refrence_varables rv;

    public int player;

    public GameObject Blackhole;

    // Start is called before the first frame update
    void Start()
    {
        rv = GameObject.Find("Main Camera").GetComponent<refrence_varables>();

        speed = Random.Range(0f, 1f);
        point_worth = base_points_worth + (int)(speed * 10);

    }

    // Update is called once per frame
    void Update()
    {

        
        if (fall == false)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(rv.time) / 4, transform.position.z) + transform.right * -(rv.duck_move_speed + speed);
            duck_outBounds();

        }

    }

    public void duck_shot()
    {
        GameObject X;
        X = Instantiate(Blackhole, transform);
        X.transform.parent = null;
        X.transform.localScale = new Vector3(1, 1, 1);
        X.GetComponent<black_hole>().player = player;

        
        Destroy(GetComponent<BoxCollider>());
        if (GetComponent<BoxCollider>())
        {
            Destroy(GetComponent<BoxCollider>());
        }
        rv.populationCount -= 1;

        Destroy(gameObject);
    }

    void duck_outBounds()
    {
        if (transform.position.x < -225 || transform.position.x > 225)
        {
            // add pop count
            Destroy(gameObject);
            rv.populationCount -= 1;
        }
    }
   
}
