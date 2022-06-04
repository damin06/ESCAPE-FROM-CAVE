using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c : playerhit
{
    
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
}
