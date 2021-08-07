using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
    public float slidePower;
    Vector3 lookdirection;
    float timelimit = 0;
    public bool jumping;
    public int nextcombo = 0;
    public bool GetHit;
    SphereCollider beatingHand;
    public int PlayerHP = 100;
    public float RecoveryTime;
    public bool slide;
    public bool onCylinder;

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
            if (jumping == true && GetHit != true && slide != true)
            {
                Move();
                Sliding();
            }
            Jump();
            if(GetHit == true) {
                Recover();
            }
        }
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.D))
            {
                lookdirection = new Vector3(
                    0,
                    Mathf.LerpAngle(transform.eulerAngles.y, Camera.main.transform.eulerAngles.y + 45, Time.deltaTime * rotSpeed),
                    0);
                transform.rotation = Quaternion.Euler(lookdirection);
                rigid.AddForce(transform.forward, ForceMode.Impulse);
                animator.SetBool("Move", true);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                lookdirection = new Vector3(
                    0,
                    Mathf.LerpAngle(transform.eulerAngles.y, Camera.main.transform.eulerAngles.y - 45, Time.deltaTime * rotSpeed),
                    0);
                transform.rotation = Quaternion.Euler(lookdirection);
                rigid.AddForce(transform.forward, ForceMode.Impulse);
                animator.SetBool("Move", true);
            }
            else
            {
                lookdirection = new Vector3(
                    0,
                    Mathf.LerpAngle(transform.eulerAngles.y, Camera.main.transform.eulerAngles.y, Time.deltaTime * rotSpeed),
                    0);
                transform.rotation = Quaternion.Euler(lookdirection);
                rigid.AddForce(transform.forward, ForceMode.Impulse);
                animator.SetBool("Move", true);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            lookdirection = new Vector3(

                0,
                Mathf.LerpAngle(transform.eulerAngles.y, Camera.main.transform.eulerAngles.y + 90, Time.deltaTime * rotSpeed),
                0);
            transform.rotation = Quaternion.Euler(lookdirection);
            rigid.AddForce(transform.forward, ForceMode.Impulse);
            animator.SetBool("Move", true);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            lookdirection = new Vector3(
                0,
                Mathf.LerpAngle(transform.eulerAngles.y, Camera.main.transform.eulerAngles.y - 45, Time.deltaTime * rotSpeed),
                0);
            transform.rotation = Quaternion.Euler(lookdirection);
            rigid.AddForce(transform.forward, ForceMode.Impulse);
            animator.SetBool("Move", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            lookdirection = new Vector3(
                0,
                Mathf.LerpAngle(transform.eulerAngles.y, Camera.main.transform.eulerAngles.y - 90, Time.deltaTime * rotSpeed),
                0);
            transform.rotation = Quaternion.Euler(lookdirection);
            rigid.AddForce(transform.forward, ForceMode.Impulse);
            animator.SetBool("Move", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.D))
            {
                lookdirection = new Vector3(
                    0,
                    Mathf.LerpAngle(transform.eulerAngles.y, Camera.main.transform.eulerAngles.y - 135, Time.deltaTime * rotSpeed),
                    0);
                transform.rotation = Quaternion.Euler(lookdirection);
                rigid.AddForce(transform.forward, ForceMode.Impulse);
                animator.SetBool("Move", true);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                lookdirection = new Vector3(
                    0,
                    Mathf.LerpAngle(transform.eulerAngles.y, Camera.main.transform.eulerAngles.y - 225, Time.deltaTime * rotSpeed),
                    0);
                transform.rotation = Quaternion.Euler(lookdirection);
                rigid.AddForce(transform.forward, ForceMode.Impulse);
                animator.SetBool("Move", true);
            }
            else
            {
                lookdirection = new Vector3(
                    0,
                    Mathf.LerpAngle(transform.eulerAngles.y, Camera.main.transform.eulerAngles.y - 180, Time.deltaTime * rotSpeed),
                    0);
                transform.rotation = Quaternion.Euler(lookdirection);
                rigid.AddForce(transform.forward, ForceMode.Impulse);
                animator.SetBool("Move", true);
            }
        }
        else
        {
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
    void Sliding() {
        if(Input.GetKeyDown(KeyCode.LeftShift) && slide != true) {
            slide = true;
            rigid.AddForce(transform.forward * slidePower, ForceMode.Impulse);
            animator.SetBool("Move", false);
            animator.SetBool("Jumping", false);
            animator.SetBool("Jump", false);
            animator.SetBool("sliding", true);
        } 
    }
    void Jump()
    {
        RaycastHit rayHit;
        float rayDistance = 1f;
        int layerMask = 1 << LayerMask.NameToLayer("Floor");
        Debug.DrawRay(transform.position, Vector3.down * rayDistance, Color.red, 0.5f);
        if (Physics.Raycast(transform.position, Vector3.down, out rayHit, rayDistance, layerMask))
        {
            if (GetHit != true)
            {
                animator.SetBool("Jumping", false);
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                {
                    jumping = true;
                }
            }
        }
        else
        {
            jumping = false;
            animator.SetBool("Move", false);
            animator.SetBool("Jumping", true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumping == true)
        {
            rigid.AddForce(transform.up * jumpPower, ForceMode.Impulse);
            animator.SetBool("Jumping", true);
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                animator.SetBool("Jump", false);
                animator.SetBool("Jumping,", true);
            }
        }
    }

    void Recover() {
        RaycastHit rayHit;
        float rayDistance = 1.5f;
        int layerMask = 1 << LayerMask.NameToLayer("Floor");
        Debug.DrawRay(transform.position, Vector3.down * rayDistance, Color.green, 0.5f);
        if (Physics.Raycast(transform.position, Vector3.down, out rayHit, rayDistance, layerMask)) {
            RecoveryTime += Time.deltaTime;
            if(RecoveryTime >= 3) {
                rigid.DORotate(new Vector3(0, 0, 0), 0.5f).OnComplete(() => {
                    rigid.freezeRotation = true;
                    GetHit = false;
                    RecoveryTime = 0;
                });
            }
        } else {
            RecoveryTime = 0;
        }
    }


    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Bullet"))
        {
            rigid.freezeRotation = false;
            GetHit = true;
        }
    }
}
