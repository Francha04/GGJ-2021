using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameManager _instance;
    public int amountOfErrors;
    private int errorsTolerance = 10;
    public bool playerLostTheGame;
    public GameObject[] NPCs;
    public GameObject Canvas;
    public GameObject[] botones; //Esto debe contener una referencia para los 4 botones.
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
            //Destroy(this);
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
        Invoke("startNextEvent", timeBetweenEvents);
    }

    public void Boton1Rechazo() // Este es el metodo para el primer boton de los 4, que siempre va a corresponder con el "No lo tengo".
    {
        NPCs[NPCIndex - 1].GetComponent<NPCBehaivor>().Noitemfound();
    }
    public void Boton2Detalles() //Este es el metodo para el segundo boton de los 4, que siempre va a corresponder con el "Pedir detalles
    {
        NPCs[NPCIndex - 1].GetComponent<NPCBehaivor>().AskForDetails();
    }
    public void Boton3() //Este es el metodo para el tercer boton de los 4, que todavia no hemos definido para qué se va a usar
    { 
    }
    public void Boton4() //Este es el metodo para el cuarto boton de los 4, que todavia no hemos definido para qué se va a usar
    { 
    }
    private void startNextEvent() 
    {
        NPCs[NPCIndex].SetActive(true);
        print("Ahora mismo deberia estar empezando el evento que involucra al NPC de indice " + NPCIndex + " en el array de GameManager");
        NPCIndex++;        
    }   

}