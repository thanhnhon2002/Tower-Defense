using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonContentTower : BaseButton
{
    protected string nameTower;
    public string _nameTower => nameTower;
    protected TextMeshProUGUI textPrice;
    protected TowerDefenseSO towerDefenseSO;
    [SerializeField] Image imageBn;
    [SerializeField] protected int price;
    public int _price => price;
    protected override void LoadData()
    {
        this.nameTower = transform.name.Replace("Bn", "");
        this.textPrice = transform.GetComponentInChildren<TextMeshProUGUI>();
        this.towerDefenseSO = Resources.Load<TowerDefenseSO>("TowerDefenseSO/" + this.nameTower);
        this.price = this.towerDefenseSO.price;
        this.imageBn = transform.GetComponent<Image>();
    }
    private void Start()
    {
        this.textPrice.text =this.price.ToString();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.button.onClick.AddListener(OnClick);
    }
    protected void OnClick()
    {
        if (this.transform.childCount > 3)
        {
            UIMenuChoseTower.instance.OnBnOkClick();
            return;
        }
        UIMenuChoseTower.instance.SetButtonContenTower(this);
    }
    private void FixedUpdate()
    {
        if (Player.instance._dataGamePlayer._gold > this.price)
        {

            Color currentColor = this.imageBn.color;
            currentColor.a = 1;
            this.imageBn.color = currentColor;
        }
        if (Player.instance._dataGamePlayer._gold < this.price)
        {

            Color currentColor = this.imageBn.color;
            currentColor.a = 0.4f;
            this.imageBn.color = currentColor;
        }
    }
}
