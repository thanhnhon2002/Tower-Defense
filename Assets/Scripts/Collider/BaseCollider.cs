using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollider : AdminMonoBehaviour
{
    [SerializeField] protected new Collider2D collider2D;
    [SerializeField] protected new Rigidbody2D rigidbody2D;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        collider2D = GetComponent<Collider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
}
