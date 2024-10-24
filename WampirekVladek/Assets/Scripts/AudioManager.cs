using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip blood, button, buy, chomp, clothes, coin, gameover, hit, petting, sleep;

    [HideInInspector] public AudioSource audioSrc;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(Instance.gameObject);
            Instance = this;
        }
    }
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "blood":
                audioSrc.PlayOneShot(blood);
                break;
            case "button":
                audioSrc.PlayOneShot(button);
                break;
            case "buy":
                audioSrc.PlayOneShot(buy); 
                break;
            case "chomp":
                audioSrc.PlayOneShot(chomp);
                break;
            case "clothes":
                audioSrc.PlayOneShot(clothes); 
                break;
            case "coin":
                audioSrc.PlayOneShot(coin);
                break;
            case "gameover":
                audioSrc.PlayOneShot(gameover);
                break;
            case "hit":
                audioSrc.PlayOneShot(hit);
                break;
            case "petting":
                audioSrc.PlayOneShot(petting); /// to do
                break;
            case "sleep":
                audioSrc.PlayOneShot(sleep);
                break;
            default: break;
        }
    }
}
