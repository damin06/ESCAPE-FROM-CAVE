
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class gamepause : MonoBehaviour
{
    [SerializeField]private GameObject pauseUI;
public static bool ispause=false;

  
    // Start is called before the first frame update
    void Start()
    {
   
    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
          ispause=true;
            pauseUI.SetActive(true);
            //pauseUI.transform.DOMoveY(-490,1).SetEase(Ease.OutElastic);
           Time.timeScale=0;
           Time.fixedDeltaTime=0.002f*Time.timeScale;
        }
    }
    public void isPausegame()
    {
        ispause=false;
            Time.timeScale=1;
         Time.fixedDeltaTime=0.002f*Time.timeScale;
        pauseUI.SetActive(false);
          //pauseUI.transform.DOMoveY(-2123,1).SetEase(Ease.OutElastic);
         // pauseUI.SetActive(false);
    }
    public void hombutton()
    {
        ispause=false;
         Time.timeScale=1;
         Time.fixedDeltaTime=0.002f*Time.timeScale;
        pauseUI.SetActive(false);
SceneManager.LoadScene("start");
    }
    public void quitbn()
    {
        Application.Quit();
    }

}
