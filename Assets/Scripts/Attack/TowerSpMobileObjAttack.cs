using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpMobileObjAttack : TowerAttack
{   
    [SerializeField] protected Transform target;
    public Transform _target => this.target;

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
    protected override void LoadComponent()
    {
        this.towerDefense = transform.parent.GetComponent<TowerSpawnMobileObject>();
        base.LoadComponent();
    }
    protected IEnumerator CheckTarget()
    {
        while (true)
        {
            if (this.target!=null) if (!this.target.gameObject.activeSelf) this.target = null;
            if (isAttack&& this.target != null)
            {
                this.Attack();
                yield return new WaitForSeconds(this.dataTower._atkSpeed);
            }
            yield return null;
        }
    }
    protected override void Attack()
    {
        Vector3 distance = this.target.transform.position - transform.parent.position;

        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Transform newBullet = BulletSpawner.instance.Spawn(this.objectSpawn.name,this.spawnPoint.position, rotation);
        DataMobileObject dataBullet = newBullet.GetComponentInChildren<DataMobileObject>();
        dataBullet.SetData(this.transform.parent, this.target, this.dataTower._atk, this.dataTower._category);
        switch (transform.parent.name)
        {
            case "BowTower":
                AudioSpawner.instance.Spawn("Ranged1", transform.parent.position, Quaternion.identity);
                break;
            case "CannonTower":
                AudioSpawner.instance.Spawn("Shot1", transform.parent.position, Quaternion.identity);
                break;
            case "WitchTower":
                AudioSpawner.instance.Spawn("Magic1", transform.parent.position, Quaternion.identity);
                break;
        }

    }
    private void OnDrawGizmos()
    {
        if (this.target != null && this.target.gameObject.activeSelf)
            Gizmos.DrawLine(this.transform.parent.position, this.target.position);
    }

    protected void Start()
    {
        StartCoroutine("CheckTarget");
    }

}
