using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameManager _instance;
    public int amountOfErrors;
    private int errorsTolerance = 5;
    public bool playerLostTheGame;
    public GameObject[] NPCs;
    public GameObject Canvas;
    public GameObject[] botones; //Esto debe contener una referencia para los 4 botones.
    public float timeBeforeFirstEvent;
    public float timeBetweenEvents;
    private int NPCIndex;
    public libroQuejas libroDeQuejas;


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
        //Invoke("startNextEvent", timeBeforeFirstEvent); //Esto summonea al primer NPC despues de cierta cantidad de tiempo, definida por timeBeforeFirstEvent.
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            ResetStats();
            Invoke("startNextEvent", timeBeforeFirstEvent); //Esto summonea al primer NPC despues de cierta cantidad de tiempo, definida por timeBeforeFirstEvent.
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {

        }
    }

    public bool CheckIfPlayerLostTheGame()
    {
        return amountOfErrors >= errorsTolerance;
    }

    public void ResetStats()
    {
        amountOfErrors = 0;
        playerLostTheGame = false;
        NPCIndex = 0;
    }

    private void Update()

    {
        playerLostTheGame = CheckIfPlayerLostTheGame();

        if (playerLostTheGame)
        {
            //Cargar escena final ?
        }

    }
    public void eventEnded()   //Este debe ser convocado por otros objetos, cuando el evento con el NPC actual haya terminado, asi despues de cierto tiempo se inicia el siguiente.
    {
        Invoke("startNextEvent", timeBetweenEvents);
    }

    public void Boton1Rechazo() // Este es el metodo para el primer boton de los 4, que siempre va a corresponder con el "No lo tengo".
    {
        if (NPCIndex == 5)
        {
            NPCs[NPCIndex - 1].GetComponent<LadronaBehaviour>().Noitemfound();
        }
        else
        {
            NPCs[NPCIndex - 1].GetComponent<NPCBehaivor>().Noitemfound();
        }
    }
    public void Boton2Detalles() //Este es el metodo para el segundo boton de los 4, que siempre va a corresponder con el "Pedir detalles
    {
        if (NPCIndex == 5)
        {
            NPCs[NPCIndex - 1].GetComponent<LadronaBehaviour>().AskForDetails();
        }
        else
        {
            NPCs[NPCIndex - 1].GetComponent<NPCBehaivor>().AskForDetails();
        }
    }
    public void Boton3() //Este es el metodo para el tercer boton de los 4, que todavia no hemos definido para qué se va a usar
    { 
    }
    public void Boton4() //Este es el metodo para el cuarto boton de los 4, que todavia no hemos definido para qué se va a usar
    { 
    }
    private void startNextEvent() 
    {
        if (NPCs.Length > NPCIndex)
        {
            NPCs[NPCIndex].SetActive(true);
            NPCIndex++;
        }
        else 
        {
            if (amountOfErrors > errorsTolerance)
            {
                SceneManager.LoadScene(3);
            }
            else 
            {
                SceneManager.LoadScene(4);
            }
        }
    }

    public void errorCometido() 
    {
        amountOfErrors++;
        libroDeQuejas.updateSprite(amountOfErrors);
    }
}