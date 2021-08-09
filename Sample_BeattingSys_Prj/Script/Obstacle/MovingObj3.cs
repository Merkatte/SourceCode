using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MovingObj3 : MonoBehaviour
{
    public GameObject Target;
    // Start is called before the first frame update    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveZ(170, 7).OnComplete(() => {
            DOVirtual.DelayedCall(2, GoBack);
        });
    }

    void GoBack() {
        transform.DOMoveZ(143, 7).OnComplete(() => {
            DOVirtual.DelayedCall(2, GoForward);
        });
    }

    void GoForward() {
        transform.DOMoveZ(170, 7).OnComplete(() => {
            DOVirtual.DelayedCall(2, GoBack);
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
