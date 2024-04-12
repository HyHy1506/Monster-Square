using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundMusic : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Awake()
    {
        slider.value = DataPlayer.GetMusic();
    }
    public void ChangeMusic(float value)
    {
        DataPlayer.SetMusic(value);
    }
}
