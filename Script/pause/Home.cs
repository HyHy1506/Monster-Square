using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public void clickHome()
    {
        SceneManager.LoadSceneAsync("Start");
        Time.timeScale = 1.0f;
    }
}
