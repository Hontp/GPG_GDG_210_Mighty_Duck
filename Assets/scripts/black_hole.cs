using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class black_hole : MonoBehaviour
{
    public List<GameObject> ducks_effected =null;
    public refrence_varables rv;
    public int player;

    // Start is called before the first frame update
    void Start()
    {
        rv = GameObject.Find("Main Camera").GetComponent<refrence_varables>();
        Destroy(gameObject, 7);

    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; ducks_effected.Count > i; i++)
        {
            ducks_effected[i].transform.position= Vector3.Lerp(ducks_effected[i].transform.position,transform.position,1f*Time.deltaTime);
            ducks_effected[i].transform.localScale = ducks_effected[i].transform.localScale * (1-Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "duck")
        {
            rv.populationCount -= 1;
            ducks_effected.Add(col.gameObject);
            col.gameObject.GetComponent<duck_Script>().stop = true;

            if (player == 1)
                rv.player_1_score += 5;

            if (player == 2)
                rv.player_2_score += 5;

            if (player == 3)
                rv.player_3_score += 5;

            if (player == 4)
                rv.player_4_score += 5;

            col.gameObject.transform.parent = gameObject.transform;
        }
    }

}
