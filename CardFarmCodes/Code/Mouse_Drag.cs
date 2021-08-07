using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mouse_Drag : MonoBehaviour
{
    Vector2 MousePosition;
    Camera Camera;
    GraphicRaycaster gr;
    PointerEventData eventData;
    public GameObject card_object;
    public bool mouse_is_clicked;

    private void Awake()
    {
        gr = GetComponent<GraphicRaycaster>();
        eventData = new PointerEventData(null);
        Camera = GameObject.Find("Camera").GetComponent<Camera>();
    
    }

    private void Update()
    {
        eventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        if(Input.GetMouseButton(0)) {
            gr.Raycast(eventData, results);

            if (results.Count > 0)
            {
                card_object = results[0].gameObject;
                mouse_is_clicked = true;
            }
        } else
        {
            mouse_is_clicked = false;
        }
    }
}