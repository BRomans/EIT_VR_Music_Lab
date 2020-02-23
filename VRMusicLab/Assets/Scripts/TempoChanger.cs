using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoChanger : MonoBehaviour
{
    AudioSource m_MyAudioSource;
    public float speed = 0;
    UnityEngine.Audio.AudioMixerGroup pitchBendGroup;
    
    // Start is called before the first frame update
    void Start()
    {
        pitchBendGroup = Resources.Load<UnityEngine.Audio.AudioMixerGroup>("MusicLabMixer");
        m_MyAudioSource = GetComponent<AudioSource>();
        m_MyAudioSource.outputAudioMixerGroup = pitchBendGroup;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Two)) {
            increaseTempo();
        }
        if (OVRInput.Get(OVRInput.Button.One)) {
            decreaseTempo();
        }
        m_MyAudioSource.pitch = 1f+speed;
        pitchBendGroup.audioMixer.SetFloat("pitchBend", 1f / (1f+speed));
    }

    public void increaseTempo() {
        this.speed += 0.01f;
    }

    public void decreaseTempo() {
        this.speed -= 0.01f;
    }
}