using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BnMap : BaseButton
{
    GameObject imageLock;
    DataPlayerSO dataPlayerSO;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.button.onClick.AddListener(OnClick);
        this.imageLock = transform.Find("Image").gameObject;
        this.dataPlayerSO = Resources.Load<DataPlayerSO>("DataPlayerSO/DataPlayer");
    }
    void OnClick()
    {
       // UIMenuGame.instance.BnCloseMenuMapOnClick();
        string nameBn = this.gameObject.name;
        GameManager.instance.LoadScene(nameBn);
    }
    IEnumerator CBn()
    {
        yield return new WaitForSeconds(2);
    }
    private void Update()
    {
        int index = transform.GetSiblingIndex()+1;
        if (index <= this.dataPlayerSO._level) this.SetStateBn(false);
        else this.SetStateBn(true);
    }
    void SetStateBn(bool b)
    {
        this.imageLock.SetActive(b);
        this.button.interactable = !b;
    }
}
