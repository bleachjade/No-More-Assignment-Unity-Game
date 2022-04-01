using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    public Slider sliderBgm;
    public Slider sliderSfx;
    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        LoadBGM_SFX();
    }

    public void LoadBGM_SFX() {
        if (PlayerPrefs.HasKey("BGM_VOLUME")) {
            sliderBgm.value = PlayerPrefs.GetFloat("BGM_VOLUME");
        }
        if (PlayerPrefs.HasKey("SFX_VOLUME")) {
            sliderSfx.value = PlayerPrefs.GetFloat("SFX_VOLUME");
        }
    }

    public void SetBGMVol(float vol) {
        mixer.SetFloat("BGM_VOLUME", vol);
        PlayerPrefs.SetFloat("BGM_VOLUME", vol);
    }

    public void SetSFXVol(float vol) {
        mixer.SetFloat("SFX_VOLUME", vol);
        PlayerPrefs.SetFloat("SFX_VOLUME", vol);
    }

}
