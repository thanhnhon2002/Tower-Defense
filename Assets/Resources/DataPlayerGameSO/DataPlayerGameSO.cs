using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DataGamePlayer",menuName ="SO/DataGamePlayer")]
public class DataPlayerGameSO : ScriptableObject
{
    [SerializeField] protected List<DataGamePlayer> listDataGamePlayers;
    public DataGamePlayer GetDataGamePlayer(int level)
    {
        if (level >= listDataGamePlayers.Count) return null;
        return this.listDataGamePlayers.Find( i => i._level == level);
    }
}
