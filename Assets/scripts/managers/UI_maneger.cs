using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_maneger : MonoBehaviour
{
    public refrence_varables rv;
    public game_maneger gm;

    public TMP_Text player_1_socre;
    public TMP_Text player_2_socre;
    public TMP_Text player_3_socre;
    public TMP_Text player_4_socre;

    public TMP_Text start_countdown;

    public float time;

    public GameObject menue;
    public GameObject game_Initiation;
    public GameObject game_play;
    public GameObject game_Over;

    public TMP_Text highscores;

    // Start is called before the first frame update
    void Start()
    {
        rv = GetComponent<refrence_varables>();
        gm = GetComponent<game_maneger>();
    }

    // Update is called once per frame
    void Update()
    {
        player_1_socre.text = "player1 socre: " + rv.player_1_score.ToString();
        if (!rv.isActive1)
            player_1_socre.text = "";

        player_2_socre.text = "player2 socre: " + rv.player_2_score.ToString();
        if (!rv.isActive2)
            player_2_socre.text = "";

        player_3_socre.text = "player3 socre: " + rv.player_3_score.ToString();
        if (!rv.isActive3)
            player_3_socre.text = "";

        player_4_socre.text = "player4 socre: " + rv.player_4_score.ToString();
        if (!rv.isActive4)
            player_4_socre.text = "";
            
        if (gm.Game_State == 0)
        {
            menue.SetActive(true);
            game_Initiation.SetActive(false);
            game_play.SetActive(false);
            game_Over.SetActive(false);
            time = 0;
        }
        if (gm.Game_State == 1)
        {
            time += Time.deltaTime;
            start_countdown.text = (5-(int)time).ToString();

            menue.SetActive(false);
            game_Initiation.SetActive(true);
            game_play.SetActive(false);
            game_Over.SetActive(false);
        }
        if (gm.Game_State == 2)
        {
            menue.SetActive(false);
            game_Initiation.SetActive(false);
            game_play.SetActive(true);
            game_Over.SetActive(false);
        }
        if (gm.Game_State == 3)
        {
            highscores.text = "1st: " + rv.highscores[0].ToString() + " \n" + "2nd: " + rv.highscores[1].ToString() + "\n" + "3rd: " + rv.highscores[2].ToString() + "\n" + "\n" + "green score: " + rv.currentscores[0].ToString() + "\n" + "red score: " + rv.currentscores[1].ToString() + "\n" + "cyan score: " + rv.currentscores[2].ToString() + "\n" + "Magenta score" + rv.currentscores[3].ToString();

            menue.SetActive(false);
            game_Initiation.SetActive(false);
            game_play.SetActive(false);
            game_Over.SetActive(true);
        }
    }
}
