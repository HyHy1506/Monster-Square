using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Sword : MonoBehaviour
{
    [SerializeField] private float MakeDaamage = 50;
    //
    [SerializeField] private float swordRadius;
    [SerializeField] private Image imSword;
    [SerializeField] private Transform tfPointSword;
    [SerializeField] private float TimeRange;
    //
    [SerializeField] private Collider2D collSword;
    [SerializeField] private Transform SwordPos;
    [SerializeField] private Rigidbody2D rbSwordPos;
    [SerializeField] private Transform PointPlayer;
    [SerializeField] private LayerMask lmEnemies;
    [SerializeField] private RotatingFollow rf;
    //joystick
    [SerializeField] private Joystick jsMoving;
    private Animator ani;
    private bool isSowrd;
    private int startCountTime=2;
    Vector2 oldpos;
    bool isEnable = true;
    // Start is called before the first frame update
    void Start()
    {
        collSword.enabled = false;
        oldpos=jsMoving.Direction;
        ani= GetComponent<Animator>();
      isEnable= true;
        SwordPos.transform.position = PointPlayer.transform.position;

    }

    // Update is called once per frame
   
    private void FixedUpdate()
    {
        //disable Sword
        if (DataInGame.GetHealth() > 0)
        {
            isEnable = true;
           
        }
        else { 
            isEnable = false;

        }

        if (isEnable == true)
        {
            //move follow player
            MoveAndScale();
            //processed attack
            if (isSowrd && startCountTime == 0)
            { //animation attack
                ani.SetTrigger("StartAttack");
                //sound
                FindObjectOfType<AudioManager>().Play("Sword");
                //attack
                Attack();
                //
                isSowrd = false;
                startCountTime = 1;
            }
            if (startCountTime == 1)
            {
                imSword.fillAmount -= TimeRange * Time.deltaTime;

                if (imSword.fillAmount == 0) { imSword.fillAmount = 1; }
            }
            if (imSword.fillAmount == 1)
            {
                startCountTime = 0;
            }

        }
    }
    private void Attack()
    {
        if (isEnable == true)
        {
            Collider2D[] DetectEnemies = Physics2D.OverlapCircleAll(tfPointSword.position, swordRadius, lmEnemies);
            foreach (Collider2D enemy in DetectEnemies)
            {
                //take damage
                if (enemy == null)
                {
                    Debug.Log("enemy bij null");
                    return;
                }
                enemy.GetComponent<enemies>().TakeDamage(MakeDaamage);
            }
        }
    }
    private void MoveAndScale()
    {
        //rotating
        if (jsMoving.Horizontal != 0 || jsMoving.Vertical != 0)
        {
           float angle= rf.rotateFollow(oldpos, jsMoving.Direction);
            rbSwordPos.rotation = angle;
        }
        //follow position player
        SwordPos.transform.position = PointPlayer.transform.position;
        //sacle sword by scale player
        if (PointPlayer.transform.localScale.x == -1)
        {
            SwordPos.transform.localScale = new Vector3(-1, 1);
        }
        else
        {
            SwordPos.transform.localScale = new Vector3(1, 1);
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(tfPointSword.position, swordRadius);
    }

    public void swordDown()
    {
        isSowrd = true;
    }
    public void eventDisableSword() { collSword.enabled = false; }
    public void eventEnableSword() { collSword.enabled = true; }
}
