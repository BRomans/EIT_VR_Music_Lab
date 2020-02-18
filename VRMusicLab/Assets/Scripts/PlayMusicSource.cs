using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicSource : MonoBehaviour
{

    public AudioSource theaudio;   
          
 
    void OnCollisionEnter ()  //Plays Sound Whenever collision detected
    {
        theaudio.Play ();
    }
          
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
