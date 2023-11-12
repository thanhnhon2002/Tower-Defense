using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : AdminMonoBehaviour
{
    public static MapManager instance;
    public Transform tBackGround;
    public Collider2D pathMapCollider;
    public Collider2D mapCollider;
    public GameObject warnningEnemySpawn;
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    protected override void LoadComponent()
    { 
        this.tBackGround = transform.Find("BackGround");
        this.pathMapCollider = transform.Find("Colliderpath").GetComponent<Collider2D>();
        this.mapCollider = transform.Find("BackGround").GetComponent<Collider2D>();
        this.warnningEnemySpawn = transform.Find("WarnningEnemySpawn").gameObject;
    }
    public void SetWarnningEnemySpawn(bool bl)
    {
        this.warnningEnemySpawn.gameObject.SetActive(bl);
    }
}
