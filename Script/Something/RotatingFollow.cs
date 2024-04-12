using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingFollow : MonoBehaviour
{
   public float rotateFollow(Vector2 star,Vector2 end)
    { 
        Vector2 direction= end-star;
        float angle=Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg-90;
        return angle; 
    }
}
