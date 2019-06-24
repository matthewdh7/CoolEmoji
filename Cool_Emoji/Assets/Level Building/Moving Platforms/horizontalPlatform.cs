using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontalPlatform : MonoBehaviour
{
    public float platSpeed = 60f;
    int left = 1;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {

        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(1/platSpeed * left, 0));
        
    }
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "HorizontalPlatform") {
            left *= -1;
        }

    }
}
