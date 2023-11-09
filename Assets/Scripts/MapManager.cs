using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : AdminMonoBehaviour
{
    public static MapManager instance;
    public Transform tBackGround;
    public Collider2D mapCollider;
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    protected override void LoadComponent()
    { 
        this.tBackGround = transform.Find("BackGround");
        this.mapCollider = transform.GetComponentInChildren<Collider2D>();
    }
}
