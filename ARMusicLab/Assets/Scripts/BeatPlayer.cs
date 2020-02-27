using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatPlayer : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
     void OnTriggerEnter(Collider other)
    {  
        
        if (other.gameObject.tag == "Beats")
        {
            audioSource.Play();
        }

    }

    void OnTriggerExit() {
        audioSource.Stop();
    }
}
