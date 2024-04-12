using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().DisPlay("BackGround");
        FindObjectOfType<AudioManager>().Play("StartBefore");
        Debug.Log("MainMenu");

    }


}
