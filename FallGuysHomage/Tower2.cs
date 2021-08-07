using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower2 : MonoBehaviour
{
    public GameObject bullet;
    public GameObject instance_Bullet;
    public GameObject CannonPos;
    Rigidbody rigid;
    float shootDelay;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shootDelay += Time.deltaTime;
        if (shootDelay >= 3)
        {
            instance_Bullet = Instantiate(bullet);
            instance_Bullet.transform.position = CannonPos.transform.position;
            rigid = instance_Bullet.GetComponent<Rigidbody>();
            rigid.AddForce(transform.forward * 130, ForceMode.Impulse);
            shootDelay = 0;
        }
    }
}
