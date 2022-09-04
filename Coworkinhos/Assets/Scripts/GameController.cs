using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject gameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartGame(string lvlName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(lvlName);
    }
}
 