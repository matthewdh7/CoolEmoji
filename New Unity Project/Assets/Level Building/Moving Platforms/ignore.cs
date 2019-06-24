using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignore : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        GameObject yeti = GameObject.Find("Yeti");
        transform.GetComponent<SpriteRenderer>().enabled = false;
        Physics2D.IgnoreCollision(transform.GetComponent<BoxCollider2D>(), yeti.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(transform.GetComponent<BoxCollider2D>(), yeti.GetComponent<CircleCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
