using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class followenemy : MonoBehaviour
{
    PlayerHP playerHP;
    Animator animator;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float movespeed;
    int rnadomwait; 
    Rigidbody2D rb2d;
    private float curtime;
    GameObject playerpos;
    [SerializeField]
    private float damage=5;
    [SerializeField]
    private float enemyHP=10;
    
    // Start is called before the first frame update
    void Start()
    {
       playerHP=GetComponent<PlayerHP>();
        playerpos = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
       rnadomwait= Random.Range(1,3);
       animator.SetTrigger("spawn");
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHP<=0)
        {
            Destroy(gameObject);
        }
        curtime+=Time.deltaTime;
        
        float distoplayer = Vector2.Distance(transform.position,playerpos.transform.position);
        if(distoplayer<agroRange && curtime>1)
        {
          StartCoroutine(ChasePlayer());
          StopCoroutine(SotpChase());
        }
        else
        {
        StopCoroutine(ChasePlayer());
         StartCoroutine(SotpChase());
        }     
    }
    IEnumerator ChasePlayer()
    {
     if(transform.position.x<playerpos.transform.position.x)
     {
      rb2d.velocity = new Vector3(movespeed,0);  
       //transform.eulerAngles= new Vector3(0,0,0);
      transform.eulerAngles = new Vector3(0,180,0);       
     }
     else
     {
          //transform.eulerAngles= new Vector3(0,180,0);
          rb2d.velocity = new Vector3(-movespeed,0);
          transform.eulerAngles = new Vector3(0,0,0);    
     }
     yield return null;
    }
    IEnumerator SotpChase()
    {
       rb2d.velocity = new Vector3(0,0,0);
       yield return null;
    }
    IEnumerator randomfollow()
    { if(transform.position.x<playerpos.transform.position.x)
     {
         transform.eulerAngles= new Vector3(0,0,0);
     }
         rb2d.velocity = new Vector2(rnadomwait,0);
        Vector3 vce = Vector3.right;
     yield return new WaitForSeconds(1);
      transform.eulerAngles= new Vector3(0,180,0);
    }
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("bullet")){
           enemyHP-=playerBullet.bulletdamage;
        }
      if(collision.CompareTag("Player"))
      {
        PlayerHP.currentHP-=damage;
        //collision.GetComponent<PlayerHP>().HPdamager(damage);
      
      }
    }
}
