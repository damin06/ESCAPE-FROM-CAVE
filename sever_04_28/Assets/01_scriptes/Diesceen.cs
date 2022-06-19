using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Diesceen : MonoBehaviour
{
   [SerializeField]private Text bestcore; 
   private int bestScore;
   [SerializeField]private Text currentscore;
   private int currentScore;
    // Start is called before the first frame update
    void Start()
    {
          bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestcore.text = "BEST SCORE " + bestScore;
        currentScore = PlayerPrefs.GetInt("Score", 0);
        currentscore.text = "SCORE " + currentScore;
    }

 public void nextscene()
 {
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

}
