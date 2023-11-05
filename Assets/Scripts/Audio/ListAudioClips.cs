using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListAudioClips : MonoBehaviour
{
    [SerializeField] protected List<AudioClip> listAudioClips;

    public AudioClip getPrefab(string name)
    {
        return this.listAudioClips.Find((i) => i.name == name);
    }
    public AudioClip getPrefab(int index)
    {
        return this.listAudioClips[index];
    }
    public int getCoutListPrafab()
    {
        return this.listAudioClips.Count;
    }
}
