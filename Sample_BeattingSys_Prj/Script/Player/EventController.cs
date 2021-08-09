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

    public void colliderOn() {
        beatingHandR.enabled = true;
    }

    public void colliderOff()
    {
        animator.SetBool("Attack", false);
        beatingHandR.enabled = false;
        player.nextcombo++;
    }

    public void SecondColliderOn() {
        beatingHandR.enabled = true;
        beatingHandL.enabled = true;
    }

    public void SecondColliderOff() {
        animator.SetBool("Attack1", false);
        beatingHandR.enabled = false;
        beatingHandL.enabled = false;
        player.nextcombo++;
    }

    public void ThirdColliderOn() {
        beatingHandR.enabled = true;
    }
    public void ThirdColliderOff() {
        animator.SetBool("Attack2", false);
        beatingHandR.enabled = false;
    }
    public void HitOn() {
        player.GetHit = true;
    }
    public void HitOff() {
        player.GetHit = false;
        animator.SetBool("GetHit", false);
    }
}
