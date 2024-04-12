using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataInGame
{
    public static StoreData SD;
    static DataInGame() { SD = new StoreData(); }

    // positionPlayer
    public static void SetValueSD(float a, float b, float c)
    {
        SD.SetValue(a, b, c);
    }
    public static float GetValueSDx()
    {
        return SD.dirXPlayer;

    }
    public static float GetValueSDy()
    {
        return SD.dirYPlayer;
    }
    public static float GetValueSDz()
    {
        return SD.dirZPlayer;
    }
    //score
    public static void SetValueScore(float Score)
    {
        SD.SetScore(Score);
    }
    public static float GetValueScore()
    {
        return SD.TotalScore;
    }
    //
    public static void SetHealth(float health)
    {
        SD.SetHealthPlayer(health);
    }
    public static float GetHealth()
    {
        return SD.healthPlayer;
    }
    public static void ResetScore()
    {
        SD.ResetValueScore();
    }
}
public class StoreData
{
    public float dirXPlayer;
    public float dirYPlayer;
    public float dirZPlayer;
    
    public float TotalScore=0;
    public float healthPlayer=100;
    public void SetValue(float x,float y,float z)
    {
        dirXPlayer = x;
        dirYPlayer = y;
        dirZPlayer = z;
    }
    public void SetScore(float score)
    {
        TotalScore = TotalScore+ score;
    }
    public void SetHealthPlayer(float health)
    {
        healthPlayer= health;
    }
    public void ResetValueScore()
    {
        TotalScore= 0;
    }

}
