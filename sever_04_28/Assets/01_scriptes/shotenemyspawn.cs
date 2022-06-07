using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotenemyspawn : MonoBehaviour
{
     public GameObject enemyFactory;
    public float spawntime;
    float MinTime=8;
     float MaxTime = 12;
    public float createTime;
    // Start is called before the first frame update
    void Start()
    {
        createTime = UnityEngine.Random.Range(3, 6);        
    }

    // Update is called once per frame
    void Update()
    {
        
        spawntime += Time.deltaTime;
        if(spawntime > createTime)
        {
          GameObject enemy= Instantiate(enemyFactory);
          
        
            enemy.transform.position= transform.position;
           createTime = UnityEngine.Random.Range(MinTime,MaxTime);  
            spawntime = 0;
        }
        
    }
}
