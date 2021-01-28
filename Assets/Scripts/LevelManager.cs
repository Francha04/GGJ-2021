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
}
