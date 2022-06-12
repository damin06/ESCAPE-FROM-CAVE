using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerMove : chrachtermove
{
     SpriteRenderer spriteRenderer;
    PlayerHP playerHP;
 Playershot playershot;
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
         spriteRenderer = GetComponent<SpriteRenderer>();
        playerHP = GetComponent<PlayerHP>();
        playershot =GetComponent<Playershot>();
        base.Start();
        _col = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

private void Update()
{
    if(playershot.reroled==true || playershot.shot==true){
      Debug.Log("재장전");
        StopCoroutine(Move());
        StopCoroutine(Jump());
    }
    else
    {
       StartCoroutine(Move());
        StartCoroutine(Jump());
    }
   
}

     public IEnumerator Move()
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
    yield return null;
    }

    private IEnumerator Jump()
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
        yield return null;
    }

    private bool IsGround()
    {
        return Physics2D.OverlapBox(transform.position, _col.bounds.size, 0f , _groundLayer);
    }
private void OnTriggerEnter2D(Collider2D collision)
{
   StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");
}
IEnumerator HitColorAnimation()
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.5f);

        spriteRenderer.color = Color.white;
    }
}
