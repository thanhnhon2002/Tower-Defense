using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="DataPlayerSO",menuName ="SO/DataPlayerSO")]
public class DataPlayerSO : ScriptableObject
{
    [SerializeField] int level;
    public int _level => level;
    public void UnLockLevel(int level)
    {
        if(this.level < level) this.level = level;
    }
    [SerializeField] float volumeMusic=1;
    public float _volumeMusic => volumeMusic;
    [SerializeField] float volumeFXSound=1;
    public float _volumeFXSound => volumeFXSound;
    public void SetVolume(float music,float fx)
    {
        this.volumeMusic = music;
        this.volumeFXSound = fx;
    }
}
