using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowTowerAttack : TowerAttack
{
    protected override void Attack()
    {
        BulletSpawner.instance.Spawn("Arrow", transform.parent.position + new Vector3(0, 1, 0), Quaternion.identity);
    }
}
