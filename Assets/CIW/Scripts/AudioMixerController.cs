using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerController : MonoBehaviour
{
    public AudioMixer _masterMixer;

    public Slider[] _sliders; // 오디오를 조절할 슬라이더 배열

    public void ControllVolume(string audioType)
    {
        switch (audioType)
        {
            case "BGM":
                _masterMixer.SetFloat("BGM", _sliders[0].value);
                break;
            case "SoundEffect":
                _masterMixer.SetFloat("SoundEffect", _sliders[1].value);
                break;
        }
    }
}
