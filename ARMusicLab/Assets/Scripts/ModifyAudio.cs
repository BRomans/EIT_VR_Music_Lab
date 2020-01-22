using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifyAudio : MonoBehaviour
{

    public Slider TempoSlider;
    public Slider PitchSlider;
    public Slider VolumeSlider;

    public float minPitch = -3.0f;
    public float maxPitch = 3.0f;

    AudioSource audioSource;


    [SerializeField] float currentPitch = 1.0f;
    [SerializeField] float currentTempo = 1.0f;
    [SerializeField] float currentVolume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        PitchSlider = GameObject.Find("PitchSlider").GetComponent<Slider>();
        TempoSlider = GameObject.Find("TempoSlider").GetComponent<Slider>();
        VolumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();

        audioSource = GetComponent<AudioSource>();

        //Initialize the pitch
        audioSource.pitch = currentPitch;
        audioSource.volume = currentVolume;
    }

    // Update is called once per frame
    void Update()
    {
        if(PitchSlider.value < maxPitch && PitchSlider.value > minPitch)
        {
            audioSource.pitch = PitchSlider.value;
        }

        audioSource.volume = VolumeSlider.value;


        Debug.Log("pitch: "+PitchSlider.value);
        Debug.Log("volume: " + VolumeSlider.value);

        transform.Rotate(new Vector3(0, PitchSlider.value * 30, 0) * Time.deltaTime);


    }
}
