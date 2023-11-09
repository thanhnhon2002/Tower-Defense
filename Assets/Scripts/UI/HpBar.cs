using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : AdminMonoBehaviour
{
    Slider slider;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.slider = GetComponentInChildren<Slider>();
    }
    public void SetHpBar(float value)
    {
        this.slider.value = value;
    }
    protected void OnEnable()
    {
        this.slider.value = 1;
    }
}
