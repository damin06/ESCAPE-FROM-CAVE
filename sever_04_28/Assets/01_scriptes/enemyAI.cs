using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
 [SerializeField] LayerMask isLayer;
   [SerializeField]private float speed=6;
 [SerializeField]int rad;
 [SerializeField]float  wiatrad;
 Rigidbody2D ri;
 //public Transform playerpos;
 bool isfollow= false;
 void Update()
 {
//  RaycastHit2D ray= Physics2D.Raycast(transform.position,transform.right,isLayer);
//         if(ray.collider != null)
//         {
            
         
//             if(ray.collider.CompareTag("Bullet")){
//                 Destroy(gameObject);
//             }
            
            
//         }
 }
    void Start()
    {
    //StartCoroutine("changemove");
StartCoroutine("enemyai");
    }
void Awake(){
    ri= GetComponent<Rigidbody2D>();
}
    void FixedUpdate(){
        
 ri.velocity= new Vector2(rad,ri.velocity.y);

    }
    IEnumerator enemyai(){
        rad = Random.Range(-1,2);
         wiatrad =Random.Range(1,3);
        yield return new WaitForSeconds(wiatrad);
      StartCoroutine("enemyai");
    }
    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
        wrkxek();
         
        }
    }
    // void OntriggerEnter2D(CircleCollider2D other){
    //     if(other.gameObject.CompareTag("Player")){
    //       StopCoroutine("enemyai");
    //       Destroy(other.gameObject);
    //       isfollow=true;
         
    //     }
    // }
    public void wrkxek(){
      Destroy(gameObject);
    }
   
//     void OntriggerStay2D(CircleCollider2D other)
//     {
//        if(other.gameObject.CompareTag("Player"))
//         {
         
//         }
//     }
//     void OntriggerExit2D(CircleCollider2D other)
//     {
//      if(other.gameObject.CompareTag("Player"))
//        {
//           StartCoroutine("enemyai");
//           isfollow=false;
//        }
//     }
//     void follow()
//     {
//   GameObject taget = GameObject.Find("Player");
//   Vector3 dir=transform.position -playerpos.transform.position;
//   dir.Normalize();
//   transform.position+= dir*speed*Time.deltaTime;
//     }
//   IEnumerator changemove()
//   {
//        vec = Vector3.zero;
//       int movement;
//       movement = Random.Range(0,3); 
//       if (movement==0){
//     transform.eulerAngles= new Vector3(0,0,0);
//       }
//       else if (movement==1){
//           transform.eulerAngles= new Vector3(0,180,0);   
//       }
//       else{
//           yield return new WaitForSeconds(1f);
//       }
      
       
// yield return new WaitForSeconds(1f);
// StartCoroutine("changemove");
//   }
}
