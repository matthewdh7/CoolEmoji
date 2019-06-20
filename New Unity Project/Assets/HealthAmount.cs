using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAmount : MonoBehaviour {
    Rigidbody2D rb;
    public static float takenDamage = 0;
    public static float healthAmount;
    float checkHealth = 1;

    // Start is called before the first frame update
    void Start() {
        healthAmount = 1;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if(takenDamage > 0) {
            Debug.Log("Yep");
            healthAmount -= takenDamage;
            StartCoroutine(Wait());
            takenDamage = 0;
        }
        ////checkHealth = healthAmount;
    }
   
    IEnumerator Wait() {
        yield return new WaitForSeconds(10);   //Wait
    }
}