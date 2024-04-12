using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public RectTransform rt;
    public void quitClick()
    {
        Application.Quit();
    }    
    public void AskQuit()
    {
        rt.position = new Vector3(rt.position.x-17.77f, rt.position.y, rt.position.z);
    }
    public void AskNo()
    {
        rt.position = new Vector3(rt.position.x + 17.77f, rt.position.y, rt.position.z);

    }
}
