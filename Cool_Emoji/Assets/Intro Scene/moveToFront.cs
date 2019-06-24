using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToFront : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<MeshRenderer>().sortingLayerName = "Arm";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
