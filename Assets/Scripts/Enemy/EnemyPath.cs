using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] protected List<Transform> listPoint; 
    public List<Vector3> GetListPos()
    {
        List<Vector3> list = new List<Vector3>();
        foreach (Transform t in listPoint)
        {
            Vector3 pos = new Vector3(Random.Range(-0.5f,0.5f), Random.Range(-0.5f,0.5f),0);
            list.Add(t.position+pos);
        }
        return list;
    }
    private void OnDrawGizmos()
    {
        for (int i = 0; i < listPoint.Count - 1; i++) Gizmos.DrawLine(this.listPoint[i].position, this.listPoint[i + 1].position);  
    }
}
