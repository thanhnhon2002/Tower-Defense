using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : AdminMonoBehaviour
{
    static public UIManager instance;
    public ListPrefab listPrefab;
    public ListPool listPool;
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    protected override void LoadComponent()
    {
        this.listPrefab = GetComponentInChildren<ListPrefab>();
        this.listPool = GetComponentInChildren<ListPool>();
    }
    public void Announce(string text)
    {
        Announcement.instance.Announce(text);
    }
    public void OnMenuChoseTower()
    {
        UIMenuChoseTower.instance.OnMenuChoseTower();
    }
}
