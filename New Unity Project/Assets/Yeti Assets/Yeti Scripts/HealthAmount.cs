using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthAmount : MonoBehaviour {
    Rigidbody2D rb;
    public static bool hurt = false;
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
            hurt = true;
            healthAmount -= takenDamage;
            if(healthAmount <= 0) {
                takenDamage = 0;
                healthAmount = 1;
                hurt = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else {
                StartCoroutine(Wait());
                takenDamage = 0;
            }
            
        }
        ////checkHealth = healthAmount;
    }
   
    IEnumerator Wait() {
        yield return new WaitForSeconds(1.5f);   //Wait
        hurt = false;
    }
}