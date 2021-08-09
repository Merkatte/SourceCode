using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemeAI : MonoBehaviour
{
    Animator animator;
    NavMeshAgent nav;
    public int EnemyHp = 100;
    // Start is called before the first frame update
    public GameObject target;
    public bool StartAttack;
    public float attackTime;
    float timer;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyHp <= 0) {
            animator.SetBool("Die", true);
            nav.isStopped = true;
        }
        if(target != null) {
            nav.destination = target.transform.position;
        }
        if(StartAttack == true) {
            timer += Time.deltaTime;
            if(timer > attackTime) {
                animator.SetBool("Attack", true);
                timer = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("BeatHand")) {
            animator.SetTrigger("GetHit");
            EnemyHp -= 25;
        }
        if(other.gameObject.CompareTag("FriendlyBeatHand")) {
            animator.SetTrigger("GetHit");
            EnemyHp -= 10;
        }
        if(other.gameObject.CompareTag("PlayerArea")) {
            nav.isStopped = true;
            StartAttack = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("PlayerArea")) {
            nav.isStopped = false;
            StartAttack = false;
        }
    }
}
