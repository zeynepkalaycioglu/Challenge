using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    
    public enum SoundTypes {Crash, Collect, Congratz, Lose};
    public enum BgMusicTypes {MainBgMusic};
    
    public AudioSource crashSound;
    public AudioSource collectSound;
    public AudioSource congratzSound;
    public AudioSource loseSound;
    
    public AudioSource bgMusic;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    
    public void PlayBgMusic(BgMusicTypes currentMusic)
    {
        switch (currentMusic)
        {
            case BgMusicTypes.MainBgMusic:
                bgMusic.Play();
                bgMusic.volume = 0.1f;
                break;
        }
    }

    public void PlaySound(SoundTypes currentSound)
    {
        switch (currentSound)
        {
            case SoundTypes.Crash:
                crashSound.Play();
                break;
            case SoundTypes.Collect:
                collectSound.Play();
                break;
            case SoundTypes.Congratz:
                congratzSound.Play();
                break;
            case SoundTypes.Lose:
                congratzSound.Play();
                break;
        }
    }
}
