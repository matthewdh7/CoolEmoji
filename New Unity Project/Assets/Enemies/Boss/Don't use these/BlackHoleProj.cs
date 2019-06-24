using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleProj: MonoBehaviour
{
 
    public Vector2 direction;
    Rigidbody2D rd;

    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        rd = gameObject.GetComponent<Rigidbody2D>();
        speed = 20;

        rd.velocity = direction* speed * Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 g;
        int o = Random.Range(0, 4);
        switch (o) {
            case 0:
                g = Vector2.right;
                break;
            case 1:
                g = Vector2.left;
                break;
            case 2:
                g = Vector2.down;
                break;
            case 3:
                g = Vector2.up;
                break;
            default:
                g = Vector2.up;
                break;

        }
        rd.velocity = g * speed * Time.deltaTime;
   
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //Gabe add it here

        }
        else if (col.gameObject.CompareTag("Boss")) {


        }
       

    }
}
