using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftenemy : playerhit
{
  
    public float speed = 3;
      Vector3 dir=Vector3.left;
   
protected override void Dead()
    {
        Debug.Log("사망");
        
   

    }
  
 public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
        base.Dead();
        Dead();
        }
    } 
 
void Update()
    {
      transform.position += dir*speed*Time.deltaTime;
        
    }
    
}

