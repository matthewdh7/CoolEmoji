using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballMovement : MonoBehaviour
{
    public int fireballSpeed = 30;
    // Update is called once per frame

    void Update() {
        transform.Translate(Vector3.right * Time.deltaTime * fireballSpeed);
        Destroy(this.gameObject, 5);

    }
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player" && HealthAmount.hurt == false) {
            HealthAmount.takenDamage = 0.1f;
        }
        Destroy(this.gameObject);

    }

}
