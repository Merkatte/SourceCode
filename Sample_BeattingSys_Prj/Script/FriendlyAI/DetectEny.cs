using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEny : MonoBehaviour
{
    public GameObject target;
    public FriendlyAI friendly;
    SphereCollider sphereCollider;
    // Start is called before the first frame update
    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(friendly.following == true) {
            sphereCollider.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Enemy")) {
            target = other.gameObject;
        }
    }
}
