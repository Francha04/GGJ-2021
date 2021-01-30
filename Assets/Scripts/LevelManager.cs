using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private LevelManager _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public void LoadLevel(string name)
    {
        //Verificar que el nombre de la escena concuerde con el nombre del parametro
        //y que la escena este en el build
        SceneManager.LoadScene(name);
    }
    public void goToMainMenu() 
    {
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void goToCredits() 
    {
        SceneManager.LoadScene(2);
    }
    public void gameQuit() 
    {
        Application.Quit();
    }
}
