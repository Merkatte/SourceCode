using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Card_BigOne : MonoBehaviour
{

    public GameObject Object;
    public List<Sprite> card_Image = new List<Sprite>();
    Card_Loader card_Loader;
    Mouse_Drag draging_Object;
    RectTransform thisPos;
    RectTransform ImgScale;
    Image image;
    Text infoTxt;
    Text costTxt;
    void Awake()
    {
        card_Loader = Object.GetComponent<Card_Loader>();
        thisPos = GetComponent<RectTransform>();
        draging_Object = transform.parent.gameObject.GetComponent<Mouse_Drag>();
        image = transform.GetChild(0).GetComponent<Image>();
        ImgScale = transform.GetChild(0).GetComponent<RectTransform>();
        infoTxt = transform.GetChild(1).GetComponent<Text>();
        costTxt = transform.GetChild(2).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(draging_Object.mouse_is_clicked)
        {
            switch(draging_Object.card_object.name)
            {
                case "cards1":
                    image.sprite = card_Image[0];
                    ImgScale.sizeDelta = new Vector2(300, 300);
                    transform.GetChild(0).localPosition = new Vector3(0, 70, 0);
                    infoTxt.text = card_Loader.Loaded_Info[3].card_data;
                    costTxt.text = card_Loader.Loaded_Info[3].cost.ToString();
                    if (DOTween.IsTweening(gameObject))
                        DOTween.Pause(gameObject);
                    thisPos.DOAnchorPosX(-300, 0.5f);
                    break;
                case "cards2":
                    image.sprite = card_Image[1];
                    ImgScale.sizeDelta = new Vector2(200, 200);
                    transform.GetChild(0).localPosition = new Vector3(0, 70, 0);
                    infoTxt.text = card_Loader.Loaded_Info[1].card_data;
                    costTxt.text = card_Loader.Loaded_Info[1].cost.ToString();
                    if (DOTween.IsTweening(gameObject))
                        DOTween.Pause(gameObject);
                    thisPos.DOAnchorPosX(-300, 0.5f);
                    break;
                case "cards3":
                    image.sprite = card_Image[2];
                    ImgScale.sizeDelta = new Vector2(300, 300);
                    transform.GetChild(0).localPosition = new Vector3(0, 70, 0);
                    infoTxt.text = card_Loader.Loaded_Info[0].card_data;
                    costTxt.text = card_Loader.Loaded_Info[0].cost.ToString();
                    if (DOTween.IsTweening(gameObject))
                        DOTween.Pause(gameObject);
                    thisPos.DOAnchorPosX(-300, 0.5f);
                    break;
                case "cards4":
                    image.sprite = card_Image[3];
                    ImgScale.sizeDelta = new Vector2(300, 300);
                    transform.GetChild(0).localPosition = new Vector3(0, 70, 0);
                    infoTxt.text = card_Loader.Loaded_Info[5].card_data;
                    costTxt.text = card_Loader.Loaded_Info[5].cost.ToString();
                    if (DOTween.IsTweening(gameObject))
                        DOTween.Pause(gameObject);
                    thisPos.DOAnchorPosX(-300, 0.5f);
                    break;
                case "cards5":
                    image.sprite = card_Image[4];
                    ImgScale.sizeDelta = new Vector2(250, 250);
                    transform.GetChild(0).localPosition = new Vector3(0, 40, 0);
                    infoTxt.text = card_Loader.Loaded_Info[2].card_data;
                    costTxt.text = card_Loader.Loaded_Info[2].cost.ToString();
                    if (DOTween.IsTweening(gameObject))
                        DOTween.Pause(gameObject);
                    thisPos.DOAnchorPosX(-300, 0.5f);
                    break;
                case "cards6":
                    image.sprite = card_Image[5];
                    ImgScale.sizeDelta = new Vector2(300, 300);
                    transform.GetChild(0).localPosition = new Vector3(0, 70, 0);
                    infoTxt.text = card_Loader.Loaded_Info[9].card_data;
                    costTxt.text = card_Loader.Loaded_Info[9].cost.ToString();
                    if (DOTween.IsTweening(gameObject))
                        DOTween.Pause(gameObject);
                    thisPos.DOAnchorPosX(-300, 0.5f);
                    break;
            }
        } else
        {
            thisPos.DOAnchorPosX(250, 0.5f);
        }
    }
}
