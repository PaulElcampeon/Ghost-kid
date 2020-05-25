using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSoundVolumes : MonoBehaviour
{
    public Slider sfxSlider;
    public Slider bgmSlider;

    void Start()
    {
        sfxSlider.value = SoundEngine.instance.sfxVolume;
        bgmSlider.value = SoundEngine.instance.bgmVolume;
    }

    public void UpdateBGMVolume()
    {
        SoundEngine.instance.UpdateBGMVolume(bgmSlider.value);
    }

    public void UpdateSFXVolume()
    {
        SoundEngine.instance.UpdateSFXVolume(sfxSlider.value);
    }
}
