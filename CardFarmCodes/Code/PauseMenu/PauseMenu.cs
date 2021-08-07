using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Enable()
    {
        transform.DOLocalMoveY(0, (float)0.5).SetUpdate(true);
    }

    public void Ani_Enable()
    {
        transform.DOLocalMoveY(-850, (float)0.5).SetUpdate(true);
        StartCoroutine(resume()); 
    }
    IEnumerator resume()
    {
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1;
        transform.parent.gameObject.SetActive(false);
    }


}
