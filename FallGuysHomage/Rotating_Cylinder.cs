using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating_Cylinder : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotSpeed;
    public float moveSpeed;

    Rigidbody rigid;
    public Cylinder child;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, -rotSpeed * Time.deltaTime));
    }
    

}
