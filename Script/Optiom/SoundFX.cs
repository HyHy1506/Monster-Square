using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundFX : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Awake()
    {
        slider.value = DataPlayer.GetSoundEffect();
    }
    public void ChangeMusic(float value)
    {
        DataPlayer.SetSoundEffect(value);
    }
}
