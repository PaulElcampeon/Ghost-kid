using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSoundVolumes : MonoBehaviour
{
    public Slider sfxSlider;
    public Slider bgmSlider;
    // Start is called before the first frame update
    void Start()
    {
        sfxSlider.value = SoundEngine.instance.sfxVolume;
        bgmSlider.value = SoundEngine.instance.bgmVolume;
    }

    // Update is called once per frame
    void Update()
    {
        SoundEngine.instance.UpdateSoundVolume(sfxSlider.value, bgmSlider.value);
    }
}
