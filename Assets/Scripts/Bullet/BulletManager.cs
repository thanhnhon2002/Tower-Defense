using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    static public BulletManager instance;
    public ListPrefab listPrefab;
    public ListPool listPool;
    private void Awake()
    {
        
        this.LoadComponent();
        instance = this;
    }
    void LoadComponent()
    {
        this.listPrefab = GetComponentInChildren<ListPrefab>();
        this.listPool = GetComponentInChildren<ListPool>();
    }
}
