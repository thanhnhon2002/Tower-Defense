using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BowTower : TowerDenfense
{
    public BowTowerAttack attack;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.attack = transform.Find("Attack").GetComponent<BowTowerAttack>();
    }
}
