using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class DataPlayer : Data
{
    public static DataPlayer instance;
    [SerializeField] protected int level;
    [SerializeField] protected DataGamePlayer dataGamePlayer;
    [SerializeField] protected int kill;
    protected DataPlayerGameSO dataPlayerGameSO;

    [SerializeField] protected TextMeshProUGUI textGold;
    [SerializeField] protected TextMeshProUGUI textKill;
    [SerializeField] protected TextMeshProUGUI textHeal;
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    protected override void LoadData()
    {
        this.dataPlayerGameSO = Resources.Load<DataPlayerGameSO>("DataPlayerGameSO/DataGamePlayer");
        DataGamePlayer data = this.dataPlayerGameSO.GetDataGamePlayer(this.level);
        this.dataGamePlayer = new DataGamePlayer(data._level, data._gold, data._heal);
        this.textGold = transform.Find("TextGold").GetComponent<TextMeshProUGUI>();
        this.textKill = transform.Find("TextKill").GetComponent<TextMeshProUGUI>();
        this.textHeal = transform.Find("TextHeal").GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        this.textGold.text = this.dataGamePlayer._gold.ToString();
        this.textHeal.text = this.dataGamePlayer._heal.ToString();
        this.textKill.text = this.kill.ToString();
        StartCoroutine(IncGoldByTime());
    }
    public void IncKill()
    {
        this.kill++;
        this.textKill.text = this.kill.ToString();
    }
    public void IncGold(int gold)
    {
        this.dataGamePlayer.SetGold(gold+this.dataGamePlayer._gold);
        this.textGold.text = this.dataGamePlayer._gold.ToString();
    }
    public void DecHeal(int heal)
    {
        int currentHeal = Math.Clamp(this.dataGamePlayer._heal - heal,0,int.MaxValue);
        this.dataGamePlayer.SetHeal(currentHeal);
        this.textHeal.text = this.dataGamePlayer._heal.ToString();
    }
    IEnumerator IncGoldByTime()
    {
        yield return new WaitForSeconds(1);
        this.IncGold(10);
        this.IncKill();
        this.DecHeal(2);
        yield return StartCoroutine(IncGoldByTime());
    }
}
