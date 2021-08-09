using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextPos : MonoBehaviour
{
    public GameObject CamPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
    }
}
