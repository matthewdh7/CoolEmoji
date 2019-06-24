using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBox : MonoBehaviour
{
    public int spikeTiming;
    public Sprite spikeOutTexture;
    public Sprite spikeInTexture;
    int count;
    bool spikeOut;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        spikeOut = false;
        transform.GetChild(0).gameObject.SetActive(spikeOut);
    }

    // Update is called once per frame
    void Update()
    {
        if(count >= spikeTiming) {
            spikeOut = !spikeOut;
            transform.GetChild(0).gameObject.SetActive(spikeOut);
            count = 0;
            if(spikeOut == true) {
                transform.GetComponent<SpriteRenderer>().sprite = spikeOutTexture;
            }
            else {
                transform.GetComponent<SpriteRenderer>().sprite = spikeInTexture;
            }
            
        }
        count++;
    }
}
