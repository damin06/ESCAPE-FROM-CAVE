using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerMove : chrachtermove
{
    Animator animator;
    [SerializeField]
    
    private float _jumpSpeed = 8f;

    [SerializeField]

    private float _moveSmooth = 5f;

    [SerializeField]

    private LayerMask  _groundLayer;


    private Collider2D _col = null;
  

    protected override void Start()
    {
        base.Start();
        _col = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

private void Update()
{
    Move();
    Jump();
}

    private void Move()
    {
        float hori = Input.GetAxis("Horizontal");

        _rb.velocity = new Vector2(Mathf.Lerp(_rb.velocity.x , hori * _speed, _moveSmooth * Time.deltaTime), _rb.velocity.y);
        if(hori>0){
        transform.eulerAngles= new Vector3(0,0,0);
         animator.SetBool("run",true);  
    }
    else if(hori<0){
         transform.eulerAngles= new Vector3(0,180,0);
         animator.SetBool("run",true);  
    }
    else
    {
        animator.SetBool("run",false);
    }
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsGround())
        {
            _rb.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
        }
          if(Input.GetKeyDown(KeyCode.UpArrow) && IsGround())
        {
            _rb.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
        }
          if(Input.GetKeyDown(KeyCode.W) && IsGround())
        {
            _rb.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
        }
    }

    private bool IsGround()
    {
        return Physics2D.OverlapBox(transform.position, _col.bounds.size, 0f , _groundLayer);
    }
   

}
