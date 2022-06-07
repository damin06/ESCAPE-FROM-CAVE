using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : playerhit
{
 
 Vector3 dir;
    public float speed = 4;
   
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
  void Start()
    {
        int randomvalve = UnityEngine.Random.Range(0, 10);

        if (randomvalve < 4)
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }
    void Update()
    {
      transform.position += dir*speed*Time.deltaTime;
        
    }
    
}
