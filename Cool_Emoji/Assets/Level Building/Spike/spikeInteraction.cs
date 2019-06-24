using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player" && HealthAmount.hurt == false) {
            HealthAmount.takenDamage = 0.1f;
        }

    }
}
