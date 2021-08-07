using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> sfx_list = new List<AudioClip>();
    public List<GameObject> Channel = new List<GameObject>();
    public List<AudioClip> BGM = new List<AudioClip>();
    AudioSource audioSource;
    AudioSource BGMSource;
    ParticleSystem particle;
    int nextChannel;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound(string soundName)
    {
        switch(soundName)
        {
            case "keyboard":
                audioSource = Channel[nextChannel].GetComponent<AudioSource>();
                audioSource.clip = sfx_list[0];
                audioSource.Play();
                nextChannel++;
                break;
            case "cju_logo":
                audioSource = Channel[nextChannel].GetComponent<AudioSource>();
                audioSource.clip = sfx_list[1];
                audioSource.Play();
                nextChannel++;
                break;
            case "Start":
                audioSource = Channel[nextChannel].GetComponent<AudioSource>();
                audioSource.clip = sfx_list[2];
                audioSource.Play();
                nextChannel++;
                break;
            case "ESC":
                audioSource = Channel[nextChannel].GetComponent<AudioSource>();
                audioSource.clip = sfx_list[3];
                audioSource.Play();
                nextChannel++;
                break;
            case "button":
                audioSource = Channel[nextChannel].GetComponent<AudioSource>();
                audioSource.clip = sfx_list[4];
                audioSource.Play();
                nextChannel++;
                break;
            case "Shuffle":
                audioSource = Channel[nextChannel].GetComponent<AudioSource>();
                audioSource.clip = sfx_list[5];
                audioSource.Play();
                nextChannel++;
                break;
            case "Card_Pick":
                audioSource = Channel[nextChannel].GetComponent<AudioSource>();
                audioSource.clip = sfx_list[6];
                audioSource.Play();
                nextChannel++;
                break;
            case "Card_Put":
                audioSource = Channel[nextChannel].GetComponent<AudioSource>();
                audioSource.clip = sfx_list[7];
                audioSource.Play();
                nextChannel++;
                break;
            case "Power_Up":
                audioSource = Channel[nextChannel].GetComponent<AudioSource>();
                audioSource.clip = sfx_list[8];
                audioSource.Play();
                nextChannel++;
                break;
            case "Nor_Attack":
                audioSource = Channel[nextChannel].GetComponent<AudioSource>();
                int rnd = Random.Range(9, 11);
                audioSource.clip = sfx_list[rnd];
                audioSource.Play();
                nextChannel++;
                break;
            case "Gunner_Attack":
                audioSource = Channel[nextChannel].GetComponent<AudioSource>();
                audioSource.clip = sfx_list[11];
                audioSource.Play();
                nextChannel++;
                break;
            case "Coin":
                audioSource = Channel[nextChannel].GetComponent<AudioSource>();
                int rnd2 = Random.Range(13, 20);
                audioSource.clip = sfx_list[rnd2];
                audioSource.Play();
                nextChannel++;
                break;
            case "chainsaw":
                audioSource = Channel[nextChannel].GetComponent<AudioSource>();
                audioSource.clip = sfx_list[20];
                audioSource.Play();
                nextChannel++;
                break;
            case "roundStart":
                audioSource = Channel[nextChannel].GetComponent<AudioSource>();
                audioSource.clip = sfx_list[21];
                audioSource.Play();
                nextChannel++;
                break;
            case "HQ_Explode":
                audioSource = Channel[nextChannel].GetComponent<AudioSource>();
                audioSource.clip = sfx_list[22];
                audioSource.Play();
                nextChannel++;
                break;
            case "reload":
                audioSource = Channel[nextChannel].GetComponent<AudioSource>();
                audioSource.clip = sfx_list[23];
                audioSource.Play();
                nextChannel++;
                break;


        }
        if (nextChannel > 4)
            nextChannel = 0;
    }

    IEnumerable SetTimeDefault(AudioSource audioSource)
    {
        yield return new WaitForSeconds(6.1f);
        
    }

    public void playBGM(string soundName)
    {
        switch(soundName)
        {
            case "Intro":
                BGMSource = Channel[5].GetComponent<AudioSource>();
                BGMSource.clip = BGM[0];
                BGMSource.volume = 0.7f;
                BGMSource.Play();
                break;
            case "InGame":
                BGMSource = Channel[5].GetComponent<AudioSource>();
                StartCoroutine(volumeDown());
                break;
            case "GameOver":
                BGMSource = Channel[5].GetComponent<AudioSource>();
                StartCoroutine(volumeDown());
                break;

        }
    }

    IEnumerator volumeDown()
    {
        while (BGMSource.volume > 0)
        {
            BGMSource.volume -= 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(2);
        if (BGMSource.clip == BGM[0])
        {
            BGMSource.clip = BGM[1];
            BGMSource.loop = true;
            BGMSource.Play();
        } else if(BGMSource.clip == BGM[1])
        {
            BGMSource.clip = BGM[2];
            BGMSource.volume = 1;
            BGMSource.loop = false;
            BGMSource.Play();
            StopCoroutine(volumeDown());
        }
        while (BGMSource.volume < 0.4f)
        {
            BGMSource.volume += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
