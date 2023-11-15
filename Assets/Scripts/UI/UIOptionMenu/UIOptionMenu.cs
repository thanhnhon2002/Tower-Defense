using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOptionMenu : AdminMonoBehaviour
{
    Button bnOnOptionMenu;
    Button bnContinue;
    Button bnMusic;
    Button bnHome;
    protected override void LoadComponent()
    {
        this.bnOnOptionMenu = transform.parent.Find("UIGame").Find("BnOnOptionMenu").GetComponent<Button>();
        this.bnContinue = transform.Find("BnContinue").GetComponent<Button>();
        this.bnMusic = transform.Find("BnMusic").GetComponent<Button>();
        this.bnHome = transform.Find("BnHome").GetComponent<Button>();

        this.bnOnOptionMenu.onClick.AddListener(this.BnOnOptionMenuOnClick);
        this.bnContinue.onClick.AddListener(this.BnContinueOnClick);
        this.bnMusic.onClick.AddListener(this.BnMusicOnClick);
        this.bnHome.onClick.AddListener(this.BnHomeOnClick);
    }
    private void Start()
    {
        this.HideUI();
    }
    void ShowUI()
    {
        transform.gameObject.SetActive(true);
        this.bnOnOptionMenu.gameObject.SetActive(false);
    } 
    void HideUI()
    {
        transform.gameObject.SetActive(false);
        this.bnOnOptionMenu.gameObject.SetActive(true);
    }
    void BnOnOptionMenuOnClick()
    {
        this.ShowUI();
        GameManager.instance.PauseGame();
    }
    void BnContinueOnClick()
    {
        this.HideUI();
        GameManager.instance.ContinueGame();
    }
    void BnMusicOnClick()
    {
        Debug.Log("Bn Music OnClick");
    }
    void BnHomeOnClick()
    {
        GameManager.instance.ContinueGame();
        GameManager.instance.LoadScene("SceneMain");
    }
}
