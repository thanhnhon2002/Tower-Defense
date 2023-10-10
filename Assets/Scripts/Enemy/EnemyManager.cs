using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    static public EnemyManager instance;
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
