using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScript : MonoBehaviour
{
    public LevelManager levelM;
    float timeForCredits = 11.95f;
    private void Start()
    {
        Invoke("fadeOut", timeForCredits);
    }

    private void fadeOut()   
    {
        levelM.goToMainMenu();
    }
}
