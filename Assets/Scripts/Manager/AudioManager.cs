using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//…˘“Ùπ‹¿Ì∆˜
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource bgmSource;//±≥æ∞“Ù¿÷µƒ“Ù‘¥

    private void Awake()
    {
        Instance = this;
    }

    public void Init()
    {
        //’“µΩ±≥æ∞“Ù¿÷µƒ“Ù‘¥
        bgmSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayBGM(string name,bool isLoop = true)
    {
        //º”‘ÿ“Ù¿÷
        AudioClip clip = Resources.Load<AudioClip>("Sounds/BGM/" + name);
        //≤•∑≈“Ù¿÷
        bgmSource.clip = clip;
        bgmSource.loop = isLoop;
        bgmSource.Play();
    }

    //“Ù–ß
    public void PlayEffect(string name)
    {
        //º”‘ÿ“Ù¿÷
        AudioClip clip = Resources.Load<AudioClip>("Sounds/Effect/" + name);
        AudioSource.PlayClipAtPoint(clip, transform.position);//≤•∑≈
    }
}
