using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DataGameSO",menuName ="SO/DataGameSO")]
public class DataGameSO : ScriptableObject
{
    [SerializeField] protected List<DataGamePlayer> listDataGamePlayers;
    public DataGamePlayer GetDataGamePlayer(int level)
    {
        if (level > listDataGamePlayers.Count) return null;
        return this.listDataGamePlayers.Find( i => i._level == level);
    }
    [SerializeField] protected List<DataGameEnemy> listDataGameEnemys;
    public DataGameEnemy GetDataGameEnemy(int level)
    {
        if (level > listDataGameEnemys.Count) return null;
        return this.listDataGameEnemys.Find(i => i._level == level);
    }
}
