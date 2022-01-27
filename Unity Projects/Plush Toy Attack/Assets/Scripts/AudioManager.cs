using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AudioManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioSource music1Source;
    [SerializeField] private string levelBGMusic;
    private float _musicVolume;
    public float musicVolume
    {
        get
        {
            return _musicVolume;
        }
        set
        {
            _musicVolume = value;
            if (music1Source != null)
            {
                music1Source.volume = _musicVolume;
            }
        }
    }
    public bool musicMute
    {
        get
        {
            if (music1Source != null)
            {
                return music1Source.mute;
            }
            return false;
        }
        set
        {
            if (music1Source != null)
            {
                music1Source.mute = value;
            }
        }
    }
    public void PlayLevelMusic()
    {
        PlayMusic(Resources.Load("Music/" + levelBGMusic) as AudioClip);
    }
    private void PlayMusic(AudioClip clip)
    {
        music1Source.clip = clip;
        music1Source.Play();
    }
    public void StopMusic()
    {
        music1Source.Stop();
    }
    public float soundVolume
    {
        get { return AudioListener.volume; }
        set { AudioListener.volume = value; }
    }
    public bool soundMute
    {
        get { return AudioListener.pause; }
        set { AudioListener.pause = value; }
    }
    public void Startup()
    {
        Debug.Log("Audio manager starting...");
        music1Source.ignoreListenerVolume = true;
        music1Source.ignoreListenerPause = true;
        soundVolume = 1f;
        musicVolume = 1f;
        status = ManagerStatus.Started;
    }
    public void PlaySound(AudioClip clip)
    {
        soundSource.PlayOneShot(clip);
    }

}
