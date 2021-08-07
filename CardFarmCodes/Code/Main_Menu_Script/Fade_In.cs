using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fade_In : MonoBehaviour
{
    Image image;
    Color color;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        color = GetComponent<Color>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnEnable()
    {
    }
}
