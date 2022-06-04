using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : playerhit
{
 public float speed = 5;
 Vector3 vec =Vector3.down;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+=vec*speed*Time.deltaTime;
    }
    protected override void Dead()
    {
        Debug.Log("사망");
        
       
        //Destroy(gameObject);

    }
  
 public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
        base.Dead();
        Dead();
        }
               
    }
   
}
