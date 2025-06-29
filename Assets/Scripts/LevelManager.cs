using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelManager : MonoBehaviour
{    
    
    [SerializeField] float sceneLoadDelay=2.0f;
    ScoreKeeper scoreKeeper;
     void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    public void LoadGame()
    {  
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("Game");
    }
    public void LoadMainMenu()
    {
         
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadGameOver()
    {
        scoreKeeper.SaveHighScoreIfNeeded();
        StartCoroutine(WaitAndLoad("GameOver",sceneLoadDelay));
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game....");
        Application.Quit();
    }
    IEnumerator WaitAndLoad( string SceneName, float delay)
    {

        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneName);
    }

}
