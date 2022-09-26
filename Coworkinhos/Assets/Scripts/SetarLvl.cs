using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetarLvl : MonoBehaviour
{   
    public int porximaCena;
    // Start is called before the first frame update
    void Start()
    {
        porximaCena = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Setar()
    {
        if(SceneManager.GetActiveScene().buildIndex==13)
        {
            Debug.Log("lvl maximo");
        }
        else{
            if(porximaCena > PlayerPrefs.GetInt("maxlvl"))
            {
                PlayerPrefs.SetInt("maxlvl",porximaCena);
            }
        }
    }
}
