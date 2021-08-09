using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyEventController : MonoBehaviour
{
    public GameObject AtkHand;
    Animator animator;
    SphereCollider sphereCollider;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sphereCollider = AtkHand.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    public void colliderOn() {
        sphereCollider.enabled = true;
    }
    public void colliderOff() {
        Debug.Log("공격 수행함");
        sphereCollider.enabled = false;
        animator.SetBool("Attack", false);
    }
}
