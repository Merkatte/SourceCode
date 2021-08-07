using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class intro_script1 : MonoBehaviour
{
    Text txt;
    public GameObject mainLogo;
    public SoundManager soundManager;
    CJU_Logo cju;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
        cju = transform.parent.GetChild(1).gameObject.GetComponent<CJU_Logo>();
        StartCoroutine(intro_on());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator intro_on()
    {
        yield return new WaitForSeconds(1);
        soundManager.playSound("keyboard");
        txt.DOText("본 게임은 청주대학교 \n 캡스톤 디자인용으로 제작되었습니다. \n 본 게임의 저작권은 제작한 학생에게 있음을 알립니다.", 6, true);
        StartCoroutine(effect_off());
    }
    IEnumerator effect_off()
    {
        yield return new WaitForSeconds(7);
        txt.DOFade(0, 0.4f);
        cju.playAni();
    }

    public IEnumerator panel_off()
    {
        GameObject intro = transform.parent.gameObject;
        Image image = intro.GetComponent<Image>();
        Color color = image.color;
        while (image.color.a > 0)
        {
            color.a -= 0.01f;
            image.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1);
        mainLogo.SetActive(true);
        intro.SetActive(false);
    }
}
