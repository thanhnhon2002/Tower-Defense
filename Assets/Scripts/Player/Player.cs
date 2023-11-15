using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Player : Data
{
    public static Player instance;
    [SerializeField] protected int level;
    [SerializeField] protected DataGamePlayer dataGamePlayer;
    [SerializeField] protected int kill;
    public int _kill => kill;
    [SerializeField]protected DataGameSO dataPlayerGameSO;
    public DataGamePlayer _dataGamePlayer => dataGamePlayer;

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
        this.dataPlayerGameSO = Resources.Load<DataGameSO>("DataGameSO/DataGame");
        this.textGold = transform.Find("TextGold").GetComponent<TextMeshProUGUI>();
        this.textKill = transform.Find("TextKill").GetComponent<TextMeshProUGUI>();
        this.textHeal = transform.Find("TextHeal").GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        this.level = GameManager.instance._level;
        DataGamePlayer data = this.dataPlayerGameSO.GetDataGamePlayer(this.level);
        this.dataGamePlayer = new DataGamePlayer(data._level, data._gold, data._heal);
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
    public void SetGold(int gold)
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
        this.SetGold(1);
        yield return StartCoroutine(IncGoldByTime());
    }
    public bool IsBuying(int price)
    {
        bool isBuying = this.dataGamePlayer._gold>=price;
        if (isBuying) this.SetGold(-price);
        else UIManager.instance.Announce("Not enough gold to buy");
        return isBuying;
    }
    public void HideUI()
    {
        this.gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (this.dataGamePlayer._heal == 0) GameManager.instance.EndGame();
    }
}
