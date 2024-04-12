using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class DataPlayer
{
    public static string AllData = "alldataSetting";
    public static StorePlayer SP;
    static DataPlayer()
    {
        SP = JsonUtility.FromJson<StorePlayer>(PlayerPrefs.GetString(AllData));
        if (SP == null)
        {
            SP = new StorePlayer()
            {
                soundEffect = 1, music = 1, maxScore = 0
            };
        }
    }
    public static void SavaData()
    {
        var data = JsonUtility.ToJson(SP);
        PlayerPrefs.SetString(AllData, data);
    }
    //music
    public static void SetMusic(float music)
    {
        SP.SetValueMusic(music);
        SavaData();
    }
    public static float GetMusic() { return SP.music; }
    //sound effect
    public static void SetSoundEffect(float music)
    {
        SP.SetValueSoundFX(music);
        SavaData();
    }
    public static float GetSoundEffect() { return SP.soundEffect; }
    //max score
    public static void SetMaxScore (float score)
    {
        SP.SetValueMaxScore(score);
        SavaData();
    }
    
    public static float GetMaxScore() { return SP.maxScore; }

    public static void ResetScore()
    {
        SP.ResetValueScore();
    }
}
public class StorePlayer
{
    public float music;
    public float soundEffect;
    public float maxScore;
    public void SetValueMusic(float valuemusic)
    {
        music = valuemusic;
    }
    public void SetValueSoundFX(float valuemusic)
    {
        soundEffect = valuemusic;
    }
    public void SetValueMaxScore(float valueScore)
    {
        maxScore= valueScore;
    }
    public void ResetValueScore()
    {
        maxScore= 0;
    }

}
