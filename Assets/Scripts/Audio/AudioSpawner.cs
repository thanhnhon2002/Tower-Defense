using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioSpawner : SpawnObject
{
    static public AudioSpawner instance;

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    public override Transform Spawn(string name, Vector3 pos, Quaternion rotation)
    {
        AudioClip aClips = AudioManager.instance.listAudioClips.getPrefab(name);
        Transform newObj = base.Spawn("FXSound", pos, rotation);
        newObj.GetComponent<AudioSource>().clip = aClips;
        newObj.GetComponent<AudioSource>().Play();
        newObj.AddComponent<DestroyByTime>();
        newObj.GetComponent<DestroyByTime>().SetListPool(AudioManager.instance.listPool);
        newObj.GetComponent<DestroyByTime>().SetTimeMax(aClips.length+1f);
        return newObj;
    }
}
