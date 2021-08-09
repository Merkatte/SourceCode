using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SphereObj : MonoBehaviour
{
    int playOnlyOnce;
    Rigidbody rigid;
    Rigidbody thisObj;
    // Start is called before the first frame update
    void Start()
    {
        thisObj = GetComponent<Rigidbody>();
        if(transform.position.x > 60) {
            playOnlyOnce = 0;
        } else if(transform.position.x < 25){
            playOnlyOnce = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playOnlyOnce == 0 && transform.position.x > 60) {
            playOnlyOnce++;
            StartCoroutine(Wandering());
        } else if(playOnlyOnce == 1 && transform.position.x < 25) {
            playOnlyOnce--;
            StartCoroutine(Wandering());
        }
    }

    IEnumerator Wandering() {
        yield return new WaitForSecondsRealtime(2);
        if(playOnlyOnce == 1) {
            transform.DOMoveX(24, 1);
        } else if(playOnlyOnce == 0) {
            transform.DOMoveX(61, 1);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            Debug.Log("충돌");
            rigid = other.gameObject.GetComponent<Rigidbody>();
            rigid.AddForce(new Vector3(40, 0, 0), ForceMode.Impulse);
        }
    }
}
