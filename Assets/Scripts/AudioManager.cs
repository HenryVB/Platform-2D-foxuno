using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    [SerializeField]
    private AudioSource[] soundEffects;

    [Header("Background Music")]
    [SerializeField]
    private AudioSource bgm;

    [Header("End level Music")]
    [SerializeField]
    private AudioSource lvlEnd;

    [Header("Boss Music")]
    [SerializeField]
    private AudioSource bossMusic;


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(int indexAudioToPlay)
    {
        soundEffects[indexAudioToPlay].Stop();
        soundEffects[indexAudioToPlay].pitch = Random.Range(0.9f,1.1f);
        soundEffects[indexAudioToPlay].Play();
    }

    public void PlayLevelVictory()
    {
        bgm.Stop();
        lvlEnd.Play();
    }

    public void PlayBossMusic()
    {
        bgm.Stop();
        bossMusic.Play();
    }

    public void StopBossMusic()
    {
        bossMusic.Stop();
        bgm.Play();
    }

}
