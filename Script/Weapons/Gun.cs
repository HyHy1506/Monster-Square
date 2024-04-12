using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform tfGunPos;
    [SerializeField] private Rigidbody2D rbGunPos;
    [SerializeField] private Transform tfGun;
    [SerializeField] private Transform tfPointGun;
    [SerializeField] private Transform tfPlayer;
    [SerializeField] private RotatingFollow rf;
    [SerializeField] private Joystick jsGun;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private float ForceBullet = 5;
    [SerializeField] private float TimeRange;
    [SerializeField] private GameObject ShootFX;
    private float nextTime;
    Vector2 oldpos;
    bool isEnable = true;
    
    // Start is called before the first frame update
    void Start()
    {
        oldpos = jsGun.Direction;
        tfGunPos.position = new Vector3(tfPlayer.position.x - 1, tfPlayer.position.y + 0.7f, tfGun.position.z);
        isEnable= true;
    }

    // Update is called once per frame
    void Update()
    {
        //disable Gun
        if (DataInGame.GetHealth() > 0)
        {
            isEnable = true;
            
        }
        else
        {
            
            isEnable = false; }
            if (isEnable)
        {
            // fire bullet
            if (jsGun.Horizontal != 0 || jsGun.Vertical != 0)
            {
                Attack();
            }
        }
    }
    private void FixedUpdate()
    {if (isEnable)
        {
            //moving
            tfGunPos.position = new Vector3(tfPlayer.position.x - 1, tfPlayer.position.y + 0.7f, tfGun.position.z);
            //rotation
            if (jsGun.Horizontal != 0 || jsGun.Vertical != 0)
            {
                float angle = rf.rotateFollow(oldpos, jsGun.Direction);
                rbGunPos.rotation = angle;
            }
        }
    }
    private void Attack()
    {
        if (isEnable)
        {
            if (Bullet == null)
            {
                Debug.Log("null bullet");
                return;
            }
            if (Time.time > nextTime)
            {
                GameObject createShootFX = Instantiate(ShootFX, tfPointGun.position, tfPointGun.rotation);
                FindObjectOfType<AudioManager>().Play("Shoot");
                Destroy(createShootFX, 1f);
                GameObject FireBullet = Instantiate(Bullet, tfPointGun.position, tfPointGun.rotation);
                Rigidbody2D rbBullet = FireBullet.GetComponent<Rigidbody2D>();
                rbBullet.AddForce(tfPointGun.up * ForceBullet, ForceMode2D.Impulse);
                nextTime = Time.time + TimeRange + Time.deltaTime;
            }
        }
    }
}
