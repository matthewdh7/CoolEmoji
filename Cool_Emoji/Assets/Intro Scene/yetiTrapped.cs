using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yetiTrapped : MonoBehaviour
{
    public int count = 0;
    int iterator = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(count%2 == 0) {
            if (iterator < 75) {
                transform.Translate(Vector2.up * waveMovement.movement);
            }
            else {
                transform.Translate(Vector2.down * waveMovement.movement);
                if (iterator > 150) {
                    iterator = 0;
                }
            }
            iterator++;
        }
        count++;
        if(count > 10) {
            count = 0;
        }
        
        
    }
}
