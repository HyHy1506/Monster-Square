using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using UnityEngine;
using UnityEngine.UI;

public class PlayerMoving : MonoBehaviour
{
    //Player
    [SerializeField] private Joystick JsPlayerMoving;
    [SerializeField] private float Speed = 300f;
    [SerializeField] private float acceleration=10f;
    [SerializeField] private Transform tfPlayer;// ///////////////////////
    [SerializeField]private Rigidbody2D rb;// ////////////////
    [SerializeField] private Animator aniPlayer;
    //Surf
    [SerializeField] private Image imSurf;
    [SerializeField] private float TimeDecreaseSurf;
    [SerializeField] private float TimeIncreaseSurf;
    //ghost
    [SerializeField] private GameObject Ghost;
    [SerializeField ]private float TimeRangeGhost;
    //
    [SerializeField] private float maxHealth=100;
    [SerializeField] private Health health;
    //private
    private float currentHealth;
    private bool isSuft;
    private float valueAcceleration;
    private float nextTimeGhost;
   
 
  
   
    // Start is called before the first frame update
    void Start()
    {
       
        valueAcceleration = 1;
        currentHealth = maxHealth;
        health.SetMaxHealth(maxHealth);
        DataInGame.SetHealth(maxHealth);
        Debug.Log(" health star " + DataInGame.GetHealth());
       
    }

    // Update is called once per frame
   

    private void FixedUpdate()
    {
      
       
        //suft
        Moving();
        //animaton:run,idle,hurt,die,surf
        if (JsPlayerMoving.Horizontal != 0 || JsPlayerMoving.Vertical != 0)
        {
            aniPlayer.SetBool("isRun", true);
        }else if (JsPlayerMoving.Horizontal == 0 && JsPlayerMoving.Vertical == 0)
        {
            aniPlayer.SetBool("isRun", false);
        }
        //animation moving
    }

    private void Moving()
    {
        //surf
        
        if (isSuft)
        { valueAcceleration = acceleration;
            //ANIMATION SURF
            if (Time.time > nextTimeGhost)
            {
                FindObjectOfType<AudioManager>().Play("Surf");
                GameObject aniSurf = Instantiate(Ghost, rb.position, Quaternion.identity);
                if(tfPlayer.localScale.x==-1)
                {
                    aniSurf.transform.localScale = new Vector3(-1,1);
                }else if(tfPlayer.localScale.x == 1)
                {
                    aniSurf.transform.localScale = new Vector3(1, 1);
                }
                Destroy(aniSurf, 1f);
                nextTimeGhost = Time.time + TimeRangeGhost*Time.deltaTime;
            }
            imSurf.fillAmount -= TimeDecreaseSurf * Time.deltaTime;
        }
        if (isSuft == false)
        { 
            valueAcceleration = 1;
            imSurf.fillAmount += TimeIncreaseSurf * Time.deltaTime;
        }
        if (imSurf.fillAmount <= 0)
        {
            isSuft = false;
        }
       

        //moving
        rb.velocity = new Vector2(JsPlayerMoving.Horizontal * Speed * Time.deltaTime * valueAcceleration, JsPlayerMoving.Vertical * Speed * Time.deltaTime * valueAcceleration);
        //save in DataIn Game
        DataInGame.SetValueSD(tfPlayer.position.x, tfPlayer.position.y, tfPlayer.position.z);
        
        //scale
        if (JsPlayerMoving.Horizontal!=  0)
        {if (JsPlayerMoving.Horizontal > 0.01f)
            {
                tfPlayer.localScale = new Vector3(1, 1);
            }
            else { tfPlayer.localScale = new Vector3(-1, 1); }
        }
    } 
    public void TakeDamage(float Damage)
    {
        aniPlayer.SetTrigger("isHurt");
       
        currentHealth -= Damage;
       health.SetHealth(currentHealth);
        DataInGame.SetHealth(currentHealth);
       
        if(currentHealth <= 0) { Die(); }
    }
    private void Die()
    {
        
        FindObjectOfType<AudioManager>().Play("PlayerDie");
        rb.velocity=new Vector2(0, 0);  
        aniPlayer.SetBool("isDie", true);
        GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;
    }
   
    public void suftUp()
    {
        isSuft=false;
      
    }
    public void suftDown() 
    {
        isSuft=true;
      
    }

}
