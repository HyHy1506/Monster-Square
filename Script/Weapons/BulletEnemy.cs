using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public GameObject BulletFX;
    public Transform tfBullet;
    public float damage=10f;
    // Start is called before the first frame update
    void Start()
    {
        
        tfBullet = GetComponent<Transform>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies") == false)
        {
            if (collision.gameObject.CompareTag("MosterPos") == false)
            {
                GameObject createbulletFX = Instantiate(BulletFX, tfBullet.position, tfBullet.rotation);
                if (createbulletFX == null)
                {
                    Debug.Log("create fx bullet is null");
                    return;
                }
                Destroy(createbulletFX, 1f);
                if (collision.gameObject.CompareTag("Player"))
                {
                    
                }

                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null)
        {
            Debug.Log("collision is null");
            return;
        }
        if (collision.gameObject.CompareTag("EnemiesGun") == false)
        { 
        if (collision.gameObject.CompareTag("Enemies") == false)
        {
            if (collision.gameObject.CompareTag("MosterPos") == false)
            {
                GameObject createbulletFX = Instantiate(BulletFX, tfBullet.position, tfBullet.rotation);
                if (createbulletFX == null)
                {
                    Debug.Log("create fx bullet is null");
                    return;
                }
                Destroy(createbulletFX, 1f);
                if (collision.gameObject.CompareTag("Player"))
                {
                    collision.GetComponent<PlayerMoving>().TakeDamage(damage);
                }

                Destroy(gameObject);
            }
        }
    }
    }
}
