using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_maneger : MonoBehaviour
{
    public int Game_State=0;
    public refrence_varables rv;
    public crosshair_maneger cm;
    bool corutineTick=false;
    

    // Start is called before the first frame update
    void Start()
    {
        
        rv = GetComponent<refrence_varables>();
        cm = GameObject.Find("crosshair maneger").GetComponent<crosshair_maneger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        //start and menue
        if (Game_State == 0)
        {
            if ((Input.GetButtonDown("fire 1") && rv.isActive1) || (Input.GetButtonDown("fire 2") && rv.isActive2) || (Input.GetButtonDown("fire 3") && rv.isActive3) || (Input.GetButtonDown("fire 4") && rv.isActive4))
            {
                game_Stae1();
                cm.ResetValues();
                //resets scores
                
            }
        }
        //game initolisation
        if (Game_State == 1)
        {
            //reset crosshair position
            cm.ResetValues();

            if(!corutineTick)
                StartCoroutine(inisalisation_phase());
        }
        //game runing
        if (Game_State == 2)
        {
            if(!corutineTick)
                StartCoroutine(gamePlay_phase());
        }
        //game over and restart to game_state0
        if (Game_State == 3)
        {
            if (Input.GetButtonDown("confirm 1") || Input.GetButtonDown("confirm 2") || Input.GetButtonDown("confirm 3") || Input.GetButtonDown("confirm 4"))
            {
                rv.ResetValues();
                game_Stae0();
            }
        }
    }

    public void game_Stae0()
    {
        Game_State = 0;
    }
    public void game_Stae1()
    {
        Game_State = 1;
    }
    public void game_Stae2()
    {
        Game_State = 2;
    }
    public void game_Stae3()
    {
        Game_State = 3;
        
    }

    IEnumerator inisalisation_phase()
    {
        corutineTick = true;
        yield return new WaitForSeconds(5);
        Game_State = 2;
        corutineTick = false;
    }

    IEnumerator gamePlay_phase()
    {
        corutineTick = true;
        yield return new WaitForSeconds(60);
        Game_State = 3;
        corutineTick = false;
        rv.Update_scores();
    }
}
