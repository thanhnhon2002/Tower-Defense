using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : AdminMonoBehaviour
{
    static public EnemyManager instance;
    public Transform tClone;
    public ListPrefab listPrefab;
    public ListPool listPool;
    protected override void Awake()
    {
        
        base.Awake();
        instance = this;
    }
    protected override void LoadComponent()
    {
        this.tClone = transform.Find("ListClone");
        this.listPrefab = GetComponentInChildren<ListPrefab>();
        this.listPool = GetComponentInChildren<ListPool>();
    }
    public bool IsHaveEnemy() { return this.tClone.childCount == 0 ? false : true; }
  
}
