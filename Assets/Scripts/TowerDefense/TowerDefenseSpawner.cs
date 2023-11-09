using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerDefenseSpawner : SpawnObject
{
    static public TowerDefenseSpawner instance;

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    
}
