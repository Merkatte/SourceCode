using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Outro_Panel : MonoBehaviour
{
    Image image;
    public SoundManager soundManager;
    SpriteRenderer spriteRender;
    RectTransform rectTransform;
    public GameObject intro;
    public GameObject HQ;
    HeadQuarter_Movement hqScript;
    RectTransform thisTransform;
    Color color;
    // Start is called before the first frame update
    void Awake()
    {
        image = GetComponent<Image>();
        rectTransform = transform.GetChild(0).GetComponent<RectTransform>();
        thisTransform = GetComponent<RectTransform>();
        hqScript = HQ.GetComponent<HeadQuarter_Movement>();
        spriteRender = HQ.GetComponent<SpriteRenderer>();
        color = image.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        thisTransform.SetAsLastSibling();
        rectTransform.anchoredPosition = new Vector2(0, -750);
        StartCoroutine(Fade_In());
        transform.GetChild(0).gameObject.SetActive(true);
    }

    IEnumerator Fade_In()
    {

        while (image.color.a < 1)
        {
            color.a += 0.01f;
            image.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(2f);
        rectTransform.DOAnchorPosY(900, 8);
    }

    public void Restart()
    {
        soundManager.playSound("button");
        StartCoroutine(Backto_Menu());
    }

    IEnumerator Backto_Menu()
    {
        hqScript.doOnlyOnce = 1;
        hqScript.health = 1000;
        spriteRender.sprite = hqScript.hq_Image[0];
        transform.GetChild(0).gameObject.SetActive(false);
        while(color.a > 0)
        {
            color.a -= 0.01f;
            image.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1);
        intro.SetActive(true);
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }

    public void Close()
    {
        soundManager.playSound("button");
        Application.Quit();
    }
}
