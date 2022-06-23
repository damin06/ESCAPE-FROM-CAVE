using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chrachtermove : MonoBehaviour
{

protected Rigidbody2D _rb=null;

 [SerializeField]
 protected  float _speed = 5;
 public bool isFacingRight{get; private set; }=false;
protected virtual void Start(){
    _rb=GetComponent<Rigidbody2D>();
}
 private void ChangeFacing()
    {
        if(_rb.velocity.x >= 0.1f)
        {
            isFacingRight = true;
        }
        else
        {
            isFacingRight = false;
        }
    }
}
