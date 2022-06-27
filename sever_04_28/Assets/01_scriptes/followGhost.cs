using System.Collections;
using UnityEngine;

public class followGhost : MonoBehaviour
{
       SpriteRenderer spriteRenderer;
        private float ghostHp=300;
   private  Transform target;
   private float speed=2;
   private float spawntime;   
   private float time;
   [SerializeField]private GameObject fire;
    void Start()
    {
      Invoke("circleFire",3);
        spriteRenderer = GetComponent<SpriteRenderer>();
        spawntime=Random.Range(9,14);
        target= GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        time+=Time.deltaTime;
        if(time>spawntime)
        {
shot();
 spawntime=Random.Range(8,15);
 time=0;
        }
          if(ghostHp<=0)
      {
        Destroy(gameObject);
      }
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
              StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");  
              PlayerHP.currentHP-=20;

       }
         if(collision.CompareTag("bullet"))
       {
           StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");  
         ghostHp-=playerBullet.bulletdamage;
         score sc = GameObject.Find("score").GetComponent<score>();
         sc.SetScore(sc.GetScore()+20);
       }

    }
    private void shot()
    {
        Instantiate(fire);
     
        
        int radshot=Random.Range(1,4);
       for(int i=0; radshot>i; i++)
        {
            
     Instantiate(fire);
     fire.transform.position=transform.position;
        }
        

    }
    IEnumerator HitColorAnimation()
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.2f);

        spriteRenderer.color = Color.white;
    }
    private IEnumerator circleFire()
    {
      float attackRate=0.5f;
      int count=30;
      float intervalAngle =360/count;
      float weightAngle=0;
      while(true)
      {
        for(int i=0;i<count; ++i){
        GameObject clone = Instantiate(fire,transform.position,Quaternion.identity);
        float angle = weightAngle + intervalAngle*i;
        float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
        float y=Mathf.Sin(angle * Mathf.PI / 180.0f);
        //clone.GetComponent<PlayerMove>().Move(new Vector2(x,y));
      }
      weightAngle+=1;
      yield return new WaitForSeconds(attackRate);
      }
    }
}
