using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderMoverment : BaseMovement
{
    [SerializeField] protected DataDefender dataDefender;
    [SerializeField] protected Vector3 createPos;
    [SerializeField] protected Transform spawnPoint;
    [SerializeField] protected Collider2D colliderPath;
    public void SetCreatePos(Vector3 newPos)
    {
        this.createPos = newPos;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.dataDefender = transform.parent.GetComponentInChildren<DataDefender>();
    }
    protected override void LoadData()
    {
        base.LoadData();
        this.runSpeed = this.dataDefender._runSpeed;
    }
    protected void OnEnable()
    {
        StartCoroutine(MoveWhenCreate());
    }
    protected override void Move()
    {

    }
    IEnumerator MoveToPos( Vector3 pos)
    {
        
        while (this.transform.parent.position != pos)
        {
            transform.parent.position = Vector3.MoveTowards(transform.parent.position, pos, this.runSpeed * Time.fixedDeltaTime);
            Debug.Log("move");
            yield return null;
        }
    }
    IEnumerator MoveWhenCreate()
    {

        while (this.transform.parent.position != this.createPos)
        {    
            transform.parent.position = Vector3.MoveTowards(transform.parent.position, this.createPos, this.runSpeed * Time.fixedDeltaTime);

            yield return null;
        }
        StartCoroutine(MoveRandom());
    }
    IEnumerator MoveRandom()
    {
        while (true)
        {
            yield return new WaitForSeconds(6);
            Vector3 newPos = RandomPos();
          
            yield return StartCoroutine(MoveToPos(newPos));
            yield return null;
        }
    }
    Vector3 RandomPos()
    {
        Vector3 randomPos = new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), 0);
        Vector3 newPos = randomPos + this.spawnPoint.position;
        if (Vector3.Distance(newPos, this.colliderPath.ClosestPoint(newPos)) > 0.1f) return RandomPos();
        return newPos;
    }
}
