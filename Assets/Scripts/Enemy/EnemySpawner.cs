using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : SpawnObject
{
    public override Transform Spawn(string name, Vector3 pos, Quaternion rotation)
    {
        List<Vector3> path = ListEnemyPath.instance.GetRandomEnemyPath();
        Transform newEnemy = base.Spawn(name, path[0], Quaternion.identity);
        EnemyCtrl enemyCtrl = newEnemy.GetComponent<EnemyCtrl>();
       
        enemyCtrl.moveFollowEnemyPath.SetPath(path);
        enemyCtrl.moveFollowEnemyPath.StartMove();
        return newEnemy;
       
    }
}
