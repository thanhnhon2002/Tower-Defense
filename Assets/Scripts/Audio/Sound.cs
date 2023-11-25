using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : AdminMonoBehaviour
{
    [Serializable]
    enum SoundCategory
    {
        fx =0,
        music =1
    }
    AudioSource audioSource;
    SoundCategory soundCategory;
    protected override void LoadComponent()
    {
        this.audioSource =GetComponent<AudioSource>();
        if(transform.name.Contains("Music")) this.soundCategory = SoundCategory.music;
        else this.soundCategory = SoundCategory.fx;
    }
    void Update()
    {
        if (this.soundCategory == SoundCategory.music) this.audioSource.volume = AudioManager.instance._musicVolume;
        else this.audioSource.volume = AudioManager.instance._fxVolume;
    }
}
