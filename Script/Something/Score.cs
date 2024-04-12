using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float valueScore;

    private Text text;
    private void Start()
    {
        text= GetComponent<Text>();
        text.text = "0";
        DataInGame.ResetScore();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        valueScore=DataInGame.GetValueScore();
        text.text = valueScore.ToString();
       if(DataInGame.GetHealth()<=0 && valueScore>DataPlayer.GetMaxScore())
        {
            DataPlayer.SetMaxScore(valueScore);
        }

    }
}
