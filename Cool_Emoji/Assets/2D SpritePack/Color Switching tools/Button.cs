using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public Sprite activated;
    public Sprite nonactivated;

    // Start is called before the first frame update
    SpriteRenderer spriteRenderer;
    List<GameObject> blocks;
    List<Block> block_script;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = activated;
        blocks = new List<GameObject>();
        block_script = new List<Block>();
        CircleCollider2D cd = gameObject.AddComponent<CircleCollider2D>() as CircleCollider2D;
        Rigidbody2D rd = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        rd.bodyType = RigidbodyType2D.Static;
        cd.radius = 1.426f;
        foreach (Transform child in transform)
        {
            blocks.Add(child.gameObject);



        }

        foreach (GameObject blo in blocks)
        {
          
            block_script.Add(blo.GetComponent<Block>());

        }
        foreach (Block b in block_script)
        {
            b.ChangeColor(Color.red);

        }
        // Vector2 off = Vector2(-0.626f, 0.8475316f);
        // cd.offset = off;

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("changed");
            foreach (Block b in block_script)
            {
                b.ChangeColor(Color.red);

            }

        }
        
    }


        void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Bullet"){
            change();

            Destroy(col.gameObject);
            foreach (Block b in block_script)
            {
               b.ChangeColor(Color.blue);

            }

        }

    }

    void change()
    {

        if (spriteRenderer.sprite.Equals(activated)) {
            spriteRenderer.sprite = nonactivated;

        }
        else {
            spriteRenderer.sprite = activated;
        }

    }
    
    

}
