using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListEnemyPath : MonoBehaviour
{
    static public ListEnemyPath instance;
    [SerializeField] protected List<EnemyPath> listEnemyPath = new List<EnemyPath>();
    private void Awake()
    {
        
        this.LoadListPath();
        instance = this;
    }
    protected void LoadListPath()
    {
        foreach (Transform t in transform)
        {
            this.listEnemyPath.Add(t.GetComponent<EnemyPath>());
        }
    }
    public List<Vector3> GetRandomEnemyPath()
    {
        int i=Random.Range(0, listEnemyPath.Count);
        return this.listEnemyPath[i].GetListPos();
    }
}
