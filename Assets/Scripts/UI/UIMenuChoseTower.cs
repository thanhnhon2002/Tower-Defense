using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuChoseTower : AdminMonoBehaviour
{
    public static UIMenuChoseTower instance;
    protected Button bnClose;
    protected Button bnOk;
    [SerializeField] List<Button> bnContents;
    protected Vector3 currentPlacePosition;
    [SerializeField] protected string nameTower;
    [SerializeField] protected BuildingPlace buildingPlace;
    protected Transform fxChose;
    public Vector3 _currentPlacePosition => currentPlacePosition;
    public void SetBuildingPlace(BuildingPlace buildingPlace)
    {
        this.buildingPlace = buildingPlace;
    }
    public void SetNameTower(string name)
    {
        this.nameTower = name;
        this.SetParentForfxChose(name);
        this.fxChose.transform.localPosition = new Vector3(0, 1.5f, 0);
    }
    protected void SetParentForfxChose(string name)
    {
        Transform t = this.bnContents.Find(i => i.name == "Bn" + name).transform;
        this.fxChose.SetParent(t);
        this.fxChose.gameObject.SetActive(true);
    }
    public void SetCurrentPlacePosition(Vector3 pos)
    {
        this.currentPlacePosition = pos;
    }
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    protected override void LoadComponent()
    {
        this.bnClose = transform.Find("Image").Find("ButtonClose").GetComponent<Button>();
        this.bnOk = transform.Find("Image").Find("ButtonOk").GetComponent<Button>();
        this.fxChose= transform.Find("FXChose");
        Transform panel = transform.Find("Panel");
        foreach (Transform t in panel)
        {
            Button bn = t.GetComponent<Button>();    
            this.bnContents.Add(bn);
        }
        this.bnOk.onClick.AddListener(OnBnOkClick);
        this.bnClose.onClick.AddListener(OnBnCloseClick);
    }
    private void Start()
    {
        this.CloseMenuChoseTower();
        this.fxChose.gameObject.SetActive(false);
    }
    public void OnMenuChoseTower()
    {
        gameObject.SetActive(true);
    }
    public void CloseMenuChoseTower()
    {
        gameObject.SetActive(false);
    }
    public void OnBnOkClick()
    {
        if (this.nameTower != ""&&!this.buildingPlace._isBuilding)
        {
            TowerDefenseSpawner.instance.Spawn(this.nameTower, this.currentPlacePosition, Quaternion.identity);
            this.buildingPlace.HaveTowerStatus();
            this.buildingPlace.SetIsBuild(true);
            this.buildingPlace.OnBnSetting();
            this.SetDefaulMenu();
            this.CloseMenuChoseTower();
            
        }
    }
    public void OnBnCloseClick()
    {  
        if (this.buildingPlace._isBuilding) this.buildingPlace.HaveTowerStatus();
        else this.buildingPlace.InitialState();
        this.SetDefaulMenu();
        this.CloseMenuChoseTower();
    }
    public void SetDefaulMenu()
    {
        this.currentPlacePosition = Vector3.zero;
        this.nameTower = "";
        this.buildingPlace = null;
        this.fxChose.gameObject.SetActive(false);
        this.fxChose.SetParent(this.transform);
    }

}
