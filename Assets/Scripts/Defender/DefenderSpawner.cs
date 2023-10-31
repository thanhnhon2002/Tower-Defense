using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : SpawnObject
{
    static public DefenderSpawner instance;

    protected override void Awake()
    {
        base.Awake();
        instance = this;

    }
    public override Transform Spawn(string name, Vector3 pos, Quaternion rotation)
    {
        return base.Spawn(name, pos, rotation);
    }
    public Transform Spawn(string name, Vector3 pos, Quaternion rotation, Vector3 createPos)
    {
        Transform newObj =  this.Spawn(name, pos, rotation);
        DefenderMoverment moverment = newObj.GetComponentInChildren<DefenderMoverment>();
        moverment.SetCreatePos(createPos);
        return newObj;
    }
    
}
