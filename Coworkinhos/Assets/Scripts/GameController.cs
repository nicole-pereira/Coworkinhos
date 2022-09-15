using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject gameOver;

    public GameObject pause;
    bool isPause;

    public float incremento;

    public GameObject jogador;

    public bool acertou;
    
    public int totalScore;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
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
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(lvlName);
    }

    public void Errou(GameObject fruta)
    {
        Destroy(fruta);
        acertou=false;
        Debug.Log("errou a pergunta");
        Time.timeScale = 1;
    }

    public void Acertou(GameObject fruta)
    {
        Destroy(fruta);
        acertou=true;
        Debug.Log("acertou a pergunta");
        Time.timeScale = 1;
        totalScore += Fruits.instance.Score;
        scoreText.text = totalScore.ToString();
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
 