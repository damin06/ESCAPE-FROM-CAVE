using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followenemy : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float movespeed;
    int rnadomwait; 
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
       rnadomwait= Random.Range(1,3);
    }

    // Update is called once per frame
    void Update()
    {
        float distoplayer = Vector2.Distance(transform.position,player.position);
        if(distoplayer<agroRange)
        {
          ChasePlayer();
          
        }
        else
        {
         SotpChase();
        }
    }
    void ChasePlayer()
    {
     if(transform.position.x<player.position.x)
     {
      rb2d.velocity = new Vector2(movespeed,0);  
       //transform.eulerAngles= new Vector3(0,0,0);
      transform.eulerAngles = new Vector2(1,1);       
     }
     else
     {
          //transform.eulerAngles= new Vector3(0,180,0);
          rb2d.velocity = new Vector2(-movespeed,0);
          transform.eulerAngles = new Vector2(-1,1);    
     }
    }
    void SotpChase()
    {
       rb2d.velocity = new Vector2(0,0);
    }
    IEnumerator randomfollow()
    { if(transform.position.x<player.position.x)
     {
         transform.eulerAngles= new Vector3(0,0,0);
     }
         rb2d.velocity = new Vector2(rnadomwait,0);
        Vector3 vce = Vector3.right;
     yield return new WaitForSeconds(1);
      transform.eulerAngles= new Vector3(0,180,0);
    }
}
