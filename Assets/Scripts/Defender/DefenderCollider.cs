using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderCollider : AdminMonoBehaviour
{
    [SerializeField] protected DefenderAttack attack;
    [SerializeField] protected List<Transform> listTarget;
    [SerializeField] protected new Collider2D collider;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.attack =transform.parent.GetComponentInChildren<DefenderAttack>();
        this.collider = transform.GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.listTarget.Add(collision.transform.parent);
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        this.attack.SetIsAttack(true);
        if (this.attack._target == null && this.listTarget.Count > 0) this.attack.SetTarget(this.listTarget[0]);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.attack.SetIsAttack(false);
        this.listTarget.Remove(collision.transform.parent);
    }
    private void FixedUpdate()
    {
        if (this.listTarget.Count == 0)
        {
            this.attack.SetIsAttack(false);
            this.attack.SetTarget(null);
        }
        else
        {
            foreach (var i in this.listTarget)
            {
                if (!i.gameObject.activeSelf) this.listTarget.Remove(i);
            }
        }
    }
}
