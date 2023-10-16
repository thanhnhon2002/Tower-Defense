using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : SpawnObject
{
    static public BulletSpawner instance;

    protected override void Awake()
    {
        base.Awake();
        instance = this;

    }
    public override Transform Spawn(string name, Vector3 pos, Quaternion rotation)
    {
        return base.Spawn(name, pos, rotation);
    }
}
