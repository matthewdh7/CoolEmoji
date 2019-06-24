using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Color c;
    Renderer rend;
    BoxCollider2D cd;
    Rigidbody2D rd;
    public bool initialState;
    public Sprite on;
    public Sprite off;
    SpriteRenderer spriteRenderer;

   public Color getColor() {
        return rend.material.GetColor("_Color");


    }
    // Start is called before the first frame update
    void Start()
    {
        rend=GetComponent<Renderer>();
        //  rend.material.SetColor("_Color",Color.red); 
        spriteRenderer = GetComponent<SpriteRenderer>();
        cd = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
        rd = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        rd.bodyType = RigidbodyType2D.Static;
        if (initialState)
        {
            spriteRenderer.sprite = on;
        }
        else { spriteRenderer.sprite = off; }
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteRenderer.sprite.Equals(on))
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

    public bool IsItOn() {

        return spriteRenderer.sprite.Equals(on);
    }
    public void ChangeState(bool on) {
        if (on)
        {
            spriteRenderer.sprite = this.on;

        }
        else { spriteRenderer.sprite = this.off; }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        


    }



    }


