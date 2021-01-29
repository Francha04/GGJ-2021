using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager _instance;
    public int amountOfErrors;
    private int errorsTolerance = 10;
    public bool playerLostTheGame;
    public GameObject[] NPCs;
    public GameObject Canvas;
    public float timeBeforeFirstEvent;
    public float timeBetweenEvents;
    private int NPCIndex;
    
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
        Canvas = FindObjectOfType<Canvas>().gameObject; //Esto se asegura de tener el Canvas de la escena en la variable Canvas;
        NPCIndex = 0;
        Invoke("startNextEvent", timeBeforeFirstEvent); //Esto summonea al primer NPC despues de cierta cantidad de tiempo, definida por timeBeforeFirstEvent.
        playerLostTheGame = false;
    }

    public bool CheckIfPlayerLostTheGame()
    {
        return amountOfErrors >= errorsTolerance;
    }

    public void ResetStats()
    {
        amountOfErrors = 0;
        playerLostTheGame = false;
    }

    private void Update()
    {
        playerLostTheGame = CheckIfPlayerLostTheGame();

        if(playerLostTheGame)
        {
            //Cargar escena final ?
            Debug.Log("Perdiste");
        }
    }

    public void eventEnded()   //Este debe ser convocado por otros objetos, cuando el evento con el NPC actual haya terminado, asi despues de cierto tiempo se inicia el siguiente.
    {
        Invoke("startNextEvent", timeBeforeFirstEvent);
    }
    private void startNextEvent() 
    {
        Instantiate(NPCs[NPCIndex], Canvas.transform);
        print("Ahora mismo deberia estar empezando el evento que involucra al NPC de indice " + NPCIndex + " en el array de GameManager");
        NPCIndex++;        
    }

}
