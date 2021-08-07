using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject bullet;
    public GameObject instance_Bullet;
    public GameObject CannonPos;
    Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        instance_Bullet = Instantiate(bullet);
        instance_Bullet.transform.position = CannonPos.transform.position;
        rigid = instance_Bullet.GetComponent<Rigidbody>();
        rigid.AddForce(transform.forward * 160, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
