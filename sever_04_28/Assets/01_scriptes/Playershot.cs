using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playershot : MonoBehaviour
{
        Animator animator;
    public GameObject bullet;
    public Transform pos;
    public float currentime;
   public float BulletDistance=0.3f;
  
    void Start(){
        animator=GetComponent<Animator>();
    }
      void Update()
    {
     
    if(currentime<=0)
    { 
     if(Input.GetButtonDown("Fire1"))
        {
           
            
            animator.SetTrigger("shot");
            Instantiate(bullet,pos.position,transform.rotation);  
              currentime=BulletDistance; 
                  
        }
    }
     currentime -=Time.deltaTime;   
    }
  
}
