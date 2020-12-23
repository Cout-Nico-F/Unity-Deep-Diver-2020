using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    private Slider musicSlider;

    private void Awake()
    {
        musicSlider = this.gameObject.GetComponent<Slider>();
    }
    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("Music_Volume_Value", 0.5f);
    }
    public void Music_Volume(float sliderValue)
    {
        mixer.SetFloat("Music_Volume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("Music_Volume_Value", sliderValue);
    }
    public void SFX_Volume(float sliderValue)
    {
        mixer.SetFloat("SFX_Volume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SFX_Volume_Value", sliderValue);
    }
}
