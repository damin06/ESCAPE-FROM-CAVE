using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playershot : MonoBehaviour
{
    public bool reroled=false;
  PlayerMove playerMove;
        Animator animator;
    public GameObject bullet;
    public Transform pos;
    public float currentime;
   public float BulletDistance=0.3f;
   int bulletmin=8;
   int bulletmax=8;
  public Text bullettxt;
  public bool shot=false;
  
  
    void Start(){
    
        animator=GetComponent<Animator>();
        playerMove=GetComponent<PlayerMove>();
      

    }
      void Update()
    {
        gamepause pu = GameObject.Find("gamepause").GetComponent<gamepause>();
      if(gamepause.ispause==false){
      bullettxt.text=bulletmin + "/8";
     if(Input.GetKeyDown(KeyCode.R))
     {
StartCoroutine(rebullet());
     }
    if(currentime<=0)
    { 
     if(Input.GetButtonDown("Fire1"))
        {
          
           if(bulletmin>0)
           {
              bulletmin--;
            StartCoroutine(bulletfire());
           }
           else
           {
            StopCoroutine(bulletfire());
           }
                  
        }
    }
    
     currentime -=Time.deltaTime;   
      }
    }
  IEnumerator bulletfire()
  {
    shot=true;
 animator.SetTrigger("shot");
            Instantiate(bullet,pos.position,transform.rotation);  
              currentime=BulletDistance;             
      yield return new WaitForSeconds(0.3f);
      shot=false;
  }
  IEnumerator rebullet()
  {
 reroled=true;
 animator.SetTrigger("rero");
 animator.SetBool("run",false);
    yield return new WaitForSeconds(0.9f);
    bulletmin=8;
    reroled=false;
  }
}
