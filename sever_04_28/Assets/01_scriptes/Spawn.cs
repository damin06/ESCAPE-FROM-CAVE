using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{    public Transform maxPos = null;
    public Transform minPos = null;
    public  GameObject enemy;
        public  GameObject enemy2;
    public float currentime;
    public float rand;
    public float spawntime;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
         StartCoroutine(SpawnEnemy2());
    }
private IEnumerator SpawnEnmy()
    {      
        yield return null;
    }
    private IEnumerator SpawnEnmy2()
    {      
        yield return null;
    }
    private IEnumerator SpawnEnemy()
    {
       rand =UnityEngine.Random.Range(1,3);
        
        while(true){
            yield return new WaitForSeconds(rand);
          Instantiate(enemy, new Vector2(Random.Range(minPos.position.x, maxPos.position.x), maxPos.position.y), enemy.transform.rotation);
            yield return null;
          rand =UnityEngine.Random.Range(1,3);
         
  
        }
 
        }
         private IEnumerator SpawnEnemy2()
    {
       rand =UnityEngine.Random.Range(2,5);
        
        while(true){
            yield return new WaitForSeconds(rand);
          Instantiate(enemy2, new Vector2(Random.Range(minPos.position.x, maxPos.position.x), maxPos.position.y), enemy.transform.rotation);
            yield return null;
          rand =UnityEngine.Random.Range(2,5);
         
  
        }
 
        }
    

    }

