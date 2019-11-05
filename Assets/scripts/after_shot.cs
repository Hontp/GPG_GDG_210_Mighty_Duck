using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class after_shot : MonoBehaviour
{
    private Material mat;
    public Material material;
    // Start is called before the first frame update
    void Start()
    {
        mat = new Material(material);
        mat.color = new Vector4(mat.color.r, mat.color.b, mat.color.g, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponentInChildren<Renderer>().material = mat;
        mat.color = new Vector4(mat.color.r, mat.color.b, mat.color.g, mat.color.a-Time.deltaTime*2);
        if (mat.color.a <= 0.01)
        {
            Destroy(mat);
            Destroy(gameObject);
        }
    }
}
