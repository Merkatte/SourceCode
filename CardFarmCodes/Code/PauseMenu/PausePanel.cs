using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    PauseMenu pauseMenu;
    RectTransform rectTransform;
    // Start is called before the first frame update
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        Debug.Log("Ȱ��ȭ��");
        rectTransform.SetAsLastSibling();
        pauseMenu = transform.GetChild(0).gameObject.GetComponent<PauseMenu>();
        pauseMenu.Enable();
    }
}
