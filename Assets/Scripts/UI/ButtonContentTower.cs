using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonContentTower : BaseButton
{
    protected string nameTower;
    protected TextMeshProUGUI textPrice;
    protected TowerDefenseSO towerDefenseSO;
    protected float price;
    protected override void LoadData()
    {
        this.nameTower = transform.name.Replace("Bn", "");
        this.textPrice = transform.GetComponentInChildren<TextMeshProUGUI>();
        this.towerDefenseSO = Resources.Load<TowerDefenseSO>("TowerDefenseSO/" + this.nameTower);
        this.price = this.towerDefenseSO.price;
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
        UIMenuChoseTower.instance.SetNameTower(this.nameTower);
    }
   
}
