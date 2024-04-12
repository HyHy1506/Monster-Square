using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public RectTransform rt;
    public void ClickPause()
    {
        rt.position=new Vector3(rt.position.x, rt.position.y - 718, rt.position.z);
        Time.timeScale=0;
    }
    public void clickHome()
    {
        SceneManager.LoadSceneAsync("Start");
        Time.timeScale = 1.0f;
    }
    public void clickReturn()
    {
        rt.position = new Vector3(rt.position.x, rt.position.y + 718, rt.position.z);
        Time.timeScale = 1f;
    }
    public void ClickAgain()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
    public void MenuDeath()
    {
        rt.position = new Vector3(rt.position.x - 1600f, rt.position.y, rt.position.y);
    }
    public void AskNo()
    {
        rt.position = new Vector3(rt.position.x + 1600f, rt.position.y, rt.position.z);

    }
    public void AskQuit()
    {
        rt.position = new Vector3(rt.position.x - 1600f, rt.position.y, rt.position.z);
    }
}
