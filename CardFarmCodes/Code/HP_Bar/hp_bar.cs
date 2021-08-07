using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp_bar : MonoBehaviour
{
    public int object_hp;
    bool calculate = false;
    int total_hp;
    int callOnlyone = 0;
    Image image;
    // Start is called before the first frame update
    void Awake()
    {
        image = GetComponent<Image>();
    }

    private void OnDisable()
    {
        calculate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (calculate == true)
        {
            float percent = (float)object_hp / (float)total_hp;
            image.fillAmount = percent;
        }
    }

    public void GetHeroHP(int hp)
    {
        object_hp = hp;
        if (callOnlyone == 0)
        {
            total_hp = object_hp;
            callOnlyone++;
        }
        calculate = true;
    }

}
