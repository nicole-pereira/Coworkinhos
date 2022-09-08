using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject gameOver;

    public GameObject pause;

    bool isPause;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    void Update () {
        if (Input.GetKeyDown (KeyCode.P)) 
        {
            isPause = !isPause;

            if (isPause) {
                Pause ();
            }
            else
            {
                UnPause();
            }
        }
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame(string lvlName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(lvlName);
        Time.timeScale = 1;
    }

    public void Errou(GameObject fruta)
    {
        Destroy(fruta);
        Time.timeScale = 1;
    }

    public void Acertou(GameObject fruta)
    {
        Destroy(fruta);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }

}
 