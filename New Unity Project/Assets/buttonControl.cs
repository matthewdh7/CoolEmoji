using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonControl : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame() {
        Debug.Log("Made it");
        SceneManager.LoadScene("Intro");
    }
    public void Quit() {
        Application.Quit();
    }
}
