using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public AudioSource audioSrcMain, audioSrcMinigame;
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
    public void PlayMusic(string clip)
    {
        switch (clip)
        {
            case "musicMain":
                audioSrcMain.Play();
                audioSrcMinigame.Stop();
                break;
            case "musicMinigame":
                audioSrcMinigame.Play(); 
                audioSrcMain.Stop();
                break;
            default: break;
        }
    }
}
