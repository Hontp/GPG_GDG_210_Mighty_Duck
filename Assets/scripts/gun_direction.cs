using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_direction : MonoBehaviour
{
    public GameObject crosshair;
    public crosshair_maneger cm;
    Vector3 lastpos;
    public float moving_smothness;

    public int player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == 1)
        {
            if (cm.Ray1.collider != null)
            {
                transform.LookAt(Vector3.Lerp(lastpos, cm.Ray1.point, moving_smothness));
                lastpos = Vector3.Lerp(lastpos, cm.Ray1.point, moving_smothness);
            }
            else
            {
                transform.LookAt(Vector3.Lerp(lastpos, crosshair.transform.position, moving_smothness));
                lastpos = Vector3.Lerp(lastpos, crosshair.transform.position, moving_smothness);
            }
        }
        if (player == 2)
        {
            if (cm.Ray2.collider != null)
            {
                transform.LookAt(Vector3.Lerp(lastpos, cm.Ray2.point, moving_smothness));
                lastpos = Vector3.Lerp(lastpos, cm.Ray2.point, moving_smothness);
            }
            else
            {
                transform.LookAt(Vector3.Lerp(lastpos, crosshair.transform.position, moving_smothness));
                lastpos = Vector3.Lerp(lastpos, crosshair.transform.position, moving_smothness);
            }
        }
        if (player == 3)
        {
            if (cm.Ray3.collider != null)
            {
                transform.LookAt(Vector3.Lerp(lastpos, cm.Ray3.point, moving_smothness));
                lastpos = Vector3.Lerp(lastpos, cm.Ray3.point, moving_smothness);
            }
            else
            {
                transform.LookAt(Vector3.Lerp(lastpos, crosshair.transform.position, moving_smothness));
                lastpos = Vector3.Lerp(lastpos, crosshair.transform.position, moving_smothness);
            }
        }
        if (player == 4)
        {
            if (cm.Ray4.collider != null)
            {
                transform.LookAt(Vector3.Lerp(lastpos, cm.Ray4.point, moving_smothness));
                lastpos = Vector3.Lerp(lastpos, cm.Ray4.point, moving_smothness);
            }
            else
            {
                transform.LookAt(Vector3.Lerp(lastpos, crosshair.transform.position, moving_smothness));
                lastpos = Vector3.Lerp(lastpos, crosshair.transform.position, moving_smothness);
            }
        }

    }
}
