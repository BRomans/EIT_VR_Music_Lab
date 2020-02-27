using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class ModifyVolume : MonoBehaviour
{
    //public AudioListener musica;
    //public InteractionSlider slider; 
    public float musicVolume=0;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         musicVolume=GetComponent<InteractionSlider>().HorizontalSliderPercent;
         //Debug.Log(musicVolume);
         //musica.volume=musicVolume;
         AudioListener.volume = musicVolume;
    }
}
