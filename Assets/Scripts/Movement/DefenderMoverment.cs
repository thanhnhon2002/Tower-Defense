using System.Collections;
using UnityEngine;
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
    public void SetSpawnPoint(Transform spawnPoint)
    {
        this.spawnPoint = spawnPoint;
    }
    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.colliderPath = MapManager.instance.pathMapCollider;
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
        Vector3 randomPos = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
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
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, pos, this.runSpeed * Time.deltaTime);
    }
}
