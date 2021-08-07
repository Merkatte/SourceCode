using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Warning_Window : MonoBehaviour
{
    RectTransform rectTransform;
    // Start is called before the first frame update
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        rectTransform.DOAnchorPosY(-10, 0.5f);
        Invoke("deactive", 2);
    }

    void deactive()
    {
        rectTransform.DOAnchorPosY(110, 0.5f);
        Invoke("kill", 1);
    }

    void kill()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
