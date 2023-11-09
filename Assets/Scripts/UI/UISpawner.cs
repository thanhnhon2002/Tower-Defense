using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UISpawner : SpawnObject
{
    static public UISpawner instance;

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    public Transform SpawnDamageText(string text,Vector3 pos,Quaternion rotation)
    {
        Transform newTransform = base.Spawn("DamageText", pos+new Vector3(0,1,0), rotation);
        newTransform.GetComponent<DestroyByTime>().SetTimeMax(1);
        TextMeshProUGUI damageText = newTransform.GetComponentInChildren<TextMeshProUGUI>();
        //damageText.SetText(text);
        damageText.text = "-" + text;
        return newTransform;
    }
}
