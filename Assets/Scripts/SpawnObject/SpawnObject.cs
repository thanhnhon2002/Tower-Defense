using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnObject : MonoBehaviour
{
    
    [SerializeField] protected Transform listClone;
    [SerializeField] protected ListPool listPool;
    protected virtual void Awake()
    {
        
        this.LoadTransform();
        this.LoadComponent();
      

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
        newTrf.gameObject.SetActive(true);
        newTrf.transform.SetParent(this.listClone);
        return newTrf;
    }
    public virtual Transform Spawn(string name, Vector3 pos, Quaternion rotation)
    {
        Transform newTrf= this.listPool.Find(name);

        if ( newTrf== null)
        {
            Transform prefab = transform.parent.Find("ListPrefab").GetComponent<ListPrefab>().getPrefab(name);
            newTrf = Instantiate(prefab, pos, rotation);
            newTrf.name = name;  
        }
        else
        {
            newTrf.transform.position = pos;
            newTrf.transform.rotation = rotation;
            newTrf.gameObject.SetActive(true);
        }    
        newTrf.transform.SetParent(this.listClone);
        return newTrf;
    }

}
