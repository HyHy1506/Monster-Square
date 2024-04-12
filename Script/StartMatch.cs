using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMatch : MonoBehaviour
{
    
    void Start()
    {
        FindObjectOfType<AudioManager>().DisPlay("StartBefore");
        FindObjectOfType<AudioManager>().Play("BackGround");
        Debug.Log("star");

    }

    
}
