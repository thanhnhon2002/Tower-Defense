using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEngine;

public class MoveFollowEnemyPath : BaseMovement
{
    private Coroutine myCoroutine;
    [SerializeField] protected List<Vector3> path = new List<Vector3>();
    [SerializeField] protected int currentIndex;
    [SerializeField] protected Enemy enemy;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.enemy = this.transform.parent.GetComponent<Enemy>();
    }
   
    public void SetPath(List<Vector3> path)
    {
        this.path = path;
        this.currentIndex=0;
    }
    IEnumerator MoveWithPath()
    {
        
        while (this.currentIndex != this.path.Count - 1)
        {
            if (this.transform.parent.position!=this.path[this.currentIndex + 1]) 
                this.transform.parent.position = Vector3.MoveTowards(this.transform.parent.position, this.path[this.currentIndex + 1], this.enemy.dataEnemy._runSpeed * Time.fixedDeltaTime);
            else this.currentIndex++;
            yield return null;
        }
        EnemyManager.instance.listPool.PushToPool(this.transform.parent);
        myCoroutine = null;
    }
    protected override void Move()
    {
        myCoroutine = StartCoroutine(MoveWithPath());
    }
    protected void Start()
    {
       this.Move();
    }
    protected void OnEnable()
    {
        if(this.myCoroutine!=null) this.Move();
    }
}
