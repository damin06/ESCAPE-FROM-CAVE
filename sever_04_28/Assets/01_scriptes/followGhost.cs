using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followGhost : MonoBehaviour
{
        private float ghostHp=200;
   private  Transform target;
   private float speed=3;
   private float spawntime;   
   private float time;
   [SerializeField]private GameObject fire;
    void Start()
    {
        spawntime=Random.Range(9,14);
        target= GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        time+=Time.deltaTime;
        if(time>spawntime)
        {
shot();
 spawntime=Random.Range(8,15);
 time=0;
        }
          if(ghostHp<=0)
      {
        Destroy(gameObject);
      }
        transform.position= Vector2.MoveTowards(transform.position,target.position,speed*Time.deltaTime);
               if(transform.position.x<target.transform.position.x){
transform.eulerAngles= new Vector3(0,0,0);
       }
       else{
        transform.eulerAngles= new Vector3(0,180,0);
       }
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
        
              PlayerHP.currentHP-=20;
       }
         if(collision.CompareTag("bullet"))
       {
         ghostHp-=playerBullet.bulletdamage;
         score sc = GameObject.Find("score").GetComponent<score>();
         sc.SetScore(sc.GetScore()+20);
       }

    }
    private void shot()
    {
        Instantiate(fire);
     
        int i=0;
        int radshot=Random.Range(1,4);
        while(radshot>i)
        {
            i++;
     Instantiate(fire);
     fire.transform.position=transform.position;
        }
        

    }
}
