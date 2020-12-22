using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    private Slider slider;

    private void Awake()
    {
        slider = this.gameObject.GetComponent<Slider>();
    }
    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("Volume", 0.5f);
    }
    public void Volume(float sliderValue)
    {
        mixer.SetFloat("Volume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("Volume", sliderValue);
    }
}
