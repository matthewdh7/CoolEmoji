using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField]
    private float xMax;
    [SerializeField]
    private float xMin;
    [SerializeField]
    private float yMax;
    [SerializeField]
    private float yMin;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Yeti").transform;
        Debug.Log(target);
    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);
    }
}
