using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp_UI : MonoBehaviour
{
    Camera Camera_Object;
    Canvas canvas;

    private void Awake()
    {
        Camera_Object = GameObject.Find("Camera").GetComponent<Camera>();
        canvas = gameObject.GetComponent<Canvas>();
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        canvas.worldCamera = Camera_Object;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
