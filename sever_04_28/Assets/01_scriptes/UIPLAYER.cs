using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPLAYER : MonoBehaviour
{
    [SerializeField]private Image a;
    [SerializeField]private Image b;
   
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHP.currentHP<=50)
        {
          a.gameObject.SetActive(false);
          b.gameObject.SetActive(true);
        }
    }
 
}
