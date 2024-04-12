using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tetstthu : MonoBehaviour
{
    private Action attackAction;
    // Start is called before the first frame update
    void Start()
    {
        attackAction = punch;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)&&Input.GetKey(KeyCode.Space)) { attackAction=sword; }
        else { attackAction=punch; }
        if(Input.GetKeyDown(KeyCode.W) ) { attackAction(); }
    }
    private void punch()
    {
        Debug.Log("punch");
    }
    private void sword()
    {
        Debug.Log("sword");
    }
}
