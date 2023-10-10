using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public MoveFollowEnemyPath moveFollowEnemyPath;
    public AttributeEnemy attributeEnemy;
    private void Awake()
    {
        this.LoadComponent();
    }
    protected void LoadComponent()
    {
        this.moveFollowEnemyPath = this.transform.GetComponentInChildren<MoveFollowEnemyPath>();
        this.attributeEnemy = this.transform.GetComponentInChildren<AttributeEnemy>();
    }
}
