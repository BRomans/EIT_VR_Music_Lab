using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BeatPillarEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color enterColor = Color.white;
    [SerializeField] private Color downColor = Color.white;
    [SerializeField] GameObject totemPillar;
    [SerializeField] GameObject totemSphere;
    [SerializeField] AudioSource audioSource;
    [SerializeField] private UnityEvent OnClick = new UnityEvent();
    bool totemActive = false;

    private MeshRenderer meshRenderer = null;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start() {
       DisableEmission();
    }

    private void Update() {
    
        if(totemActive) {
            Material pillarMaterial = totemPillar.GetComponent<Renderer>().material;
            Material sphereMaterial = totemSphere.GetComponent<Renderer>().material;
            float floor = 0.3f;
            float ceiling = 1.0f;
            float emission = floor + Mathf.PingPong (Time.time, ceiling - floor);

            Color baseColor = pillarMaterial.GetColor("_EmissionColor"); //Replace this with whatever you want for your base color at emission level '1'
    
            Color finalColor = baseColor * Mathf.LinearToGammaSpace (emission);
    
            pillarMaterial.SetColor ("_EmissionColor", finalColor);
            sphereMaterial.SetColor ("_EmissionColor", finalColor);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        meshRenderer.material.color = enterColor;
        print("Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        meshRenderer.material.color = normalColor;
        print("Exit");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        meshRenderer.material.color = downColor;
        print("Down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        meshRenderer.material.color = enterColor;
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
        } else {
            this.audioSource.Stop();
            DisableEmission();
        }
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
