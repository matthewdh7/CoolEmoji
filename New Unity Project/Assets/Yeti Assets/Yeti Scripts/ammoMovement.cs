using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoMovement : MonoBehaviour {
    public int moveSpeed = 30;
    bool move;
    // Update is called once per frame
    void Start() {
        move = true;
    }
    void Update() {
        if (move) {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
        
    }
    void OnCollisionEnter2D(Collision2D col) {
        if(!(col.gameObject.tag == "Player")){
            move = false;
        }
        

    }

}
