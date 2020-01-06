using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrab : MonoBehaviour
{

    public GameObject CollidingObject;

    public GameObject objectInHand;
    
    
    public void OnTriggerEnter(Collider other) {

        if(other.gameObject.GetComponent())
        {

            CollidingObject = other.gameObject;

        }

    }

    public void OnTriggerExit(Collider other) {

        CollidingObject = null;

    }

    public void GrabObject() {

        objectInHand = CollidingObject;

        objectInHand.transform.SetParent (this.transform);

        objectInHand.GetComponent<RigidBody>().isKinematic = true;

    }

    private void ReleaseObject() {

        objectInHand.GetComponent<RigidBody>().isKinematic = false;

        objectInHand.transform.SetParent (null);

        objectInHand = null;

    }

}
}
