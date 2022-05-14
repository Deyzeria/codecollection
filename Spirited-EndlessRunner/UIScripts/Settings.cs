using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public static Settings Instance;
    public float musicVolume = 1;
    public float soundVolume = 1;
    public Slider musicSlider;
    public Slider soundSlider;
    public AudioSource Music;
    public AudioSource Sound;
    public AudioSource Jump;

    public AudioClip Menu, Forest, Factory;

    byte trackNumber;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
        Sound.enabled = false;
        Jump.enabled = false;
    }

    public void TurnOnSound()
    {
        Sound.enabled = true;
    }

    public void SoundJump()
    {
        Jump.Play(0);
    }

    private IEnumerator SwitchToTrack()
    {
        bool killthemusic = true;
        while (killthemusic)
        {
            yield return new WaitForSeconds(0.2f);
            Music.volume -= 0.13f;
            if (Music.volume < 0.1f)
            {
                killthemusic = false;
            }
        }

        if (trackNumber == 1)
        {
            Music.clip = Forest;
        }
        else if (trackNumber == 2)
        {
            Music.clip = Factory;
        }
        else
        {
            Music.clip = Menu;
        }
        Music.volume = musicVolume;
        Music.Play();
    }

    public void ChangeMusic()
    {
        musicVolume = musicSlider.GetComponent<Slider>().value;
        Music.volume = musicVolume;
    }

    public void ChangeSound()
    {
        soundVolume = soundSlider.GetComponent<Slider>().value;
        Sound.volume = soundVolume;
        Jump.volume = soundVolume;
    }

    public void ChangeMusicClip(byte number)
    {
        trackNumber = number;
        StartCoroutine("SwitchToTrack");
    }

   
}
