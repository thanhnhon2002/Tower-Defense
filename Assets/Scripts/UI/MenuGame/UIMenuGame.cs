using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuGame : AdminMonoBehaviour
{
    public static UIMenuGame instance;
    GameObject uiStart;
    Animator anitUIStart;
    Button bnStart;
    Button bnExit;
    Animator anitBnExit;
    GameObject menuMap;
    [SerializeField] Animator anitUIMenuMap;
    Button bnCloseMenuMap;
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    protected override void LoadComponent()
    {
        this.uiStart = transform.Find("UIStart").gameObject;
        this.bnStart = this.uiStart.GetComponentInChildren<Button>();
        this.bnExit = transform.Find("BnExit").GetComponent<Button>();
        this.menuMap = transform.Find("MenuMap").gameObject;
        this.anitUIStart = this.uiStart.GetComponent<Animator>();
        this.anitBnExit = this.bnExit.transform.GetComponent<Animator>();
        this.anitUIMenuMap = this.menuMap.transform.GetComponent<Animator>();
        this.bnCloseMenuMap = transform.Find("MenuMap").Find("BnCloseMenuMap").GetComponent<Button>();

        this.bnStart.onClick.AddListener(BnStartOnClick);
        this.bnExit.onClick.AddListener(BnExitOnClick);
        this.bnCloseMenuMap.onClick.AddListener(BnCloseMenuMapOnClick);
    }
    private void OnEnable()
    {
        this.menuMap.SetActive(false);
    }
    void BnStartOnClick()
    {
        this.anitUIStart.SetInteger("uiState", 1);
        this.anitBnExit.SetInteger("uiState", 1);

        this.menuMap.SetActive(true);
    }
    void BnExitOnClick()
    {
        GameManager.instance.ExitGame();
    }
    public void BnCloseMenuMapOnClick()
    {
        StartCoroutine(CBnCloseMenuMap());
    }
    IEnumerator CBnCloseMenuMap()
    {
        this.anitUIMenuMap.SetInteger("uiState", 1);
        yield return new WaitForSeconds(1f);
        this.menuMap.SetActive(false);
        this.menuMap.GetComponent<CanvasGroup>().alpha = 1;
        this.anitUIStart.SetInteger("uiState", 0);
        this.anitBnExit.SetInteger("uiState", 0);
    }
  
}

