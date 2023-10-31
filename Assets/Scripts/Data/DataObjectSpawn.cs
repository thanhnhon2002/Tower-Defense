using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataObjectSpawn : AdminMonoBehaviour
{
    [SerializeField] protected Transform spawner;
    public Transform _spawner => spawner;
    public void SetSpawner(Transform spawner)
    {
        this.spawner = spawner;
    }
}
