using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigSaw : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,1));
    }
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player" && HealthAmount.hurt == false) {
            HealthAmount.takenDamage = 1f;
        }

    }
}
