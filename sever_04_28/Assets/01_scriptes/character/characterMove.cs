using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chrachtermove : MonoBehaviour
{
      //[RequireComponent(typeof(Rigidbody2D))]
protected Rigidbody2D _rb=null;

 [SerializeField]
 protected  float _speed = 10f;
 public bool isFacingRight{get; private set; }=false;
protected virtual void Start(){
    _rb=GetComponent<Rigidbody2D>();
}
 private void ChangeFacing()
    {
        if(_rb.velocity.x >= 0.1f)
        {
            isFacingRight = true;
            //방향을 오른쪽으로 보는 코드
        }
        else
        {
            isFacingRight = false;
        }
    }
}
