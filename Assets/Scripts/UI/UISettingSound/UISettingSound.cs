using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UISettingSound : AdminMonoBehaviour
{
    Slider musicSlider;
    Slider fxSoundSlider;
    Button bnBack;
    DataPlayerSO dataPlayerSO;
    protected override void LoadComponent()
    {
        this.dataPlayerSO = Resources.Load<DataPlayerSO>("DataPlayerSO/DataPlayer");
        this.musicSlider = transform.Find("SliderMusic").GetComponent<Slider>();
        this.fxSoundSlider = transform.Find("SliderFXSound").GetComponent<Slider>();
        this.bnBack = transform.Find("BnBack").GetComponent<Button>();
        this.bnBack.onClick.AddListener(BnBackOnClick);
    }
    private void Start()
    {
        this.musicSlider.value = AudioManager.instance._musicVolume;
        this.fxSoundSlider.value = AudioManager.instance._fxVolume;
    }
    private void Update()
    {
        if (this.dataPlayerSO._volumeFXSound != this.fxSoundSlider.value || this.dataPlayerSO._volumeMusic != this.musicSlider.value)

        {
            this.dataPlayerSO.SetVolume(this.musicSlider.value, this.fxSoundSlider.value);
            AudioManager.instance.SetFXVolume(this.fxSoundSlider.value);
            AudioManager.instance.SetMusicVolume(this.musicSlider.value);

        }
    }
    void BnBackOnClick()
    {
        transform.gameObject.SetActive(false);
        transform.parent.GetComponent<UIOptionMenu>().OnBnUI();
    }
}
