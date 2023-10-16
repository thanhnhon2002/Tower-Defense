using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBullet : MonoBehaviour
{
    protected Transform attacker;
    protected DataTowerDefense data;
    public void RecieveInfor(Transform attacker)
    {
        this.attacker = attacker;
        this.data = this.attacker.GetComponentInChildren<DataTowerDefense>();
    }
    public void GetInfor()
    {
        
    }
}
