using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Announcement : AdminMonoBehaviour
{
    public static Announcement instance;
    [SerializeField] protected Transform tInterface;
    [SerializeField] protected TextMeshProUGUI textAnnounce;
    [SerializeField] protected Animator animator;
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    protected override void LoadComponent()
    {
        this.tInterface = transform.Find("Interface");
        this.textAnnounce = this.tInterface.GetComponentInChildren<TextMeshProUGUI>();
        this.animator = this.tInterface.GetComponent<Animator>();
    }

    protected void SetTextAnnounce(string text)
    {
        this.textAnnounce.text = text;
    }
    public void Announce(string text)
    {
        this.SetTextAnnounce(text);
        this.animator.SetInteger("announce", 1);
        StartCoroutine(WaitAnnounce(4));
    }
    IEnumerator WaitAnnounce(float time)
    {
        yield return new WaitForSeconds(time);
        this.animator.SetInteger("announce", 0);
    }
   
}
