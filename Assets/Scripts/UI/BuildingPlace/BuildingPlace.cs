using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuildingPlace : AdminMonoBehaviour
{
    SpriteRenderer ground;
    SpriteRenderer flag;
    SpriteRenderer settingTower;
    Button bnOnSettingTower;
    Button bnOption1;
    Button bnOption2;
    Button bnOption3;
    Button bnOption4;
    Transform towerdefense;
    bool isBuilding;
    public bool _isBuilding =>this.isBuilding;
    public void SetIsBuild(bool i)
    {
        this.isBuilding = i;
    }
    public void SetTowerdefense(Transform tower)
    {
        this.towerdefense = tower;
    }
    public void InitialState()
    {
        if (this.isBuilding) this.flag.gameObject.SetActive(false);
        else
        {
            this.flag.gameObject.SetActive(true);
            this.towerdefense = null;
        }
        this.bnOnSettingTower.gameObject.SetActive(true);
        this.settingTower.gameObject.SetActive(false);
        this.bnOption1.gameObject.SetActive(false);
        this.bnOption2.gameObject.SetActive(false);
        this.bnOption3.gameObject.SetActive(false);
        this.bnOption4.gameObject.SetActive(false);
    }

    private void Start()
    {
        this.InitialState();
    }
    protected override void LoadComponent()
    {
        this.ground = transform.Find("Ground").GetComponent<SpriteRenderer>();
        this.flag = transform.Find("Flag").GetComponent<SpriteRenderer>();

        this.bnOnSettingTower = transform.Find("Canvas").Find("BnOnSettingTower").GetComponent<Button>();
        this.settingTower = transform.Find("Canvas").Find("ImageSettingTower").GetComponent<SpriteRenderer>();
        this.bnOption1 = transform.Find("Canvas").Find("Option1").GetComponent<Button>();
        this.bnOption2 = transform.Find("Canvas").Find("Option2").GetComponent<Button>();
        this.bnOption3 = transform.Find("Canvas").Find("Option3").GetComponent<Button>();
        this.bnOption4 = transform.Find("Canvas").Find("Option4").GetComponent<Button>();

        this.bnOnSettingTower.onClick.AddListener(OnBnSettingTowerClick);
        this.bnOption1.onClick.AddListener(OnBn1Click);
        this.bnOption2.onClick.AddListener(OnBn2Click);
        this.bnOption3.onClick.AddListener(OnBn3Click);
        this.bnOption4.onClick.AddListener(OnBn4Click);
        
    }
    public void OnBnSettingTowerClick()
    {
        if (UIMenuChoseTower.instance.gameObject.activeSelf) return;
        if (!this.bnOption1.gameObject.activeSelf)
        {
            this.bnOption1.gameObject.SetActive(true);
            this.bnOption2.gameObject.SetActive(true);
            this.bnOption3.gameObject.SetActive(true);
            this.bnOption4.gameObject.SetActive(true);
            this.settingTower.gameObject.SetActive(true);
        }
        else
        {
            this.InitialState();
        }
       
        if (BuildingPlaceManager.instance._currentBuildingPlace==null) BuildingPlaceManager.instance.SetCurrentPlace(this);
            else if(BuildingPlaceManager.instance._currentBuildingPlace==this)
            {
                BuildingPlaceManager.instance._currentBuildingPlace.InitialState();
                BuildingPlaceManager.instance.SetCurrentPlace(null);
            }
            else 
            {
                BuildingPlaceManager.instance._currentBuildingPlace.InitialState();
                BuildingPlaceManager.instance.SetCurrentPlace(this);
            }
            
        
    }
    public void OnBn1Click()
    {
        this.bnOnSettingTower.gameObject.SetActive(false);
        UIMenuChoseTower.instance.OnMenuChoseTower();
        UIMenuChoseTower.instance.SetCurrentPlacePosition(transform.position);
        UIMenuChoseTower.instance.SetBuildingPlace(this);
       
    }    
    public void OnBn2Click()
    {
        Debug.Log("button 2 on click");
        this.InitialState();
    }
    public void OnBn3Click()
    {
        Debug.Log("button 3 on click");
        this.InitialState();
    }
    public void OnBn4Click()
    {
        if(this.isBuilding)
        {
            int price = this.towerdefense.GetComponentInChildren<DataTowerDefense>()._price;
            Player.instance.SetGold((int)price/2);
            this.towerdefense.GetComponentInChildren<TowerSpDefenderAttack>().SetClearParentListDefender();
            TowerDefenseSpawner.instance._listPool.PushToPool(this.towerdefense);
            this.isBuilding = false;
            this.InitialState();
        }
        
    }

}
