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
        Debug.Log("COLLISION");
         audioSource.Play();
        if (other.gameObject.tag == "Beats")
        {
           
        }

    }

    void OnTriggerExit() {
        audioSource.Stop();
    }
}
