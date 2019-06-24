using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public static float movement = .01f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (introVisuals.moveWaves == true) {
            transform.Translate(Vector2.right * movement);
        }
        
        

    }
}
