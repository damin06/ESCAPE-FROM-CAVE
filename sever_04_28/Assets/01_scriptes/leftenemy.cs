using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftenemy : playerhit
{
    public float speed = 3;
      Vector3 dir=Vector3.left;
   [SerializeField]
    private float gatoHP=10;
    [SerializeField]
      public float gatodamager=30;
      private void Start()
      {
        transform.eulerAngles= new Vector3(0,180,0);
      }
protected override void Dead()
    {
        Debug.Log("사망");
        
   

    }
  
 public void OnTriggerEnter2D(Collider2D other)
    {
       if(other.CompareTag("bullet"))
       {
         gatoHP-=playerBullet.bulletdamage;
         score sc = GameObject.Find("score").GetComponent<score>();
         sc.SetScore(sc.GetScore()+10);
       }
       if(other.CompareTag("Player"))
       {
        PlayerHP.currentHP-=gatodamager;
       }
    } 
 
void Update()
    {
      transform.position += dir*speed*Time.deltaTime;
          if(gatoHP<=0){
            Destroy(gameObject);
        }
    }
    
}

