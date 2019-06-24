using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introVisuals : MonoBehaviour
{
    public static bool moveWaves = false;
    int scene;
    bool keepGoing = true;
    // Start is called before the first frame update
    void Start()
    {
    
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Trapped Yeti").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Wave").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Wave 1").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Banner").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("destroyedCity").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("destroyedCity").transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("destroyedCity").transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        scene = 0;
        StartCoroutine(FirstWait());
        


    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Wait() {
        if (keepGoing) {
            Debug.Log("nO");
            transform.GetChild(scene).GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(3f);   //Wait
            transform.GetChild(scene).GetComponent<SpriteRenderer>().enabled = false;
            scene++;
            if (scene == 1) {
                keepGoing = false;
                StartCoroutine(AnotherWait());
            }
            if (scene == 2) {
                Debug.Log("He");
                GameObject.Find("Trapped Yeti").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("Wave").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("Wave 1").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("Banner").GetComponent<SpriteRenderer>().enabled = true;
                moveWaves = true;
                StartCoroutine(SolidWait());


            }
            else {
                StartCoroutine(Wait());
            }
        }
        


    }
    IEnumerator FirstWait() {
        yield return new WaitForSeconds(3f);   //Wait
        transform.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(Wait());
    }
    IEnumerator SolidWait() {
        yield return new WaitForSeconds(3f);   //Wait
        GameObject.Find("Trapped Yeti").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Wave").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Wave 1").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Banner").GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(ThirdWait());
    }
    IEnumerator ThirdWait() {
        transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(3f);   //Wait
        SceneManager.LoadScene("SampleScene");
    }
    IEnumerator AnotherWait() {
        GameObject.Find("destroyedCity").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("destroyedCity").transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("destroyedCity").transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(3f);   //Wait
        GameObject.Find("destroyedCity").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("destroyedCity").transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("destroyedCity").transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        transform.GetComponent<SpriteRenderer>().enabled = false;
        keepGoing = true;
        StartCoroutine(Wait());
    }

}
