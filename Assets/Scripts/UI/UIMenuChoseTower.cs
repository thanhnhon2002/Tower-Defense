using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuChoseTower : AdminMonoBehaviour
{
    public static UIMenuChoseTower instance;
    protected Button bnClose;
    protected Button bnOk;
    [SerializeField] List<Button> bnContents;
    protected Vector3 currentPlacePosition;
    [SerializeField] protected BuildingPlace buildingPlace;
    protected Transform fxChose;
    [SerializeField] protected ButtonContentTower buttonContentTower;
    public ButtonContentTower _buttonContentTower => buttonContentTower;
    public Vector3 _currentPlacePosition => currentPlacePosition;
    public void SetBuildingPlace(BuildingPlace buildingPlace)
    {
        this.buildingPlace = buildingPlace;
    }
    public void SetButtonContenTower(ButtonContentTower buttonContentTower)
    {
        this.buttonContentTower = buttonContentTower;
        this.SetParentForfxChose(buttonContentTower.name);
        this.fxChose.transform.localPosition = new Vector3(0, 1.5f, 0);
    }
    protected void SetParentForfxChose(string name)
    {
        Transform t = this.bnContents.Find(i => i.name == name).transform;
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
        if (this.buttonContentTower!=null&&!this.buildingPlace._isBuilding)
        {
            if(!Player.instance.IsBuying(this.buttonContentTower._price))
            {
                /////////////////////
                Debug.Log("Khong du tien");
                return;
            }

            TowerDefenseSpawner.instance.Spawn(this.buttonContentTower._nameTower, this.currentPlacePosition, Quaternion.identity);
            this.buildingPlace.InitialState();
            this.buildingPlace.SetIsBuild(true);
            this.SetDefaulMenu();
            this.CloseMenuChoseTower();
            BuildingPlaceManager.instance.SetCurrentPlace(null);
        }
    }
    public void OnBnCloseClick()
    {  
        this.buildingPlace.InitialState();
        this.SetDefaulMenu();
        this.CloseMenuChoseTower();
        BuildingPlaceManager.instance.SetCurrentPlace(null);
    }
    public void SetDefaulMenu()
    {
        this.currentPlacePosition = Vector3.zero;
        this.buttonContentTower = null;
        this.buildingPlace = null;
        this.fxChose.gameObject.SetActive(false);
        this.fxChose.SetParent(this.transform);
    }

}
