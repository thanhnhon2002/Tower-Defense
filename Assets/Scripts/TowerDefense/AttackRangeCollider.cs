using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeCollider : AdminMonoBehaviour
{
    List<Transform> listTarget = new List<Transform>();
    [SerializeField] protected TowerSpawnMobileObject towerdefense;
    protected TowerSpMobileObjAttack towerAttack;
    protected override void LoadComponent()
    {
        this.towerdefense = transform.parent.GetComponentInChildren<TowerSpawnMobileObject>();
        this.towerAttack = this.towerdefense.transform.GetComponentInChildren<TowerSpMobileObjAttack>();
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            Category categoryEnemy = collision.transform.parent.GetComponentInChildren<DataEnemy>()._category;
            if (this.towerdefense.tData.GetComponent<DataTowerDefense>()._category >= categoryEnemy)
                this.listTarget.Add(collision.transform.parent);

        }
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            this.listTarget.Remove(collision.transform.parent);
            if (this.towerAttack._target == collision.transform.parent) this.towerAttack.SetTarget(null);
        }
    }

    public Transform TargetByDistance()
    {
        this.listTarget.Sort((Transform x, Transform y) =>
        {
            if (Vector3.Distance(x.position, transform.parent.position) < Vector3.Distance(y.position, transform.parent.position)) return -1;
            else return 1;
        });
        return this.listTarget[0];
    }
    private void FixedUpdate()
    {
        if (this.listTarget.Count <= 0)
        {
            if (!this.towerAttack._isAttack) this.towerAttack.SetIsAttack(false);
            this.towerAttack.SetTarget(null);
            return;
        }


        if (!this.towerAttack._isAttack)
        {
            this.towerAttack.SetIsAttack(true);
        }
        if (this.towerAttack._target == null)
        {
            Transform newTarget = this.TargetByDistance();
            this.towerAttack.SetTarget(newTarget);
        }
    }
}
