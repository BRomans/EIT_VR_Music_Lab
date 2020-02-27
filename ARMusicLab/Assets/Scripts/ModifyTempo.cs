using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class ModifyTempo : MonoBehaviour
{
    public AudioSource[] m_MyAudioSource;
    public float speed = 0;
    UnityEngine.Audio.AudioMixerGroup pitchBendGroup;
    
    // Start is called before the first frame update
    void Start()
    {
        pitchBendGroup = Resources.Load<UnityEngine.Audio.AudioMixerGroup>("MusicLabMixer");
        
        for(int i=0; i<m_MyAudioSource.Length; i++)
         {
            //m_MyAudioSource[i] = GetComponent<AudioSource>();
            m_MyAudioSource[i].outputAudioMixerGroup = pitchBendGroup;
        }
    }

    // Update is called once per frame
    void Update()
    {
        speed=GetComponent<InteractionSlider>().HorizontalSliderPercent;
        speed -= 0.5f;
        for(int i=0; i<m_MyAudioSource.Length; i++)
         {
            m_MyAudioSource[i].pitch = 1f+speed;
            pitchBendGroup.audioMixer.SetFloat("pitchBend", 1f / (1f+speed));
         }
    }
}
