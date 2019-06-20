using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMovement : MonoBehaviour {
    public float sawSpeed;
    Vector3 endPos;
    Vector3 startPos;
    bool direction = true;
    public CircleCollider2D saw;
    float endx;
    float endy;
    int horizontalMultiplier = 1;
    int verticalMultiplier = 1;
    int count = 0;
    public float turningSpeed = 1;
    public GameObject healthbar;

    // Start is called before the first frame update
    void Start() {
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        startPos = new Vector3(transform.GetChild(0).position.x, transform.GetChild(0).position.y, transform.GetChild(0).position.z);
        endPos = new Vector3(transform.GetChild(1).position.x, transform.GetChild(1).position.y, transform.GetChild(1).position.z);
        if (startPos.x > endPos.x) {
            endx = startPos.x - endPos.x;
            horizontalMultiplier *= -1;
        }
        else {
            endx = endPos.x - startPos.x;
        }

        if (startPos.y > endPos.y) {
            endy = startPos.y - endPos.y;
            verticalMultiplier *= -1;
        }
        else {
            endy = endPos.y - startPos.y;
        }
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update() {
        transform.GetChild(2).Rotate(new Vector3(0, 0, turningSpeed));
        Vector2 move = new Vector2((endx / sawSpeed) * horizontalMultiplier, (endy / sawSpeed) * verticalMultiplier);
        transform.Translate(move);
        count++;
        if (count >= sawSpeed) {
            horizontalMultiplier *= -1;
            verticalMultiplier *= -1;
            count = 0;
        }
        Debug.Log(HealthAmount.takenDamage);


    }
    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log(HealthAmount.takenDamage);
            if (col.gameObject.tag == "Player" && HealthAmount.takenDamage == 0) {
            HealthAmount.takenDamage = 0.1f;
            }
    
    }
}
