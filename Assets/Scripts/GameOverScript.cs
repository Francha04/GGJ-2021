using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public LevelManager levelM;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            levelM.goToMainMenu();
        }
    }
}
