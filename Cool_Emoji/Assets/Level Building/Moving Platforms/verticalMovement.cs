using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verticalMovement : MonoBehaviour
{
    public float vertSpeed = 15f;
    int top = 1;
    // Start is called before the first frame update
    void Start() {



    }

    // Update is called once per frame
    void Update() {
        transform.Translate(new Vector2(0, 1 / vertSpeed * top));

    }
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "VerticalPlatform") {
            top *= -1;
        }

    }
}