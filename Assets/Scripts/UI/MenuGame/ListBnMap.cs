using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListBnMap : AdminMonoBehaviour
{
    [SerializeField]List<BnMap> bnMaps;
    protected override void LoadComponent()
    {
        foreach(var btn in GetComponentsInChildren<BnMap>())
        {
            bnMaps.Add(btn);
        }
    }
   
}
