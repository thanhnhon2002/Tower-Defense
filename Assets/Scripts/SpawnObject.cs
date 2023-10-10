using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    static public SpawnObject instance;
    [SerializeField] protected Transform listClone;
    [SerializeField] protected ListPool listPool;

    private void Awake()
    {
        
        this.LoadTransform();
        this.LoadComponent();
        instance = this;

    }
    protected void LoadTransform()
    {
        this.listClone = transform.parent.Find("ListClone");
    }
    protected void LoadComponent()
    {
        this.listPool = transform.parent.GetComponentInChildren<ListPool>();
    }
    public Transform Spawn(Transform trf, Vector3 pos, Quaternion rotation)
    {
        Transform newTrf = Instantiate(trf, pos, rotation);
        newTrf.transform.SetParent(this.listClone);
        return newTrf;
    }
    public virtual Transform Spawn(string name, Vector3 pos, Quaternion rotation)
    {
        Transform newTrf= this.listPool.Find(name);

        if ( newTrf== null)
        {
            Transform prefab = transform.parent.Find("ListPrefab").GetComponent<ListPrefab>().getPrefab(name);
            Transform newTrf1 = Instantiate(prefab, pos, rotation);
            newTrf1.name = name;
            newTrf1.gameObject.SetActive(true);
            newTrf1.transform.SetParent(this.listClone);
            return newTrf1;
        }
        else
        {
           
            newTrf.transform.position = pos;
            newTrf.transform.rotation = rotation;
           
            newTrf.gameObject.SetActive(true);
            newTrf.transform.SetParent(this.listClone);
            return newTrf;
        }
        
        

       
    }

}
