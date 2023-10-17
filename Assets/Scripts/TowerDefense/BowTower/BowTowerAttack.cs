using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BowTowerAttack : TowerAttack
{
    public Transform spawnPoint;
    protected override void Attack()
    {
        Vector3 distance= this.target.transform.position - transform.parent.position;
        
        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Transform newBullet = BulletSpawner.instance.Spawn("Arrow",this.spawnPoint.position,rotation);
        DataBullet dataBullet = newBullet.GetComponentInChildren<DataBullet>();
        dataBullet.RecieveInfor(this.transform.parent, this.target, this.towerdefense.data._atk, this.towerdefense.data._category);
    }
    private void OnDrawGizmos()
    {
        if(this.target!=null&&this.target.gameObject.activeSelf)
        Gizmos.DrawLine(this.transform.parent.position, this.target.position);
    }
}
