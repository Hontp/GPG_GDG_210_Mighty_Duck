using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class force_feild : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 startsize;
    float time;
    void Start()
    {
        Destroy(gameObject, 5);
        startsize= transform.localScale= new Vector3(0.1f, 0.1f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime*50;


        transform.localScale = new Vector3(Mathf.Clamp(startsize.x*time,startsize.x,3), Mathf.Clamp(startsize.y * time, startsize.y, 3), 1);
    }
}
