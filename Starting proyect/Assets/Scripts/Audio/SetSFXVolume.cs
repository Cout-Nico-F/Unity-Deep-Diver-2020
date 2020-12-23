using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetSFXVolume : MonoBehaviour
{
    public AudioMixer mixer;
    private Slider sfxSlider;

    private void Awake()
    {
        sfxSlider = this.gameObject.GetComponent<Slider>();
    }
    private void Start()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("SFX_Volume_Value", 0.5f);
    }
    public void SFX_Volume(float sliderValue)
    {
        mixer.SetFloat("SFX_Volume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SFX_Volume_Value", sliderValue);
    }
}
