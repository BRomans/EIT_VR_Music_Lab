using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public GameObject planeta1;
    public GameObject planeta2;
    public GameObject planeta3;
    public GameObject planeta4;
    public GameObject planeta5;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
{
    if (Input.GetMouseButtonDown(0))
    {
        Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        if (Physics.Raycast(raycast, out raycastHit))
        {
            Debug.Log("Something Hit");
            
            if (raycastHit.collider.name.Contains("Planet"))
            {
                raycastHit.collider.gameObject.SetActive(false);
            }
            else if(raycastHit.collider.name=="Uno")
            {
                planeta1.SetActive(true);
            }
            else if(raycastHit.collider.name=="Dos")
            {
                planeta2.SetActive(true);
            }
            else if(raycastHit.collider.name=="Tres")
            {
                planeta3.SetActive(true);
            }
            else if(raycastHit.collider.name=="Cuatro")
            {
                planeta4.SetActive(true);
            }
            else if(raycastHit.collider.name=="Cinco")
            {
                planeta5.SetActive(true);
            }
            /*if (raycastHit.collider.name == "Planet02 (1)")
            {
                Destroy("Planet02 (1)");
            }
            if (raycastHit.collider.name == "Planet02 (2)")
            {
                Destroy("Planet02 (2)");
            }
            if (raycastHit.collider.name == "Planet02 (3)")
            {
                Destroy("Planet02 (3)");
            }
            if (raycastHit.collider.name == "Planet02 (4)")
            {
                Destroy("Planet02 (4)");
            }*/
        }
    }
}
}
