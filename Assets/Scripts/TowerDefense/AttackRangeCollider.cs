using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeCollider : MonoBehaviour
{
      List<Transform> listTarget =new List<Transform>();
    [SerializeField] protected TowerDenfense towerdefense;

    
    private void Awake() => this.LoadComponent();
    
    void LoadComponent()
    {
        if(this.transform.parent.name.Contains("BowTower"))
        {
            this.towerdefense = transform.parent.GetComponent<BowTower>();
        }
       
     
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            Category categoryEnemy = collision.transform.parent.GetComponentInChildren<DataEnemy>()._category;
            if (this.towerdefense.data._category >= categoryEnemy)
                this.listTarget.Add(collision.transform.parent);

        }
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null) this.listTarget.Remove(collision.transform.parent);
    }

    public Transform TargetByDistance()
    {
        this.listTarget.Sort((Transform x, Transform y) => 
        { if (Vector3.Distance(x.position, transform.parent.position) < Vector3.Distance(y.position, transform.parent.position)) return -1;
            else return 1;
        } );
        return this.listTarget[0];
    }
    private void FixedUpdate()
    {
        if (this.listTarget.Count <= 0)
        {
            this.towerdefense.attack.SetIsAttack(false);
            this.towerdefense.attack.SetTarget(null);
            return;
        }
        this.towerdefense.attack.SetIsAttack(true);
        Transform newTarget = this.TargetByDistance();
        this.towerdefense.attack.SetTarget(newTarget);
        
    }
}
