using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliderCompatOnPath : ColliderCompatOnPath
{
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.attackOnPath = transform.parent.GetComponentInChildren<EnemyAttack>();
        
    }
}
