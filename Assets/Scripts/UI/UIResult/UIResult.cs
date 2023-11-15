using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIResult : AdminMonoBehaviour
{
    public static UIResult instance;
    Button bnOnOptionMenu;
    Button bnConfirm;

    TextMeshProUGUI textResult;
    TextMeshProUGUI textStar;
    TextMeshProUGUI textPointHeal;
    TextMeshProUGUI textPointKill;

    int starPoint;

    DataGameSO dataGameSO;
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    protected override void LoadComponent()
    {
        this.bnOnOptionMenu = transform.parent.Find("UIGame").Find("BnOnOptionMenu").GetComponent<Button>();
        this.bnConfirm = transform.Find("BnConfirm").GetComponent<Button>();
        this.dataGameSO = Resources.Load<DataGameSO>("DataGameSO/DataGame");

        this.bnConfirm.onClick.AddListener(BnConfirmOnClick);

        this.textResult = transform.Find("TextResult").GetComponent<TextMeshProUGUI>();
        this.textStar = transform.Find("TextStar").GetComponent<TextMeshProUGUI>();
        this.textPointHeal = transform.Find("TextPointHeal").GetComponent<TextMeshProUGUI>();
        this.textPointKill = transform.Find("TextPointKill").GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        this.HideUI();
    }
    public void ShowUI()
    {
        this.gameObject.SetActive(true);
        this.bnOnOptionMenu.gameObject.SetActive(false);
        UIMenuChoseTower.instance.CloseMenuChoseTower();
        this.SetTextHeal();
        this.SetTextStar();
        this.SetTextKill();
        this.SetTextResult();
        Player.instance.HideUI();

    }
    public void HideUI()
    {
        transform.gameObject.SetActive(false);
    }
    void SetTextStar()
    {
        float starPoint = (float)Player.instance._dataGamePlayer._heal / (float)this.dataGameSO.GetDataGamePlayer(GameManager.instance._level)._heal;
        if (starPoint <= 0.34f) this.starPoint = 1;
        else if (starPoint ==1) this.starPoint = 3;
        else this.starPoint = 2;
        Debug.Log(starPoint);
        this.textStar.text = this.starPoint.ToString();
    }
    void SetTextHeal()
    {
        int healPlayer = Player.instance._dataGamePlayer._heal;
        int healGame = this.dataGameSO.GetDataGamePlayer(GameManager.instance._level)._heal;
        this.textPointHeal.text = healPlayer.ToString()+"/"+healGame;
    }
    void SetTextKill()
    {
        this.textPointKill.text = Player.instance._kill.ToString();
    }
    void SetTextResult()
    {
        if (this.starPoint == 1) this.textResult.text = "Defeat";
        else
        {
            this.textResult.text = "Victory";
            GameManager.instance.UnLockLevel(GameManager.instance._level + 1);
        }
    }
    void BnConfirmOnClick()
    {
        GameManager.instance.ContinueGame();
        GameManager.instance.LoadScene("SceneMain");
    }
}