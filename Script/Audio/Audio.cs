using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource audi;
    

    // Update is called once per frame
    void Update()
    {
        audi.volume = DataPlayer.GetMusic();
    }
}
