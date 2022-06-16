using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class PlayerMove : chrachtermove
{
  [SerializeField]private Transform diepos;
   [SerializeField]private GameObject diepbject;
    public bool Die=false;
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
    followenemy enemyfollow;
  

    protected override void Start()
    {
        enemyfollow = GetComponent<followenemy>();
         spriteRenderer = GetComponent<SpriteRenderer>();
        playerHP = GetComponent<PlayerHP>();
        playershot =GetComponent<Playershot>();
        base.Start();
        _col = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

private void Update()
{
    if(PlayerHP.currentHP<0)
    {
        StartCoroutine("playerdie");
      

    }
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
    if(collision.CompareTag("enemy"))
    {
        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");  
    }

}
IEnumerator HitColorAnimation()
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.5f);

        spriteRenderer.color = Color.white;
    }
    public void Diev()
    {
        
      animator.SetBool("death",true);
    }
     IEnumerator playerdie()
     {  _jumpSpeed=0;
         _speed=0;
         StopCoroutine(Move());
        StopCoroutine(Jump());
     animator.SetBool("death",true);
     yield return new WaitForSeconds(2.5f);
     SceneManager.LoadScene("die");
      Instantiate(diepbject);
      diepbject.transform.position = diepos.transform.position;
      Destroy(gameObject);
    }
}
