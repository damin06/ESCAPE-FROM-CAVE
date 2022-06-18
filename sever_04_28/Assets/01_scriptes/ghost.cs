using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{
    //[SerializeField]private Transform playerpos;
    private float ghostdamage=20;
    private float ghostHp=10;
 float speed = 3;
    Vector3 dir;
    GameObject playerpos;
    private void Start()
    {
        
      playerpos = GameObject.FindGameObjectWithTag("Player");
      
      
            dir = playerpos.transform.position - transform.position;
            dir.Normalize();

        
     
    }
    void Update()
    {
      if(ghostHp<=0)
      {
        Destroy(gameObject);
      }
         GameObject target = GameObject.Find("Player");
       if(transform.position.x<playerpos.transform.position.x){
transform.eulerAngles= new Vector3(0,0,0);
       }
       else{
        transform.eulerAngles= new Vector3(0,180,0);
       }
        transform.Translate(dir * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
             Destroy(gameObject);
              PlayerHP.currentHP-=ghostdamage;
       }
         if(collision.CompareTag("bullet"))
       {
         ghostHp-=playerBullet.bulletdamage;
         score sc = GameObject.Find("score").GetComponent<score>();
         sc.SetScore(sc.GetScore()+20);
       }

    }
}
