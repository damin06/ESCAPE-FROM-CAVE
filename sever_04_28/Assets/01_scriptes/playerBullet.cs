using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour
{
    Vector3 vec = Vector3.right;
      public int speed=20;
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
      transform.position+=vec*10*Time.deltaTime;
        }
        else
        {
transform.position+=vec*-1*10*Time.deltaTime;
        }
    }
    void DestroyBullet()
    {
      Destroy(gameObject);
    }
}
