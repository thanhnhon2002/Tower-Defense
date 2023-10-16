using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : SpawnObject
{
    static public EnemySpawner instance;
 
    protected override void Awake()
    {
        base.Awake();
        instance = this;

    }
    public override Transform Spawn(string name, Vector3 pos, Quaternion rotation)
    {
        List<Vector3> path = ListEnemyPath.instance.GetRandomEnemyPath();
        Transform newEnemy = base.Spawn(name, path[0], Quaternion.identity);
        Enemy enemyCtrl = newEnemy.GetComponent<Enemy>();
       
        enemyCtrl.moveFollowEnemyPath.SetPath(path);
        enemyCtrl.moveFollowEnemyPath.StartMove();
        return newEnemy;
       
    }
}
