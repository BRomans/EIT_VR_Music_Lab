using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BeatPillarEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    [SerializeField] TempoSynchronizer tempoSync;
    [SerializeField] GameObject totemPillar;
    [SerializeField] GameObject totemSphere;
    [SerializeField] AudioSource audioSource;
    [SerializeField] private UnityEvent OnClick = new UnityEvent();
    bool totemActive = false;
    float rotationsPerMinute = 10.0f;

    private void Awake()
    {
    }

    private void Start() {
        DisableEmission();
    }

    private void Update() {
    
        if(totemActive) {
            totemSphere.transform.Rotate(0 ,6.0f * rotationsPerMinute * Time.deltaTime ,0);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("Hover IN");
        EnableEmission();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("Hover OUT");
        if(!totemActive) {
            DisableEmission();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("Down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("Up");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick.Invoke();
        
    }
    
    public void ChangeState() 
    {   
        this.totemActive = !this.totemActive;
        if(totemActive) {
            this.audioSource.Play();
            EnableEmission();
            tempoSync.SetMaster(audioSource);
        } else {
            this.audioSource.Stop();
            DisableEmission();
            tempoSync.RemoveMaster();
        }
    }

    public void SetState(bool active) {
        this.totemActive = active;
        if(totemActive) {
            this.audioSource.Play();
            EnableEmission();
            tempoSync.SetMaster(audioSource);
        } else {
            this.audioSource.Stop();
            DisableEmission();
            tempoSync.RemoveMaster();
        }
    }

    public void StartPulsating() {
        Material pillarMaterial = totemPillar.GetComponent<Renderer>().material;
        Material sphereMaterial = totemSphere.GetComponent<Renderer>().material;
        float floor = 0.3f;
        float ceiling = 1.0f;
        float emission = floor + Mathf.PingPong (Time.time, ceiling);

        Color baseColor = pillarMaterial.GetColor("_EmissionColor"); //Replace this with whatever you want for your base color at emission level '1'
        Color finalColor = baseColor * Mathf.LinearToGammaSpace (emission);    

        pillarMaterial.SetColor ("_EmissionColor", finalColor);
        sphereMaterial.SetColor ("_EmissionColor", finalColor);
    }

    public void DisableEmission() {
        Material pillarMaterial = totemPillar.GetComponent<Renderer>().material;
        Material sphereMaterial = totemSphere.GetComponent<Renderer>().material;
        pillarMaterial.DisableKeyword("_EMISSION");
        sphereMaterial.DisableKeyword("_EMISSION");
    }

    public void EnableEmission() {
        Material pillarMaterial = totemPillar.GetComponent<Renderer>().material;
        Material sphereMaterial = totemSphere.GetComponent<Renderer>().material;
        pillarMaterial.EnableKeyword("_EMISSION");
        sphereMaterial.EnableKeyword("_EMISSION");
    }
}
