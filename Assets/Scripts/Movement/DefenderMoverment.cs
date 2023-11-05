using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class DefenderMoverment : BaseMovement
{
    [SerializeField] protected DataDefender dataDefender;
    [SerializeField] protected Vector3 createPos;
    [SerializeField] protected Transform spawnPoint;
    [SerializeField] protected Collider2D colliderPath;
    [SerializeField] protected Animator animator;
    [SerializeField] protected DefenderAttack attack;
    public void SetCreatePos(Vector3 newPos)
    {
        this.createPos = newPos;
    }
    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.dataDefender = transform.parent.GetComponentInChildren<DataDefender>();
        this.animator = transform.parent.GetComponentInChildren<Animator>();
        this.attack = transform.parent.GetComponentInChildren<DefenderAttack>();
     
    }
    protected override void LoadData()
    {
        base.LoadData();
        this.runSpeed = this.dataDefender._runSpeed;
    }
    protected void OnEnable()
    {
        this.spawnPoint = this.dataDefender._spawner.GetComponent<TowerSpawnDefender>().tSpawnPoint;
        StartCoroutine(MoveWhenCreate());
   
    }
    protected override void Move()
    {
        StartCoroutine(MoveRandom());
    }
    IEnumerator MoveToPos( Vector3 pos)
    {   
        while (this.transform.parent.position != pos)
        {
            this.MoveTowardsPos(pos);
            if (this.attack._isAttack) break;
            yield return null;
        }
    }
    IEnumerator MoveWhenCreate()
    {
        while (this.transform.parent.position != this.createPos)
        {
            this.MoveTowardsPos(this.createPos);    
            yield return null;
        }
        this.animator.transform.localScale = new Vector3(1, 1, 0);
        this.Move();
    }
    IEnumerator MoveRandom()
    {
        while (true)
        {
            if (!this.attack._isAttack)
            {
                yield return new WaitForSeconds(3);
                if (this.attack._isAttack) goto jump;
                Vector3 newPos = RandomPos();
                yield return StartCoroutine(MoveToPos(newPos));
                yield return null;
                jump:
                this.animator.transform.localScale = new Vector3(1, 1, 0);
            }
            yield return null;
        }
    }
    Vector3 RandomPos()
    {
        float x = Random.Range(-5f, 5f); 
        float y =Random.Range(-5f, 5f);
        Vector3 randomPos = new Vector3(x, y, 0);
        Vector3 newPos = randomPos + this.spawnPoint.position;
        //Vector3 newPos = randomPos + this.transform.position;
        if (Vector3.Distance(newPos, this.colliderPath.ClosestPoint(newPos)) > 0.05f) return RandomPos();
        return newPos;
    }
    void MoveTowardsPos(Vector3 pos)
    {
        Vector3 distance = pos - transform.parent.position;
        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        if (angle < 90 && angle > -90) this.animator.transform.localScale = new Vector3(1, 1, 0);
        else this.animator.transform.localScale = new Vector3(-1, 1, 0);
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, pos, this.runSpeed * Time.fixedDeltaTime);
    }
}
