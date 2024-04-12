using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject BulletFX;
    private Transform tfBullet;
    float damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = 50;
        tfBullet= GetComponent<Transform>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")==false)
        {
            if (collision.gameObject.CompareTag("Enemies") )
            {
                
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == false)
        {
            if (collision.gameObject.CompareTag("MosterPos") == false)
            {
                GameObject createbulletFX = Instantiate(BulletFX, tfBullet.position, tfBullet.rotation);
                if (createbulletFX == null)
                {
                    Debug.Log("create fx bullet is null");
                    return;
                }
                if(collision== null)
                {
                    Debug.Log("collision null");
                    return;
                }
                if (collision.gameObject.CompareTag("Enemies"))
                {
                    collision.GetComponent<enemies>().TakeDamage(damage);
                }
                if(collision.gameObject.CompareTag("EnemiesGun"))
                {
                    collision.GetComponent<enemies>().TakeDamage(damage);
                }
                

                Destroy(createbulletFX, 1f);
                Destroy(gameObject);
            }
        }
    }
}
