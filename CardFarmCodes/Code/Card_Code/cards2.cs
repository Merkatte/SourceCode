using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
public class cards2 : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    Shuffle shuffled;
    public static Vector2 defaultposition;
    public bool Card_onDrag = false;
    public bool Card_onArea;
    public ObjectManager objectManager;
    public GameObject instant_Card;
    GameObject moving_instant_Card;
    Mouse_Follow_and_Checkobj chkObj;
    tile_act heron_tile;
    Card_Loader card_Loader;
    GameManager gameManager;
    SoundManager soundManager;

    void Awake()
    {
        card_Loader = objectManager.GetComponent<Card_Loader>();
        gameManager = objectManager.GetComponent<GameManager>();
        chkObj = GameObject.Find("Mouse_Collision").GetComponent<Mouse_Follow_and_Checkobj>();
        soundManager = objectManager.GetComponent<SoundManager>();

    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        Card_onDrag = true;
        soundManager.playSound("Card_Pick");
        Vector3 card_pos = Camera.main.WorldToScreenPoint(Input.mousePosition);
        card_pos.z = -2;
        moving_instant_Card = Instantiate(instant_Card, card_pos, transform.rotation);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector3 card_pos = Camera.main.WorldToScreenPoint(Input.mousePosition);
        moving_instant_Card.transform.position = card_pos;
        Time.timeScale = 0.5f;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Time.timeScale = 1;
        Card_onDrag = false;
        if (chkObj.tile_chk == true)
        {
            heron_tile = chkObj.chk_object.GetComponent<tile_act>();
            if (heron_tile.on_tile == false && gameManager.isGoldEnough(card_Loader.Loaded_Info[1].cost))
            {
                soundManager.playSound("Card_Put");
                Vector3 vec = new Vector3(heron_tile.transform.position.x, heron_tile.transform.position.y, -2);
                GameObject instance = objectManager.MakeObj("Corn");
                instance.transform.position = vec - new Vector3(0, 0.33f, 0);
                Destroy(moving_instant_Card);
                shuffled.sendGraveYard(gameObject);
                this.gameObject.SetActive(false);
            }
            else
            {
                Destroy(moving_instant_Card);
            }
        }
        else
        {
            Destroy(moving_instant_Card);

        }
        //카드가 사용 됬으니 어디다가 트루를 반환해서 카드 효과를 구현함

    }

    // Start is called before the first frame update

    void OnEnable()
    {
        shuffled = GameObject.Find("Shuffling").GetComponent<Shuffle>();
        int return_value = shuffled.Cards_Onhand.IndexOf(this.gameObject);
        transform.localPosition = new Vector3((return_value - 2) * 120, -700, 1);
        transform.DOLocalMoveY(-400, (float)0.5);
    }

    void OnDisable()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {




    }
    public void die()
    {
        transform.DOLocalMoveY(-700, (float)0.5);
        Card_onArea = true;
        Invoke("OnDisable", (float)0.6);
    }
    public void Re_Loc()
    {
        int return_value = shuffled.Cards_Onhand.IndexOf(gameObject);
        transform.DOLocalMoveX((return_value - 2) * 120, 0.3f);
    }
}
