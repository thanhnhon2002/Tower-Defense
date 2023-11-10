using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class DataGamePlayer
{
    [SerializeField] protected int level;
    public int _level => level;
    public void SetLevel(int level) => this.level = level;
    [SerializeField] protected int gold;
    public int _gold => gold;
    public void SetGold(int gold) => this.gold = gold;

    [SerializeField] protected int heal;
    public int _heal => heal;
    public void SetHeal(int heal) => this.heal = heal;
    public DataGamePlayer(int level, int gold, int heal)
    {
        this.level = level;
        this.gold = gold;
        this.heal = heal;
    }
}
