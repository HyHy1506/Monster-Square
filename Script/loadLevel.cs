using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLevel : MonoBehaviour
{
    public Animator transition;
    public float waitTime=1f;
    void Update()
    {
        //if(Input.GetKey(KeyCode.Space)) 
        //{
        //    Load();
        //}
       
    }
    public void Load()
    {
        StartCoroutine(loadnextLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator loadnextLevel(int load)
    {
        //play animation
        transition.SetTrigger("start");
        //wait animation end
        yield return new WaitForSeconds(waitTime);
        //load new scene
        SceneManager.LoadScene(load);
    }
}
