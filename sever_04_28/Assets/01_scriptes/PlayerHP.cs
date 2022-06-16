using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
  PlayerMove playerMove;
  Animator ani;
   public Image HPbar;
    private float maxHP=100f;
    public static float currentHP;
    void Start()
    {
      playerMove = GetComponent<PlayerMove>();
      ani = GetComponent<Animator>();
        HPbar = GetComponent<Image>();
        currentHP =maxHP;
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.J))
      {
        currentHP-=10;
      }
        HPbar.fillAmount = currentHP / maxHP ;
        if(currentHP <=0)
        {
          //playerMove.Diev();
         // Destroy(gameObject);
        //ani.SetBool("death",true);
        }
    }
    public void HPdamager(float damage)
    {
      if(currentHP>0)
      {
      currentHP-=damage;
      }
    }
}
