using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EventController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject RHand;
    public GameObject LHand;
    SphereCollider beatingHandR;
    SphereCollider beatingHandL;
    Player player;
    Animator animator;
    private void Start() {
        beatingHandR = RHand.GetComponent<SphereCollider>();
        beatingHandL = LHand.GetComponent<SphereCollider>();
        player = GetComponentInParent<Player>();
        animator = GetComponent<Animator>();
    }
    public void slideEnd() {
        player.slide = false;
        animator.SetBool("sliding", false);
    }
}
