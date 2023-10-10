using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPrefab : MonoBehaviour
{
    [SerializeField] protected List<Transform> listPrefab;

    public Transform getPrefab(string name)
    {
        return this.listPrefab.Find((i)=> i.name == name);
    }
    public Transform getPrefab(int index)
    {
        return this.listPrefab[index];
    }
    public int getCoutListPrafab()
    {
        return this.listPrefab.Count;
    }
}
