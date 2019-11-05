using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refrence_varables : MonoBehaviour
{
    public List<int> highscores;
    public List<int> currentscores;

    public int player_1_score;
    public int player_2_score;
    public int player_3_score;
    public int player_4_score;

    public bool isActive1 = false;
    public bool isActive2 = true;
    public bool isActive3 = false;
    public bool isActive4 = false;

    public bool isdayTime;
    public bool isnightTime;

    public float time;

    public float duck_move_speed;
    public float duck_fall_speed;

    public float populationCap =  35;
    public float populationCount = 0;

    public float spaceTimeCap = 3;
    public float spaceTimeCount = 0;

    public float boatSpeed = 5.0f;
    public float boatSpawnTime = 15.0f;
    public float maxBoat = 1;
    public float boatCount = 0;

    public float daylength;
    public float nightlength;

    public float expolsion_size;


    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("highscore 1"))
        {
            PlayerPrefs.SetInt("highscore 1", 0);
            PlayerPrefs.SetInt("highscore 2", 0);
            PlayerPrefs.SetInt("highscore 3", 0);
        }

        highscores.Add(PlayerPrefs.GetInt("highscore 1"));
        highscores.Add(PlayerPrefs.GetInt("highscore 2"));
        highscores.Add(PlayerPrefs.GetInt("highscore 3"));

      
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * 2;

        
        
    }

    //resets all values
    public void ResetValues()
    {
        player_1_score = 0;
        player_2_score = 0;
        player_3_score = 0;
        player_4_score = 0;

        isActive1 = false;
        isActive2 = false;
        isActive3 = false;
        isActive4 = false;
    }
    public void Update_scores()
    {
        int Highscore_pos = 0;
        currentscores.Clear();
        currentscores.Add(player_1_score);
        currentscores.Add(player_2_score);
        currentscores.Add(player_3_score);
        currentscores.Add(player_4_score);
        for (int x = 0; 4 > x; x++)
        {
            for (int y = 0; 3 > y; y++)
            {
                if (highscores[y] < currentscores[x])
                {
                    Highscore_pos += 1;
                    
                }
            }
            if (Highscore_pos == 1)
            {
                highscores.Insert(2, currentscores[x]);
                highscores.RemoveAt(3);
                Highscore_pos = 0;
            }
            if (Highscore_pos == 2)
            {
                highscores.Insert(1, currentscores[x]);
                highscores.RemoveAt(3);
                Highscore_pos = 0;

            }
            if (Highscore_pos == 3)
            {
                highscores.Insert(0, currentscores[x]);
                highscores.RemoveAt(3);
                Highscore_pos = 0;

            }

        }
        PlayerPrefs.SetInt("highscore 1", highscores[0]);
        PlayerPrefs.SetInt("highscore 2", highscores[1]);
        PlayerPrefs.SetInt("highscore 3", highscores[2]);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt("highscore 1"));
    }

    
}
