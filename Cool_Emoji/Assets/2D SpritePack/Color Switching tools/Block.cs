using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Color c;
    Renderer rend;
    BoxCollider2D cd;
    Rigidbody2D rd;

   public Color getColor() {
        return rend.material.GetColor("_Color");


    }
    // Start is called before the first frame update
    void Start()
    {
        rend=GetComponent<Renderer>();
        //  rend.material.SetColor("_Color",Color.red); 

        cd = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
        rd = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        rd.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        if (rend.material.GetColor("_Color").Equals(Color.blue))
        {
            cd.enabled = true;

        }
        else
        {
            cd.enabled = false;
        }

    }

    public void ChangeColor(Color c) {

        Renderer rend = gameObject.GetComponent<Renderer>();
        rend.material.SetColor("_Color", c);

    }

    void OnCollisionEnter2D(Collision2D col)
    {

        


    }



    }


