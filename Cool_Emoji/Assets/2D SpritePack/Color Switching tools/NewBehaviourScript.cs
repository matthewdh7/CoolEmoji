using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public Sprite activated;
    public Sprite nonactivated;
    public GameObject colorBox;
    // Start is called before the first frame update
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = activated;
        gameObject.AddComponent<CircleCollider2D>();
        CircleCollider2D cd = gameObject.GetComponent<CircleCollider2D>() as CircleCollider2D;

        cd.radius = 1.426f;
       // Vector2 off = Vector2(-0.626f, 0.8475316f);
       // cd.offset = off;
       
    }
        // Update is called once per frame
        void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("changed");
                Colorblock.ChangeColor(Color.cyan, colorBox);

            }
        
    }


        void OnCollisionEnter2D(Collision2D col) {
            if (col.gameObject.CompareTag("bullet")) {
                Colorblock.ChangeColor(Color.cyan,colorBox);

            }

        }

    void change()
    {

        if (spriteRenderer.sprite.Equals( activated)) {
            spriteRenderer.sprite = nonactivated;

        }
        else {
            spriteRenderer.sprite = activated;
        }

    }
    
    

}
