using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorblock : MonoBehaviour
{

    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend=GetComponent<Renderer>();
        rend.material.SetColor("_Color",Color.red); 
       
        
    }

    // Update is called once per frame
    void Update()
    {
        

        rend.material.SetColor("_Color",Color.yellow);
        
    }

     void ChangeColor(Color c) {
        rend.material.SetColor("_Color", c);

    }
}
