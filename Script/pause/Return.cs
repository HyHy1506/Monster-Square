using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return : MonoBehaviour
{
    public RectTransform rt;
    public void clickReturn()
    {
        rt.position = new Vector3(rt.position.x, rt.position.y + 10, rt.position.z);
        Time.timeScale= 1f;
    }
}
