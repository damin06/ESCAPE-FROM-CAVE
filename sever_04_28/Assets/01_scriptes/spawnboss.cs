using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnboss : MonoBehaviour
{
  [SerializeField]private  GameObject boss;
    private float timespawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timespawn+=Time.deltaTime;
        if(timespawn>120)
        {
            timespawn=0;
Instantiate(boss);
boss.transform.position=transform.position;
        }
    }

}
