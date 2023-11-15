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
}
