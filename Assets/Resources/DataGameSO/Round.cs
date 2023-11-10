using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Round
{
    [SerializeField] protected List<EnemyInRound> listEnemyInRound;
    public List<EnemyInRound> _listEnemyInRound => listEnemyInRound;
 
}
