using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class EnemyInRound 
{
    [SerializeField] protected Enemy enemy;
    public Enemy _enemy => enemy;

    [SerializeField] protected int countEnemy;
    public int _countEnemy=>countEnemy; 
}
