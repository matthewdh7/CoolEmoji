using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block2 : MonoBehaviour
{


    BoxCollider cd;
    Rigidbody2D rd;

    Renderer rend;
    // Start is called before the first frame update
    public Color getColor()
    {
        return rend.material.GetColor("_Color");


    }
    void Start()
    {
        rend = GetComponent<Renderer>();
        //  rend.material.SetColor("_Color",Color.red); 
        cd = gameObject.GetComponent<BoxCollider>() as BoxCollider;
        rd = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        
    }

    // Update is called once per frame
    void Update()
    {




    }

    public void ChangeColor(Color c)
    {

        Renderer rend = gameObject.GetComponent<Renderer>();
        rend.material.SetColor("_Color", c);

    }

}
