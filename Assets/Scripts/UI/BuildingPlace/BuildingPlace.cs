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
    bool isBuilding;
    public bool _isBuilding =>this.isBuilding;
    public void SetIsBuild(bool i)
    {
        this.isBuilding = i;
    }
    public void OnBnSetting()
    {
        this.bnOnSettingTower.gameObject.SetActive(true);
    }
    public void OnFlag()
    {
        this.flag.gameObject.SetActive(true);
    }
    public void CloseFlag()
    {
        this.flag.gameObject.SetActive(false);
    }
    public void InitialState()
    {       
        this.flag.gameObject.SetActive(true);
        this.bnOnSettingTower.gameObject.SetActive(true);
        this.settingTower.gameObject.SetActive(false);
        this.bnOption1.gameObject.SetActive(false);
        this.bnOption2.gameObject.SetActive(false);
        this.bnOption3.gameObject.SetActive(false);
        this.bnOption4.gameObject.SetActive(false);
    }
    public void HaveTowerStatus()
    {
        this.InitialState();
        this.CloseFlag();
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
        if (!this.bnOption1.gameObject.activeSelf)
        {
            this.bnOption1.gameObject.SetActive(true);
            this.bnOption2.gameObject.SetActive(true);
            this.bnOption3.gameObject.SetActive(true);
            this.bnOption4.gameObject.SetActive(true);
            this.settingTower.gameObject.SetActive(true);
        }
        else if(!this.isBuilding)
        {
            this.InitialState();
        }
        else
        {
            this.InitialState();
            this.CloseFlag();
        }
    }
    public void OnBn1Click()
    {
        Debug.Log("button 1 on click");
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
        Debug.Log("button 4 on click");
        this.InitialState();
    }

}
