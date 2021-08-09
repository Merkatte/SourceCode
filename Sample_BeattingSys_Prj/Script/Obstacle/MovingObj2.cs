using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MovingObj2 : MonoBehaviour
{
    public GameObject Target;
    // Start is called before the first frame update    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveY(14, 5).OnComplete(() => {
            DOVirtual.DelayedCall(1, GoDown);
        });
    }

    void GoDown() {
        transform.DOMoveY(0.3f, 5).OnComplete(() => {
            DOVirtual.DelayedCall(1, GoUp);
        });
    }

    void GoUp() {
        transform.DOMoveY(14, 5).OnComplete(() => {
            DOVirtual.DelayedCall(1, GoDown);
        });
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")) {
            Target.transform.SetParent(gameObject.transform);
        }
    }
    private void OnCollisionExit(Collision other) {
        if(other.gameObject.CompareTag("Player")) {
            Target.transform.SetParent(null);
        }    
    }
}
