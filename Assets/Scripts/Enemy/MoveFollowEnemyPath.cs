using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEngine;

public class MoveFollowEnemyPath : MonoBehaviour
{
    [SerializeField] protected List<Vector3> path = new List<Vector3>();
    [SerializeField] protected int currentIndex;
    [SerializeField] protected Enemy enemy;
    private void Awake()
    {
        this.enemy = this.transform.parent.GetComponent<Enemy>();
    }
    public void SetPath(List<Vector3> path)
    {
        this.path = path;
        this.currentIndex=0;
    }
    IEnumerator MoveWithPath()
    {
        while (this.currentIndex != this.path.Count - 1)
        {
            if (this.transform.parent.position!=this.path[this.currentIndex + 1]) this.transform.parent.position = Vector3.MoveTowards(this.transform.parent.position, this.path[this.currentIndex + 1], this.enemy.dataEnemy.getRunSpeed * Time.fixedDeltaTime);
            else this.currentIndex++;
            yield return null;
        }
        EnemyManager.instance.listPool.PushToPool(this.transform.parent);
        
    }
    public void StartMove()
    {
        StartCoroutine(MoveWithPath());
    }
  
}
