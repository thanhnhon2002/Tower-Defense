using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public DataEnemy dataEnemy;
    public MoveFollowEnemyPath moveFollowEnemyPath;
    
    private void Awake()
    {
        this.LoadComponent();
    }
    protected void LoadComponent()
    {
        this.moveFollowEnemyPath = this.transform.GetComponentInChildren<MoveFollowEnemyPath>();
        this.dataEnemy = this.transform.GetComponentInChildren<DataEnemy>();
    }
}
