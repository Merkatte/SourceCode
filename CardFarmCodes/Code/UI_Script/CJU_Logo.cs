using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CJU_Logo : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform rectTransform;
    intro_script1 introScript;
    public SoundManager soundManager;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        introScript = transform.parent.GetChild(0).GetComponent<intro_script1>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playAni()
    {
        StartCoroutine(effect());
    }
    IEnumerator effect()
    {
        yield return new WaitForSeconds(1f);
        rectTransform.DOSizeDelta(new Vector2(300, 300), 0.5f).SetEase(Ease.OutBounce);
        soundManager.playSound("cju_logo");
        yield return new WaitForSeconds(1.5f);
        rectTransform.DOSizeDelta(new Vector2(0, 0), 0.5f).SetEase(Ease.InBounce);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(introScript.panel_off());
    }
}
