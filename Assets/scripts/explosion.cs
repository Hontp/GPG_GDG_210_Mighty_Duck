using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public refrence_varables rv;

    public Material explosion1;
    public Material explosion2;

    Material mat1;
    Material mat2;

    bool fade=false;

    public int player;
    // Start is called before the first frame update
    void Start()
    {
        mat1 = new Material(explosion1);
        mat2 = new Material(explosion2); 

        rv = GameObject.Find("Main Camera").GetComponent<refrence_varables>();
        //    Destroy(gameObject, 0.5f);
        transform.GetChild(0).GetComponent<Renderer>().material = (mat2);
        GetComponent<Renderer>().material = mat1;

        StartCoroutine(fadedelay());
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(1,1,1) * rv.expolsion_size*Time.deltaTime;
        if (fade == true)
        {
            mat1.color = new Vector4(mat1.color.r, mat1.color.b, mat1.color.g, mat1.color.a - Time.deltaTime);
            mat2.color = new Vector4(mat2.color.r, mat2.color.b, mat2.color.g, mat2.color.a - Time.deltaTime);

            if (mat1.color.a <= 0.1)
            {
                Destroy(gameObject);
            }
        }


    }
    IEnumerator fadedelay()
    {
        yield return new WaitForSeconds(0.7f);
        fade = true;
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "duck")
        {
            rv.populationCount -= 1;

            Destroy(col.gameObject,4);

            if(col.gameObject.GetComponent<duck_Script>()!=null)
                Destroy(col.gameObject.GetComponent<duck_Script>());

            if (col.gameObject.GetComponent<black_hole_duck>() != null)
                Destroy(col.gameObject.GetComponent<black_hole_duck>());

            if (col.gameObject.GetComponent<exploding_duck>() != null)
                Destroy(col.gameObject.GetComponent<exploding_duck>());

            col.gameObject.AddComponent<Rigidbody>();


            if (player == 1)
                rv.player_1_score += 5;

            if (player == 2)
                rv.player_2_score += 5;

            if (player == 3)
                rv.player_3_score += 5;

            if (player == 4)
                rv.player_4_score += 5;

        }
    }

}
