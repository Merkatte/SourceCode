using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rigid;
    Animator animator;
    public Conversation_Manager manager;
    public GameObject Hand;
    public float maxSpeed;
    public float rotSpeed;
    public float fallSpeed;
    public float jumpPower;
    Vector3 lookdirection;
    float timelimit = 0;
    public bool attacking;
    public bool jumping;
    public int nextcombo = 0;
    public bool GetHit;
    SphereCollider beatingHand;
    public int PlayerHP = 100;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        beatingHand = Hand.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.isTalk == false)
        {
            if (jumping == true && GetHit != true)
            {
                Move();
                AtkCombo();
                ComboTime();
            }
            Jump();
        }
    }
    void Move() {
        if (Input.GetKey(KeyCode.W))
        {
            lookdirection = new Vector3(
                transform.eulerAngles.x,
                Mathf.LerpAngle(transform.eulerAngles.y, Camera.main.transform.eulerAngles.y, Time.deltaTime * rotSpeed),
                transform.eulerAngles.z);
            transform.rotation = Quaternion.Euler(lookdirection);
            rigid.AddForce(transform.forward, ForceMode.Impulse);
            animator.SetBool("Move", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            lookdirection = new Vector3(
                transform.eulerAngles.x,
                Mathf.LerpAngle(transform.eulerAngles.y, Camera.main.transform.eulerAngles.y + 90, Time.deltaTime * rotSpeed),
                transform.eulerAngles.z);
            transform.rotation = Quaternion.Euler(lookdirection);
            rigid.AddForce(transform.forward, ForceMode.Impulse);
            animator.SetBool("Move", true);
        }
        else if (Input.GetKey(KeyCode.A)) {
            lookdirection = new Vector3(
                transform.eulerAngles.x,
                Mathf.LerpAngle(transform.eulerAngles.y, Camera.main.transform.eulerAngles.y - 90, Time.deltaTime * rotSpeed),
                transform.eulerAngles.z);
            transform.rotation = Quaternion.Euler(lookdirection);
            rigid.AddForce(transform.forward, ForceMode.Impulse);
            animator.SetBool("Move", true);
        }
        else if (Input.GetKey(KeyCode.S)) {
            lookdirection = new Vector3(
                transform.eulerAngles.x,
                Mathf.LerpAngle(transform.eulerAngles.y, Camera.main.transform.eulerAngles.y - 180, Time.deltaTime * rotSpeed),
                transform.eulerAngles.z);
            transform.rotation = Quaternion.Euler(lookdirection);
            rigid.AddForce(transform.forward, ForceMode.Impulse);       
            animator.SetBool("Move", true);
        } else {
            animator.SetBool("Move", false);
        }
        if (Mathf.Abs(rigid.velocity.x) > maxSpeed || Mathf.Abs(rigid.velocity.z) > maxSpeed)
        {
            Vector3 xzForce = new Vector3(rigid.velocity.x, 0, rigid.velocity.z);
            Vector3 yForce = new Vector3(0, rigid.velocity.y, 0);
            xzForce = Vector3.ClampMagnitude(xzForce, maxSpeed);
            yForce = Vector3.ClampMagnitude(yForce, fallSpeed);
            rigid.velocity = xzForce + yForce;
        }
    }
    void AtkCombo()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && nextcombo == 0)
        {
            attacking = true;
            animator.SetBool("Attack", true);
        }
        if(Input.GetKeyDown(KeyCode.Mouse0) && nextcombo == 1) {
            animator.SetBool("Attack1", true);
        }
        if(Input.GetKeyDown(KeyCode.Mouse0) && nextcombo == 2) {
            animator.SetBool("Attack2", true);
            nextcombo = 0;
            attacking = false;
            timelimit = 0;
        }
    }
    public void PrintEvent() {
        Debug.Log("이벤트 발생");
    }

    void ComboTime() {
        if (attacking == true) {
            timelimit += Time.deltaTime;
        }
        if (timelimit > 3) {
            attacking = false;
            timelimit = 0;
            nextcombo = 0;
        }
    }

    void Jump() {
        RaycastHit rayHit;
        float rayDistance = 0.2f;
        int layerMask = 1 << LayerMask.NameToLayer("Floor");
        Debug.DrawRay(transform.position, Vector3.down * rayDistance, Color.red, 0.5f);
        if(Physics.Raycast(transform.position, Vector3.down, out rayHit, rayDistance, layerMask)) {
            animator.SetBool("Jumping", false);
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) {
                jumping = true;
            }
        } else {
            jumping = false;
            animator.SetBool("Move", false);
            animator.SetBool("Jumping", true);
        }
        if(Input.GetKeyDown(KeyCode.Space) && jumping == true) {
            rigid.AddForce(transform.up * jumpPower, ForceMode.Impulse);
            animator.SetBool("Jumping", true);
            if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) {
                animator.SetBool("Jump", false);
                animator.SetBool("Jumping,", true);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("EnyHand")) {
            PlayerHP -= 10;
            animator.SetBool("GetHit", true);
        }
    }
}
