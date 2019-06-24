using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTrail : MonoBehaviour {
    GameObject yeti;
    public int moveSpeed = 30;
    // Update is called once per frame
    void Start() {
        yeti = GameObject.Find("Yeti full");
        Physics2D.IgnoreCollision(transform.GetComponent<BoxCollider2D>(), yeti.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(transform.GetComponent<BoxCollider2D>(), yeti.GetComponent<CircleCollider2D>());
    }
    void Update() {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        Destroy(this.gameObject, 3);
    }
    void OnCollisionEnter2D(Collision2D col) {
        Destroy(this.gameObject);
    }
}
    