using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Again : MonoBehaviour
{
    public RectTransform rt;
   
    public void ClickAgain()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
   public void MenuDeath()
    {
        rt.position=new  Vector3(rt.position.x-1600f, rt.position.y, rt.position.y);
    }
}

