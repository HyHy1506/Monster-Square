using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text text;
    private void Start()
    {
        text.text = DataPlayer.GetMaxScore().ToString();
    }
    
}
