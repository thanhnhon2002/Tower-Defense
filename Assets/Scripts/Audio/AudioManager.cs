using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AudioManager : AdminMonoBehaviour
{
    static public AudioManager instance;
    public ListPrefab listPrefab;
    public ListPool listPool;
    public ListAudioClips listAudioClips;
    public ListAudioClips listMusics;
    [SerializeField] AudioSource musicGame;

    [SerializeField] float musicVolume=1;
    public float _musicVolume =>this.musicVolume;
    float fxVolume = 1;
    public float _fxVolume =>this.fxVolume;
    DataPlayerSO dataPlayerSO;
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    protected override void LoadComponent()
    {
        this.listPrefab = GetComponentInChildren<ListPrefab>();
        this.listPool = GetComponentInChildren<ListPool>();
        this.listAudioClips = transform.Find("ListAudioClips").GetComponent<ListAudioClips>();
        this.listMusics = transform.Find("ListMusics").GetComponent<ListAudioClips>();
        this.musicGame = transform.Find("MusicGame").GetComponent<AudioSource>();
        this.dataPlayerSO = Resources.Load<DataPlayerSO>("DataPlayerSO/DataPlayer");
        this.musicVolume = this.dataPlayerSO._volumeMusic;
        this.fxVolume = this.dataPlayerSO._volumeFXSound;
    }
    private void Start()
    {
        this.PlayMusic();
    }
    void PlayMusic()
    {
        this.musicGame.clip = this.listMusics.getPrefab(GameManager.instance._level);
        this.musicGame.Play();
    }
    public void SetMusicVolume(float volume)
    {
        this.musicVolume = volume;
    }
    public void SetFXVolume(float volume)
    {
        this.fxVolume = volume;
    }
}
