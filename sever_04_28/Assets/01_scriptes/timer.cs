using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    [SerializeField]private Text current_text;
    private float set_time=60;
    public float m=2;
      [SerializeField]private Image a;
   
    private float time;
    private float f_time=1;
    void Start()
    {
       
  gamestart();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHP.currentHP<=0)
        {
            lostgame();
        }
        set_time-=Time.deltaTime;
        if(set_time<9)
        {
            current_text.text=m+":"+"0"+Mathf.Round(set_time).ToString();
        }
        else
        {
           current_text.text=m+":"+Mathf.Round(set_time).ToString();
        }
        
        if(set_time<0)
        {
        m-=1;
        set_time=60;
        }

        if(m<0)
        {
           StartCoroutine(fade());
        StartCoroutine(wingame());
        }
    }
    IEnumerator wingame()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("win");
    }
    
    private void gamestart()
    {
         a.gameObject.SetActive(true);
        StartCoroutine(startgame());
    }
    public void lostgame()
    {
StartCoroutine(fade());
StartCoroutine(losegame());
    }
    IEnumerator losegame()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("die");
    }
    IEnumerator fade()
    {
        time=0;
        a.gameObject.SetActive(true);
        Color alpha=a.color;
        while(alpha.a<1)
        {
            time+=Time.deltaTime / f_time;
            alpha.a=Mathf.Lerp(0,1,time);
            a.color=alpha;
            yield return null;
        }
         yield return null;
  
    }
    IEnumerator startgame()
    {
        time=0;
           Color alpha=a.color;
         while(alpha.a>0)
        {
            time+=Time.deltaTime / f_time;
            alpha.a=Mathf.Lerp(1,0,time);
            a.color=alpha;
            yield return null;
        }
         yield return null;
        a.gameObject.SetActive(false);
    }
    
}
