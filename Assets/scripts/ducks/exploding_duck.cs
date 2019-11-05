using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exploding_duck : MonoBehaviour
{
    float speed = 0;

    public int base_points_worth;
    public int point_worth;

    public bool fall = false;
    public bool stop;
    public refrence_varables rv;
    public GameObject explosion;
    public int player;

    bool crashed=false;
    // Start is called before the first frame update
    void Start()
    {
        rv = GameObject.Find("Main Camera").GetComponent<refrence_varables>();

        speed = Random.Range(0f, 0.1f);
        point_worth = base_points_worth + (int)(speed * 10);

    }

    // Update is called once per frame
    void Update()
    {


        if (fall == false && stop == false)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(rv.time) / 4, transform.position.z) + transform.right * -(rv.duck_move_speed + speed);
            duck_outBounds();

        }
        else if (fall == true)
        {
            if (GetComponent<BoxCollider>())
            {
                Destroy(GetComponent<BoxCollider>());
            }

            transform.position -= new Vector3(0, rv.duck_fall_speed/5, 0) * Time.deltaTime;
            transform.eulerAngles += new Vector3(0, -400, 400) * Time.deltaTime;
            if (transform.position.y < -10||crashed==true)
            {
                GameObject x;
                x = Instantiate(explosion, transform);
                x.transform.parent = null;
                x.GetComponent<explosion>().player = player;

                Destroy(gameObject);
            }
        }
        if (stop == true && fall == false)
        {
            transform.eulerAngles += new Vector3(0, 400, -400) * Time.deltaTime;

        }

    }

    public void duck_shot()
    {
        stop = true;

        Destroy(GetComponent<BoxCollider>());
        if (GetComponent<BoxCollider>())
        {
            Destroy(GetComponent<BoxCollider>());
        }
        rv.populationCount -= 1;
        StartCoroutine(duck_stop());
        GetComponent<ParticleSystem>().Play();
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
    IEnumerator duck_stop()
    {
        yield return new WaitForSeconds(0.25f);
        fall = true;
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            crashed = true;
        }
    }
}
