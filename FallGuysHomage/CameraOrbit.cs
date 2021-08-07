using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public GameObject target;
    public float rotateSpeed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = rotateSpeed * Input.GetAxisRaw("Mouse X");
        float v = rotateSpeed * Input.GetAxisRaw("Mouse Y");
        transform.position = target.transform.position;
        if (transform.eulerAngles.z + v <= 0.1f || transform.eulerAngles.z + v >= 179.9f) {
            v = 0;
        }
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + h, transform.eulerAngles.z + v);
    }
}
