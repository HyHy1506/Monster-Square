using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public RectTransform rt;
    
  
    public void SettingClick()
    {
        rt.position = new Vector3(0, 10, 0);
    }
    public void BackClick()
    {
        rt.position = new Vector3(0, 0, 0);
    }
    
}
