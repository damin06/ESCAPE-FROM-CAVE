using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
     private  Transform target;
   private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed=Random.Range(3.5f,3.7f);
        Invoke("Destroyobject",6);
        target= GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
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
             Destroy(gameObject);
              PlayerHP.currentHP-=30;
       }
     }
     private void Destroyobject()
     {
        Destroy(gameObject);
     }
}
