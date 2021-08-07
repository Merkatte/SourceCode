using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Guide : MonoBehaviour
{
    public GameObject ObjectG;
    RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = ObjectG.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            ObjectG.SetActive(true);
            rect.DOAnchorPosX(20, 0.5f);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            rect.DOAnchorPosX(-200, 0.5f).OnComplete(() => {
                ObjectG.SetActive(false);
            });
        }
    }
}
