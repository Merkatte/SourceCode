using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnyDetector : MonoBehaviour
{
    EnemeAI eny;

    private void Start() {
        eny = GetComponentInParent<EnemeAI>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            eny.target = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            eny.target = null;
        }
    }
}
