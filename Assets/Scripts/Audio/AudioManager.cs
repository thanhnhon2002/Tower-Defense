using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : AdminMonoBehaviour
{
    static public AudioManager instance;
    public ListPrefab listPrefab;
    public ListPool listPool;
    public ListAudioClips listAudioClips;
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    protected override void LoadComponent()
    {
        this.listPrefab = GetComponentInChildren<ListPrefab>();
        this.listPool = GetComponentInChildren<ListPool>();
        this.listAudioClips = GetComponentInChildren<ListAudioClips>();
    }
}
