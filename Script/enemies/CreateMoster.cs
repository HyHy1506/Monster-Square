using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMoster : MonoBehaviour
{
    [SerializeField] private  GameObject[] Moster;
    [SerializeField] private float[] TimeRange;
    [SerializeField] private float[] nextTime;
    float minX=-6f;
    float maxX=20f;
    float minY=-2f;
    float maxY=11f;
    Vector2 rd;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
       
        if (Time.time > nextTime[0])
        {
            do
            {
                rd.x = Random.Range(minX, maxX);
                rd.y = Random.Range(minY, maxY);
            }
            while ((rd.x > 11 && rd.x < 18) && (rd.y > 0.2 && rd.y < 8));
           
            GameObject moster = Instantiate(Moster[0], rd, Quaternion.identity);
            nextTime[0] = Time.time + TimeRange[0];
        }
        if (Time.time > nextTime[1])
        {
            do
            {
                rd.x = Random.Range(minX, maxX);
                rd.y = Random.Range(minY, maxY);
            }
            while ((rd.x > 11 && rd.x < 18) && (rd.y > 0.2 && rd.y < 8));
            rd.x = Random.Range(minX, maxX);
            rd.y = Random.Range(minY, maxY);
            GameObject moster = Instantiate(Moster[1], rd, Quaternion.identity);
            nextTime[1] = Time.time + TimeRange[1];
        }
        if (Time.time > nextTime[2])
        {
            do
            {
                rd.x = Random.Range(minX, maxX);
                rd.y = Random.Range(minY, maxY);
            }
            while ((rd.x > 11 && rd.x < 18) && (rd.y > 0.2 && rd.y < 8));
            rd.x = Random.Range(minX, maxX);
            rd.y = Random.Range(minY, maxY);
            GameObject moster = Instantiate(Moster[2], rd, Quaternion.identity);
            nextTime[2] = Time.time + TimeRange[2];
        }
        if (Time.time > nextTime[3])
        {
            do
            {
                rd.x = Random.Range(minX, maxX);
                rd.y = Random.Range(minY, maxY);
            }
            while ((rd.x > 11 && rd.x < 18) && (rd.y > 0.2 && rd.y < 8));
            rd.x = Random.Range(minX, maxX);
            rd.y = Random.Range(minY, maxY);
            GameObject moster = Instantiate(Moster[3], rd, Quaternion.identity);
            nextTime[3] = Time.time + TimeRange[3];
        }
    }
}
