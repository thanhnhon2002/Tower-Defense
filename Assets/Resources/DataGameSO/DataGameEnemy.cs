using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class DataGameEnemy
{
    [SerializeField] protected int level;
    public int _level => level;

    [SerializeField] protected List<Round> roundList;
    public List<Round> _roundList => roundList;
    public DataGameEnemy(int level, List<Round> listRound)
    {
        this.level = level;
        this.roundList = listRound;
    }
}
