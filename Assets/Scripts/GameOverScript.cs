using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public LevelManager levelM;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButtonDown(0))) 
        {
            levelM.goToMainMenu();
        }
    }
}
