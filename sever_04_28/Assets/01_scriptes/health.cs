using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    private float he;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
         if(other.gameObject.CompareTag("Player"))
               he=Random.Range(15,35);
        PlayerHP.currentHP+=he;
        Destroy(gameObject);

      }
    }

