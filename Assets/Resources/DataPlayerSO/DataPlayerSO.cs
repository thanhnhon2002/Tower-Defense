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

}
