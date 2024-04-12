using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class enemieGun : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject MosterPoint;
    [SerializeField] private GameObject BulletEnemy;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Health heathBar;
    [SerializeField] private RotatingFollow rf;
    [SerializeField] private float ForceBullet = 5f;
    [SerializeField] private float MaxHealth = 100;
    [SerializeField] private float Speed;
    [SerializeField] private float distanceRange;
    [SerializeField] private float radiousRange;
    [SerializeField] private float TimeRange;
    [SerializeField] private float Horizontal;
    [SerializeField] private float Vertical;
    [SerializeField] private float Damage;
    //Themself
    private Transform tfMoster;
    private Animator aniMoster;
    //point
     Transform tfMosterPoint;
    //info detail
    private float currentHealth;
    private float nextTime;
    private Vector3 angleBullet;
    private bool isDie = false;
    //player
    Transform tfPlayer;

    // Start is called before the first frame update
    void Start()
    {
     //moster
     aniMoster= GetComponent<Animator>();
     tfMoster=GetComponent<Transform>();
     tfMosterPoint=MosterPoint.GetComponent<Transform>();
     //player
     tfPlayer=Player.GetComponent<Transform>();
    //detail info something
     currentHealth = MaxHealth;
     heathBar.SetMaxHealth(currentHealth);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDie == false)
        {
            Moving();
            AnimationEnemies();
            Attack();
        }
        if (isDie)
        {
            Die();
        }

    }
    //different

    private void Attack()
    {
        //***************MOSTER USE FIGHT************************
        if (gameObject.CompareTag("Enemies"))
        {
            if (Vector2.Distance(tfMoster.position, tfPlayer.position) < distanceRange)
            {
                if (Time.time > nextTime)
                {
                    aniMoster.SetBool("isAttack", true);
                    nextTime = Time.time + TimeRange;
                }
            }
        }

        //****************MOSTER USE GUN*********************
        else if (gameObject.CompareTag("EnemiesGun"))
        {
            if (Vector2.Distance(tfMoster.position, tfPlayer.position) < distanceRange)
            {
                if (Time.time > nextTime)
                {
                    //shoot bullet
                    float angle = rf.rotateFollow(tfMoster.position, tfPlayer.position);
                    angleBullet.z = angle;
                    angleBullet.x = 0;
                    angleBullet.y = 0;

                    tfMosterPoint.rotation = Quaternion.Euler(angleBullet);
                    GameObject createBulletEnemy = Instantiate(BulletEnemy, tfMosterPoint.position, tfMosterPoint.rotation);

                    Rigidbody2D rbBullet = createBulletEnemy.GetComponent<Rigidbody2D>();

                    rbBullet.AddForce(tfMosterPoint.up * ForceBullet, ForceMode2D.Impulse);
                    //
                    Debug.Log(tfMosterPoint.up);
                    // aniMoster.SetBool("isAttack", true);  -no need animation attack because it are not have 
                    nextTime = Time.time + TimeRange;
                }
            }
        }
    }
    //different

    public void eventAttack()
    {
        if (isDie == false)
        {
            //***************MOSTER USE FIGHT************************
            if (gameObject.CompareTag("Enemies"))
            {
                Collider2D[] hitPlayer = Physics2D.OverlapBoxAll(tfMosterPoint.position, new Vector2(Horizontal, Vertical), 0, layerMask);
                foreach (Collider2D player in hitPlayer)
                {
                    Debug.Log("hit player");
                    player.GetComponent<PlayerMoving>().TakeDamage(Damage);
                }
            }  //****************MOSTER USE GUN*********************
            else
            { return; }
        }
    }
    private void AnimationEnemies()
    {
        aniMoster.SetBool("isRun", true);
    }
    private void Moving()
    {

        //scale
        if (tfPlayer.position.x < tfMoster.position.x) { tfMoster.localScale = new Vector3(-1, 1); }
        else
        if (tfPlayer.position.x > tfMoster.position.x) { tfMoster.localScale = new Vector3(+1, 1); }
        //moving
        // rbEnemyPos.velocity= Vector2.MoveTowards(tfEnemyPos.position, tfPlayerPos.position, Speed * Time.deltaTime);
        tfMoster.position = Vector2.MoveTowards(tfMoster.position, tfPlayer.position, Speed * Time.deltaTime);

    }

    public void TakeDamage(float damage)
    {
        if (isDie == false)
        {
            aniMoster.SetTrigger("Hurt");
            currentHealth -= damage;
            heathBar.SetHealth(currentHealth);
            Debug.Log("heath" + currentHealth);
            if (currentHealth <= 0)
            {
                isDie = true;
                nextTime = Time.time + 4;
            }
        }
    }

    private void Die()
    {
        GetComponent<SpriteRenderer>().sortingLayerName = "Death";
        GetComponent<BoxCollider2D>().enabled = false;
      
        aniMoster.SetBool("Die", true);

        if (Time.time > nextTime)
        {
            Destroy(gameObject);
        }
    }
    //different
    private void OnDrawGizmos()
    {
        if (MosterPoint.transform.position == null)
        {
            Debug.Log("mosterpoint tranform null");
            return;
        }
        //***************MOSTER USE FIGHT************************
        if (gameObject.CompareTag("Enemies"))
        {
            
            Gizmos.DrawWireCube(MosterPoint.transform.position, new Vector3(Horizontal, Vertical));
        }
        //****************MOSTER USE GUN*********************
        else if (gameObject.CompareTag("EnemiesGun"))
        {
            Gizmos.DrawWireSphere(MosterPoint.transform.position, distanceRange);
        }
    }
}
