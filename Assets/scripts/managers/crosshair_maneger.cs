using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshair_maneger : MonoBehaviour
{
    public refrence_varables rv;
    public GameObject camera;
    public GameObject crosshair1;
    public GameObject crosshair2;
    public GameObject crosshair3;
    public GameObject crosshair4;

    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
    public GameObject gun4;



    public Vector3 raycast1;
    public Vector3 raycast2;
    public Vector3 raycast3;
    public Vector3 raycast4;

    public RaycastHit Ray1;
    public RaycastHit Ray2;
    public RaycastHit Ray3;
    public RaycastHit Ray4;

    public GameObject feather_explosion;
    public GameObject aftershot;

    public GameObject forec_feild;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        rv = GameObject.Find("Main Camera").GetComponent<refrence_varables>();
        crosshair1 = GameObject.Find("crosshair 1");
        crosshair2 = GameObject.Find("crosshair 2");
        crosshair3 = GameObject.Find("crosshair 3");
        crosshair4 = GameObject.Find("crosshair 4");
        ResetValues();
    }

    // Update is called once per frame
    void Update()
    { 
        
        crosshair1.SetActive(rv.isActive1);
        crosshair2.SetActive(rv.isActive2);
        crosshair3.SetActive(rv.isActive3);
        crosshair4.SetActive(rv.isActive4);

        if (Input.GetButton("confirm 1"))
        {
            rv.isActive1 = true;
        }
        if (Input.GetButton("confirm 2"))
        {
            rv.isActive2 = true;
        }
        if (Input.GetButton("confirm 3"))
        {
            rv.isActive3 = true;
        }
        if (Input.GetButton("confirm 4"))
        {
            rv.isActive4 = true;
        }

        raycast1 = (crosshair1.transform.position - camera.transform.position).normalized;
        bool hit = Physics.SphereCast(camera.transform.position,2f, raycast1, out Ray1);
        if (hit)
        {
            Debug.DrawLine(camera.transform.position, Ray1.point);
        }
        raycast2 = (crosshair2.transform.position - camera.transform.position).normalized;
        Physics.SphereCast(camera.transform.position,2f , raycast2, out Ray2);

        raycast3 = (crosshair3.transform.position - camera.transform.position).normalized;
        Physics.SphereCast(camera.transform.position,2f, raycast3, out Ray3);

        raycast4 = (crosshair4.transform.position - camera.transform.position).normalized;
        Physics.SphereCast(camera.transform.position,2f, raycast4, out Ray4);


        Rigidbody2D RB2D1 =crosshair1.GetComponent<Rigidbody2D>();
        Rigidbody2D RB2D2 = crosshair2.GetComponent<Rigidbody2D>();
        Rigidbody2D RB2D3 = crosshair3.GetComponent<Rigidbody2D>();
        Rigidbody2D RB2D4 = crosshair4.GetComponent<Rigidbody2D>();
        //player 1 movement
        if ((RB2D1.velocity.x < 20 && RB2D1.velocity.x > -20) && (RB2D1.velocity.y < 20 && RB2D1.velocity.y > -20))
        {
            RB2D1.velocity += new Vector2(Input.GetAxisRaw("Horizontal 1"), -Input.GetAxisRaw("Vertical 1"))*5;
        }
        else
        {
            RB2D1.velocity = RB2D1.velocity *0.9f;
        }
        if((Input.GetAxisRaw("Horizontal 1")==0 )|| (Input.GetAxisRaw("Horizontal 1")< 0 && RB2D1.velocity.x > 0) || (Input.GetAxisRaw("Horizontal 1") > 0 && RB2D1.velocity.x < 0))
        {
            RB2D1.velocity = new Vector2(RB2D1.velocity.x / 2-(1*Time.deltaTime), RB2D1.velocity.y);
            
        }
        if ((Input.GetAxisRaw("Vertical 1") == 0) ||  (Input.GetAxisRaw("Vertical 1") > 0 && RB2D1.velocity.y > 0) || (Input.GetAxisRaw("Vertical 1") < 0 && RB2D1.velocity.y < 0))
        {
            RB2D1.velocity = new Vector2(RB2D1.velocity.x, RB2D1.velocity.y/ 2 - (1 * Time.deltaTime));
           
        }

        //player 2 movement
        if ((RB2D2.velocity.x < 20 && RB2D2.velocity.x > -20) && (RB2D2.velocity.y < 20 && RB2D2.velocity.y > -20))
        {
            RB2D2.velocity += new Vector2(Input.GetAxisRaw("Horizontal 2"), -Input.GetAxisRaw("Vertical 2")) * 5;
        }
        else
        {
            RB2D2.velocity = RB2D2.velocity * 0.9f;
        }
        if ((Input.GetAxisRaw("Horizontal 2") == 0) || (Input.GetAxisRaw("Horizontal 2") < 0 && RB2D2.velocity.x > 0) || (Input.GetAxisRaw("Horizontal 2") > 0 && RB2D2.velocity.x < 0))
        {
            RB2D2.velocity = new Vector2(RB2D2.velocity.x / 2 - (1 * Time.deltaTime), RB2D2.velocity.y);

        }
        if ((Input.GetAxisRaw("Vertical 2") == 0) || (Input.GetAxisRaw("Vertical 2") > 0 && RB2D2.velocity.y > 0) || (Input.GetAxisRaw("Vertical 2") < 0 && RB2D2.velocity.y < 0))
        {
            RB2D2.velocity = new Vector2(RB2D2.velocity.x, RB2D2.velocity.y / 2 - (1 * Time.deltaTime));

        }
        //player 3 movement
        if ((RB2D3.velocity.x < 20 && RB2D3.velocity.x > -20) && (RB2D3.velocity.y < 20 && RB2D3.velocity.y > -20))
        {
            RB2D3.velocity += new Vector2(Input.GetAxisRaw("Horizontal 3"), -Input.GetAxisRaw("Vertical 3")) * 5;
        }
        else
        {
            RB2D3.velocity = RB2D3.velocity * 0.9f;
        }
        if ((Input.GetAxisRaw("Horizontal 3") == 0) || (Input.GetAxisRaw("Horizontal 3") < 0 && RB2D3.velocity.x > 0) || (Input.GetAxisRaw("Horizontal 3") > 0 && RB2D3.velocity.x < 0))
        {
            RB2D3.velocity = new Vector2(RB2D3.velocity.x / 2 - (1 * Time.deltaTime), RB2D3.velocity.y);

        }
        if ((Input.GetAxisRaw("Vertical 3") == 0) || (Input.GetAxisRaw("Vertical 3") > 0 && RB2D3.velocity.y > 0) || (Input.GetAxisRaw("Vertical 3") < 0 && RB2D3.velocity.y < 0))
        {
            RB2D3.velocity = new Vector2(RB2D3.velocity.x, RB2D3.velocity.y / 2 - (1 * Time.deltaTime));

        }
        //player 4 movement
        if ((RB2D4.velocity.x < 20 && RB2D4.velocity.x > -20) && (RB2D4.velocity.y < 20 && RB2D4.velocity.y > -20))
        {
            RB2D4.velocity += new Vector2(Input.GetAxisRaw("Horizontal 4"), -Input.GetAxisRaw("Vertical 4")) * 5;
        }
        else
        {
            RB2D4.velocity = RB2D4.velocity * 0.9f;
        }
        if ((Input.GetAxisRaw("Horizontal 4") == 0) || (Input.GetAxisRaw("Horizontal 4") < 0 && RB2D4.velocity.x > 0) || (Input.GetAxisRaw("Horizontal 4") > 0 && RB2D4.velocity.x < 0))
        {
            RB2D4.velocity = new Vector2(RB2D4.velocity.x / 2 - (1 * Time.deltaTime), RB2D4.velocity.y);

        }
        if ((Input.GetAxisRaw("Vertical 4") == 0) || (Input.GetAxisRaw("Vertical 4") > 0 && RB2D4.velocity.y > 0) || (Input.GetAxisRaw("Vertical 4") < 0 && RB2D4.velocity.y < 0))
        {
            RB2D4.velocity = new Vector2(RB2D4.velocity.x, RB2D4.velocity.y / 2 - (1 * Time.deltaTime));

        }


        crosshair4.transform.position += new Vector3(Input.GetAxisRaw("Horizontal 4"), -Input.GetAxisRaw("Vertical 4"), 0) / 5;


        if (Input.GetButtonDown("fire 1") && rv.isActive1) 
        {


            //recoil
            GameObject x;
            x = Instantiate(aftershot, gun1.transform);
            x.transform.parent = null;
            x.transform.position = gun1.transform.position;
            if (Ray1.collider != null)
            {
                x.transform.LookAt(Ray1.point);
            }
            else
            {
                x.transform.LookAt(crosshair1.transform.position);
            }
            x.transform.eulerAngles += new Vector3(90, 0, 0);
            x.transform.localScale = new Vector3(0.1f, Vector3.Distance(gun1.transform.position, Ray1.point), 0.1f);

            RB2D1.velocity += new Vector2(Random.Range(-20f, 20), 20);
            if (Ray1.collider != null && Ray1.collider.gameObject.tag == "duck")
            {
                GameObject duck = Ray1.collider.gameObject;
                Instantiate(feather_explosion, duck.transform.position, Quaternion.identity);
                //duck death event



                if (duck.GetComponent<duck_Script>() != null)
                {
                    if (duck.GetComponent<duck_Script>().fall == false)
                    {
                        duck.GetComponent<duck_Script>().duck_shot();
                        rv.player_1_score += duck.GetComponent<duck_Script>().point_worth + (int)(Ray1.distance / 10);
                    }
                    if (duck.GetComponent<duck_Script>().forceDuck == true)
                    {
                        Instantiate(forec_feild, crosshair1.transform);
                    }
                }
                if (duck.GetComponent<black_hole_duck>() != null)
                {
                    duck.GetComponent<black_hole_duck>().player = 1;
                    duck.GetComponent<black_hole_duck>().fall = true;
                    duck.GetComponent<black_hole_duck>().duck_shot();

                    rv.player_1_score += duck.GetComponent<black_hole_duck>().point_worth + (int)(Ray4.distance / 10);
                }
                if (duck.GetComponent<pignu_script>() != null)
                {
                    duck.GetComponent<pignu_script>().health -= 1;
                    rv.player_1_score += duck.GetComponent<pignu_script>().base_points_worth;
                    if (duck.GetComponent<pignu_script>().health == 0)
                    {
                        rv.player_1_score += duck.GetComponent<pignu_script>().point_worth;
                    }
                }
                if (duck.GetComponent<exploding_duck>() != null)
                {
                    duck.GetComponent<exploding_duck>().player = 1;
                    duck.GetComponent<exploding_duck>().duck_shot();

                    rv.player_1_score += duck.GetComponent<exploding_duck>().point_worth + (int)(Ray4.distance / 10);
                }
            }

            if (Ray1.collider != null && Ray1.collider.gameObject.tag == "boat")
            {
               
                GameObject boat = Ray1.collider.gameObject;
               if (boat.GetComponent<Boat>() != null)
                {
                    boat.GetComponent<Boat>().boatHp -= boat.GetComponent<Boat>().boatDmg;
                    rv.player_1_score += boat.GetComponent<Boat>().boatworth;

                }
            }
            
        }
        if (Input.GetButtonDown("fire 2") && rv.isActive2)
        {
            //recoil
            GameObject x;
            x = Instantiate(aftershot, gun2.transform);
            x.transform.parent = null;
            x.transform.position = gun2.transform.position;
            if (Ray2.collider != null)
            {
                x.transform.LookAt(Ray2.point);
            }
            else
            {
                x.transform.LookAt(crosshair2.transform.position);
            }
            x.transform.eulerAngles += new Vector3(90, 0, 0);
            x.transform.localScale = new Vector3(0.1f, Vector3.Distance(gun2.transform.position, Ray2.point), 0.1f);

            RB2D2.velocity += new Vector2(Random.Range(-20f,20), 20);
            if ( Ray2.collider != null && Ray2.collider.gameObject.tag == "duck" )
            {
                GameObject duck = Ray2.collider.gameObject;
                Instantiate(feather_explosion, duck.transform.position, Quaternion.identity);
                //duck death event


                if (duck.GetComponent<duck_Script>() != null)
                {
                    if (duck.GetComponent<duck_Script>().fall == false)
                    {
                        duck.GetComponent<duck_Script>().duck_shot();
                        rv.player_2_score += duck.GetComponent<duck_Script>().point_worth + (int)(Ray2.distance / 10);
                    }
                    if (duck.GetComponent<duck_Script>().forceDuck == true)
                    {
                        Instantiate(forec_feild, crosshair2.transform);
                    }
                }
                if (duck.GetComponent<black_hole_duck>() != null)
                {
                    duck.GetComponent<black_hole_duck>().player = 2;
                    duck.GetComponent<black_hole_duck>().fall = true;
                    duck.GetComponent<black_hole_duck>().duck_shot();

                    rv.player_2_score += duck.GetComponent<black_hole_duck>().point_worth + (int)(Ray4.distance / 10);
                }
                if (duck.GetComponent<pignu_script>() != null)
                {
                    duck.GetComponent<pignu_script>().health -= 1;

                    rv.player_2_score += duck.GetComponent<pignu_script>().base_points_worth;
                    if (duck.GetComponent<pignu_script>().health == 0)
                    {
                        rv.player_2_score += duck.GetComponent<pignu_script>().point_worth;
                    }
                }
                if (duck.GetComponent<exploding_duck>() != null)
                {
                    duck.GetComponent<exploding_duck>().player = 2;
                    duck.GetComponent<exploding_duck>().duck_shot();

                    rv.player_2_score += duck.GetComponent<exploding_duck>().point_worth + (int)(Ray4.distance / 10);
                }

            }

            if (Ray2.collider != null && Ray2.collider.gameObject.tag == "boat")
            {


                GameObject boat = Ray2.collider.gameObject;
                if (boat.GetComponent<Boat>() != null)
                {
                    boat.GetComponent<Boat>().boatHp -= boat.GetComponent<Boat>().boatDmg;
                    rv.player_2_score += boat.GetComponent<Boat>().boatworth;

                }
            }
        }
        if (Input.GetButtonDown("fire 3") && rv.isActive3)
        {
            //recoil
            GameObject x;
            x = Instantiate(aftershot, gun3.transform);
            x.transform.parent = null;
            x.transform.position = gun3.transform.position;
            if (Ray3.collider != null)
            {
                x.transform.LookAt(Ray3.point);
            }
            else
            {
                x.transform.LookAt(crosshair3.transform.position);
            }
            x.transform.eulerAngles += new Vector3(90, 0, 0);
            x.transform.localScale = new Vector3(0.1f, Vector3.Distance(gun3.transform.position, Ray3.point), 0.1f);

            RB2D3.velocity += new Vector2(Random.Range(-20f, 20), 20);
            if ( Ray3.collider != null && Ray3.collider.gameObject.tag == "duck")
            {

                GameObject duck = Ray3.collider.gameObject;
                Instantiate(feather_explosion, duck.transform.position, Quaternion.identity);
                //duck death event


                if (duck.GetComponent<duck_Script>() != null)
                {
                    if (duck.GetComponent<duck_Script>().fall == false)
                    {
                        duck.GetComponent<duck_Script>().duck_shot();
                        rv.player_3_score += duck.GetComponent<duck_Script>().point_worth + (int)(Ray3.distance / 10); ;
                    }
                    if (duck.GetComponent<duck_Script>().forceDuck == true)
                    {
                        Instantiate(forec_feild, crosshair3.transform);
                    }
                }
                if (duck.GetComponent<black_hole_duck>() != null)
                {
                    duck.GetComponent<black_hole_duck>().player = 3;
                    duck.GetComponent<black_hole_duck>().fall = true;
                    duck.GetComponent<black_hole_duck>().duck_shot();

                    rv.player_3_score += duck.GetComponent<black_hole_duck>().point_worth + (int)(Ray4.distance / 10);
                }
                if (duck.GetComponent<pignu_script>() != null)
                {
                    duck.GetComponent<pignu_script>().health -= 1;

                    rv.player_3_score += duck.GetComponent<pignu_script>().base_points_worth;
                    if (duck.GetComponent<pignu_script>().health == 0)
                    {
                        rv.player_3_score += duck.GetComponent<pignu_script>().point_worth;
                    }
                }
                if (duck.GetComponent<exploding_duck>() != null)
                {
                    duck.GetComponent<exploding_duck>().player = 3;
                    duck.GetComponent<exploding_duck>().duck_shot();

                    rv.player_3_score += duck.GetComponent<exploding_duck>().point_worth + (int)(Ray4.distance / 10);
                }
            }

            if (Ray3.collider != null && Ray3.collider.gameObject.tag == "boat")
            {
                print("(;");
                GameObject boat = Ray3.collider.gameObject;
                if (boat.GetComponent<Boat>() != null)
                {
                    boat.GetComponent<Boat>().boatHp -= boat.GetComponent<Boat>().boatDmg;
                    rv.player_3_score += boat.GetComponent<Boat>().boatworth;

                }
            }
        }
        if (Input.GetButtonDown("fire 4")&&rv.isActive4)
        {
            GameObject x;
            x = Instantiate(aftershot, gun4.transform);
            x.transform.parent = null;
            x.transform.position = gun4.transform.position;
            if (Ray4.collider != null)
            {
                x.transform.LookAt(Ray4.point);
            }
            else
            {
                x.transform.LookAt(crosshair4.transform.position);
            }
            x.transform.eulerAngles += new Vector3(90, 0, 0);
            x.transform.localScale = new Vector3(0.1f, Vector3.Distance(gun4.transform.position, Ray4.point), 0.1f);

            RB2D4.velocity += new Vector2(Random.Range(-20f, 20), 20);
            if (Ray4.collider != null && Ray4.collider.gameObject.tag == "duck")
            {
                GameObject duck = Ray4.collider.gameObject;
                Instantiate(feather_explosion, duck.transform.position, Quaternion.identity);
                //duck death event


                if (duck.GetComponent<duck_Script>() != null)
                {
                    if (duck.GetComponent<duck_Script>().fall == false)
                    {
                        duck.GetComponent<duck_Script>().duck_shot();
                        rv.player_4_score += duck.GetComponent<duck_Script>().point_worth + (int)(Ray4.distance / 10);
                    }
                    if (duck.GetComponent<duck_Script>().forceDuck == true)
                    {
                        Instantiate(forec_feild, crosshair4.transform);
                    }
                }
                if (duck.GetComponent<black_hole_duck>() != null)
                {
                    duck.GetComponent<black_hole_duck>().player = 4;
                    duck.GetComponent<black_hole_duck>().fall = true;
                    duck.GetComponent<black_hole_duck>().duck_shot();
                    rv.player_4_score += duck.GetComponent<black_hole_duck>().point_worth + (int)(Ray4.distance / 10);
                }
                if (duck.GetComponent<pignu_script>() != null)
                {
                    duck.GetComponent<pignu_script>().health -= 1;
                    rv.player_4_score += duck.GetComponent<pignu_script>().base_points_worth;
                    if (duck.GetComponent<pignu_script>().health == 0)
                    {
                        rv.player_4_score += duck.GetComponent<pignu_script>().point_worth;
                    }
                }
                if (duck.GetComponent<exploding_duck>() != null)
                {
                    duck.GetComponent<exploding_duck>().player = 4;
                    duck.GetComponent<exploding_duck>().duck_shot();

                    rv.player_4_score += duck.GetComponent<exploding_duck>().point_worth + (int)(Ray4.distance / 10);
                }
            }

            if (Ray4.collider != null && Ray4.collider.gameObject.tag == "boat")
            {
                GameObject boat = Ray4.collider.gameObject;
                if (boat.GetComponent<Boat>() != null)
                {
                    boat.GetComponent<Boat>().boatHp -= boat.GetComponent<Boat>().boatDmg;
                    rv.player_4_score += boat.GetComponent<Boat>().boatworth;

                }
            }
        }
    }
    public void ResetValues()
    {
        crosshair1.transform.position = new Vector3(-11, 3.77f, -45);
        crosshair2.transform.position = new Vector3(-4, 3.77f, -45);
        crosshair3.transform.position = new Vector3(4, 3.77f, -45);
        crosshair4.transform.position = new Vector3(11, 3.77f, -45);
    }
}
