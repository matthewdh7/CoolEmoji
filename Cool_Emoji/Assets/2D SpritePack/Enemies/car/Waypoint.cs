using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Waypoint))]
public class Waypoint : MonoBehaviour
{

    // rotate means when car comes to the waypoint it will turn destroy means it will get destroyed 
    public bool rotate;
    public bool destroy;
    [HideInInspector]
    public bool completed;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        completed = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector2 GetVector() {
        return gameObject.transform.position;

    }
    public float GetX() {

        return GetVector().x;
    }
    public float GetY()
    {

        return GetVector().y;
    }


}
