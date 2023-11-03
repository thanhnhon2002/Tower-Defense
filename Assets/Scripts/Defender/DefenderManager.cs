using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderManager : AdminMonoBehaviour
{
    public static DefenderManager instance;
    public ListPrefab listPrefab;
    public ListPool listPool;
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
   
    protected override void LoadComponent()
    {
        this.listPrefab = GetComponentInChildren<ListPrefab>();
        this.listPool = GetComponentInChildren<ListPool>();
    }

}
