using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class right_enemy : MonoBehaviour
{
    
public float speed = 3;
      Vector3 dir=Vector3.right;
      [SerializeField]
      private float gatoHP=10;
      [SerializeField]
      private float gatodamager=30;
   
void Start()
{
transform.eulerAngles= new Vector3(0,180,0);
}
  
 public void OnTriggerEnter2D(Collider2D other)
    {
       if(other.CompareTag("bullet"))
       {
         gatoHP-=playerBullet.bulletdamage;
       }
       if(other.CompareTag("Player"))
       {
        PlayerHP.currentHP-=gatodamager;
       }
    } 
 
void Update()
    {
        if(gatoHP<=0){
            Destroy(gameObject);
        }
      transform.position += dir*speed*Time.deltaTime;
    }
}
