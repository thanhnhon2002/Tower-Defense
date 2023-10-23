using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataObjectSpawn : Data
{
    protected Transform spawner;
    public Transform _spawner => spawner;
    protected new string name;
    public void SetSpawner(Transform spawner)
    {
        this.spawner = spawner;
    }
}
