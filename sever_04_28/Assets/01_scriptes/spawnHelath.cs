using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnHelath : MonoBehaviour
{
    [SerializeField]private stageData stagedata;
    [SerializeField]private GameObject health;
    [SerializeField]private float spawnMIN;
    [SerializeField]private float spawnMAX;
    // Start is called before the first frame update
    void Start()
    {
    StartCoroutine(spawnHealth());
    }

    // Update is called once per frame
    void Update()   
    {
        
    }
    private IEnumerator spawnHealth()
    {
        while(true)
        {
            float a = Random.Range(spawnMIN,spawnMAX);
              yield return new WaitForSeconds(a);
            float posX=Random.Range(stagedata.LimitMin.x,stagedata.LimitMax.x);
             float posY=Random.Range(stagedata.LimitMin.y,stagedata.LimitMax.y);
             Instantiate(health,new Vector3(posX, posY),Quaternion.identity);
           
        }
    }
}
