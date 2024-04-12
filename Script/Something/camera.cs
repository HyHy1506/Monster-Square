using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
   public Transform camerapos;
    public Transform player;
    Vector2 a;
    // Start is called before the first frame update
    private void LateUpdate()
    {
     
        
        camerapos.transform.position = new Vector3(player.position.x, player.position.y, -100);
    }
}
