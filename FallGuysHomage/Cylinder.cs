using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    public Rigidbody playerRigid;
    
    private void OnCollisionEnter(Collision other) {
        playerRigid = other.gameObject.GetComponent<Rigidbody>();
        if(other.gameObject.CompareTag("Player")) {
            other.gameObject.transform.SetParent(transform.parent.transform);
        }
    }

    private void OnCollisionExit(Collision other) {
        if(other.gameObject.CompareTag("Player")) {
            other.gameObject.transform.SetParent(null);
        }
    }
}
