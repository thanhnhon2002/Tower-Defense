using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILoadingScene : AdminMonoBehaviour
{
    public static UILoadingScene instance;
    GameObject loadingScene;
    [SerializeField] Slider slider;
    TextMeshProUGUI text;
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    protected override void LoadComponent()
    {
        this.loadingScene = transform.Find("LoadingScene").gameObject;
        this.slider = this.loadingScene.GetComponentInChildren<Slider>();
        this.text = this.loadingScene.GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Start()
    {
        this.loadingScene.SetActive(false);
    }
    void SetColider(float f)
    {
        this.slider.value = f;
    }
    void SetText(string s)
    {
        this.text.text = s;
    }
    public void ShowUI(AsyncOperation op)
    {
        this.loadingScene.SetActive(true);
        StartCoroutine(LoadSceneAsync(op));
    }
    IEnumerator LoadSceneAsync(AsyncOperation op)
    {
        while (!op.isDone)
        {
            float progress = op.progress / 0.9f;
            this.SetText("Loading ... " + progress * 100f + " %");
            this.SetColider(progress/0.9f);
            yield return null;
        }
    }
}
