using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnyEventController : MonoBehaviour
{
    public GameObject AtkHand;
    SphereCollider sphereCollider;
    Animator animator;
    private void Start() {
        sphereCollider = AtkHand.GetComponent<SphereCollider>();
        animator = GetComponent<Animator>();
    }
    public IEnumerator kill() {
        yield return new WaitForSeconds(1);
        transform.parent.gameObject.SetActive(false);
    }

    public void colliderOn() {
        sphereCollider.enabled = true;
    }
    public void colliderOff() {
        Debug.Log("공격끝");
        sphereCollider.enabled = false;
        animator.SetBool("Attack", false);
    }
}
