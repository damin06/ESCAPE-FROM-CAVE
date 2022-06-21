using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startsceen : MonoBehaviour
{
  [SerializeField]private AudioSource music;
  [SerializeField]private GameObject optoinobject;
  [SerializeField]private Image a;
    private float time;
    private float f_time=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void bnstart()
   {
    StartCoroutine(fade());
      
    }
      IEnumerator fade()
    {

        a.gameObject.SetActive(true);
        Color alpha=a.color;
        while(alpha.a<1)
        {
            time+=Time.deltaTime / f_time;
            alpha.a=Mathf.Lerp(0,1,time);
            a.color=alpha;
            yield return null;
        }
         yield return new WaitForSeconds(1);
           SceneManager.LoadScene("Play");
  
    }
     public void quit()
 {
   #if UNITY_EDITOR
   UnityEditor.EditorApplication.isPlaying=false;
   #else
   Application.Quit();
   #endif
 }
 public void option()
 {
  optoinobject.SetActive(true);
 }
     public void startsound(float Volume1)
   {
      Volume1 =PlayerPrefs.GetFloat("vo",Volume1);
      music.volume=Volume1;
     PlayerPrefs.SetFloat("vo",Volume1);
   }
   public void sounexit()
   {
    optoinobject.SetActive(false);
   }
}
