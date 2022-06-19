using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class playerBullet : MonoBehaviour
{
  public static float bulletdamage=10;
    Vector3 vec = Vector3.right;
      public int speed=20;
       Vector3 uv =Vector3.up;
    // Start is called before the first frame update
    void Start()
    {
    Invoke("DestroyBullet",2.5f);
    }

    // Update is called once per frame
    void Update()
    {
           if(transform.rotation.y==0)
        {
          //doleft();
          //transform.DOMove(Vector3.right,25);
      transform.position+=vec*10*Time.deltaTime;
      //transform.position+=uv*7*Time.deltaTime;
        }
        else
        {
          //doright();
          //transform.eulerAngles= new Vector3(0,180,0);
           //transform.position+=uv*7*Time.deltaTime;
transform.position+=vec*-1*10*Time.deltaTime;
        }
    }
    private void doleft()
    {
      transform.DOMove(vec,25);
    }
    private void doright()
    {
transform.DOMove(-vec,25);
    }
    void DestroyBullet()
    {
      Destroy(gameObject);
    }
  
    private void OnTriggerEnter2D(Collider2D other)
    {
      Destroy(gameObject);
      if(other.gameObject.CompareTag("enemy"))
      {
        //Destroy(other.gameObject);
      }
    }
}
