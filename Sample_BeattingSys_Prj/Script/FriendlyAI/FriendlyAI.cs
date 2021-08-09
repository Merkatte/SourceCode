using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendlyAI : MonoBehaviour
{
    public bool following;
    NavMeshAgent nav;
    Animator animator;
    public GameObject target;
    public DetectEny detect;
    public bool Attack;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        nav.speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(nav.velocity.magnitude > 0.5f) {
            animator.SetBool("Move", true);
        } else {
            animator.SetBool("Move", false);
        }
        if(detect.target != null) {
            if(detect.target.activeInHierarchy == true) {
                nav.destination = detect.target.transform.position;
            } else {
                detect.target = null;
                Attack = false;
            }
        }
        if(following == true && detect.target == null) {
            nav.destination = target.transform.position;
            if(Vector3.Distance(transform.position, target.transform.position) > 20f) {
                transform.position = target.transform.position;
            }
        }
        if(Attack == true) {
            timer += Time.deltaTime;
            if(timer > 2) {
                animator.SetBool("Attack", true);
                timer = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("PlayerArea")) {
            nav.isStopped = true;

        }
        if(other.gameObject.CompareTag("EnemyArea")) {
            nav.isStopped = true;

            Attack = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("PlayerArea")) {
            nav.isStopped = false;
        }
        if(other.gameObject.CompareTag("EnemyArea")) {
            nav.isStopped = false;
            Attack = false;
        }
    }
}
