using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotenemy : playerhit
{
  public float speed = 1;
  public GameObject bulletfactory=null;
 
 
 Vector3 vec =Vector3.down;
 public float ran3;
    void Start()
    {
            ran3 =UnityEngine.Random.Range(4,7);
        StartCoroutine(shot());
    }
    private IEnumerator shot(){
        while(true){
     yield return new WaitForSeconds(ran3);
            Instantiate(bulletfactory, transform.position, Quaternion.identity);
            ran3 = UnityEngine.Random.Range(4,7);
        }
    }


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
