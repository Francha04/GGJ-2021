using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NPCBehaivor : MonoBehaviour
{
    [SerializeField] Text dialogBox;
    [SerializeField] Canvas canvas;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject[] buttons;   // Aca referenciemos SIEMPRE a los 4 botones.
    [SerializeField] string[] textoBotones; // Aca guardamos el texto de todos los botones que necesita el NPC. Los que no tengan texto van a estar desactivados
    [SerializeField] float timeFadeOut; // La duracion de la animacion del fade out final.
    [SerializeField] float timeForLastDialogue; // El tiempo que tiene el player antes de que el NPC, y su dialogue box, empiece a desaparecer. Esta variable determina cuanto tiempo va a tener el player para poder leer el ultimo dialogo del NPC.

    // "1" Viene a dejar un objeto perdido "2" Perdio un objeto "3" Esta perdido
    public enum pacientType
    {
        encontroAlgo = 1,
        perdioAlgo = 2,
        //estaPerdido = 3,
    };

    [SerializeField]
    private pacientType paciente;

    private int type;

    public GameObject itemFound;
    public GameObject itemLost;
    int expectedValue; // El valor que espera recibir. Si lo que recibe es del mismo tipo que el objeto que quiere, y tiene mas valor, entonces lo acepta igual.
    //public GameObject wheresLocation;

    //chat
    [TextArea(3, 10)]
    public string chatIntro;
    [TextArea(3, 10)]
    public string chatDetail;
    [TextArea(3, 10)]
    public string chatDeny;
    [TextArea(3, 10)]
    public string chatCorrect;
    [TextArea(3, 10)]
    public string chatAcceptfraud;
    [TextArea(3, 10)]
    public string chatWrong;

    
    void Start()
    {
        type = (int)paciente;
        gameManager = FindObjectOfType<GameManager>(); // Para asegurarnos de tener un game manager cuando empezamos.
        dialogBox.text = dialogBox.text = $"{ chatIntro }";
        dialogBox.GetComponent<Animator>().SetTrigger("Fade In");
        // Se revisa el caso del paciente
        switch (type)
        {
            case 1:
                foreach(GameObject objects in buttons)
                {
                    objects.GetComponent<Button>().interactable = false;
                }
                FoundThis();
                break;
            case 2:
                int x = 0;
                foreach (GameObject objects in buttons)
                {
                    if (x < textoBotones.Length) // Hacemos esto para que solo active los botones necesarios, y que les aplique el texto correcto.
                    {
                        objects.GetComponent<Button>().interactable = true;
                        objects.GetComponentInChildren<Text>().text = textoBotones[x];
                    }
                    else // Los botones innecesarios los desactiva y les pone una linea -- de texto.
                    {
                        objects.GetComponent<Button>().interactable = false;
                        objects.GetComponentInChildren<Text>().text = "--";
                    }
                    x++;
                }
                expectedValue = itemLost.GetComponent<DataItem>().itemValue;
                IlostThis();
                break;
        }
    }

    void FoundThis()
    {
   
        dialogBox.text = $"{ chatIntro }";
        GameObject cloneFound = Instantiate(itemFound);
        cloneFound.transform.SetParent(canvas.transform, false);
        cloneFound.GetComponent<DragAndDrop>().canvas = canvas;
        cloneFound.SetActive(true);
    }

    public void ReceivingItem(GameObject objetoRecibido) // Este method es para cuando le das un objeto al NPC. Es decir que solo se usa para NPCs de tipo lost item.
    {
        DataItem dataObjetoRecibido = objetoRecibido.GetComponent<DataItem>();
        DataItem dataObjetoBuscado = itemLost.GetComponent<DataItem>();
        if (dataObjetoRecibido.id == dataObjetoBuscado.id)
        {
            dialogBox.text = $"{ chatCorrect }";
            Invoke("InteractionFinish", timeForLastDialogue); //Despues de determinada cantidad de segundos termina la interaccion, asi da tiempo para que el jugador lea el dialogo de chatCorrect
        }
        else if (dataObjetoBuscado.itemType == dataObjetoRecibido.itemType && dataObjetoRecibido.itemValue > dataObjetoBuscado.itemValue)  // Si son del mismo tipo y el que le das tiene mas valor que el buscado, se acepta por fraude.
        {
            dialogBox.text = $"{chatAcceptfraud}";
            gameManager._instance.amountOfErrors++;
            Invoke("InteractionFinish", timeForLastDialogue);            
        }
        else  // Si no era correcto ni era fraude, entonces va el chatWrong.
        {
            dialogBox.text = $"{ chatWrong }";
            gameManager._instance.amountOfErrors++;
            Invoke("InteractionFinish", timeForLastDialogue);
        }
        objetoRecibido.gameObject.GetComponent<DragAndDrop>().Immobilize(); //Deja inamovible el objeto que recibio el NPC.
        Destroy(objetoRecibido, timeForLastDialogue + timeFadeOut); // Asi el NPC y el objeto se van al mismo tiempo.        
    }

    void IlostThis()
    {
        dialogBox.text = $"{ chatIntro }";
    }

    public void AskForDetails()
    {
        dialogBox.text = $"{ chatDetail }";
    }

    public void Noitemfound() //Esto se corre cuando el jugador dice "No lo tengo"
    {

        dialogBox.text = $"{ chatDeny }";
        if (itemLost != null)
        {
            gameManager._instance.amountOfErrors++;
            Debug.Log(gameManager._instance.amountOfErrors);
        }

        //llamar animador y destruir persona. Todo lo hace el metodo InteractionFinish.
        Invoke("InteractionFinish", timeForLastDialogue);
    }

    public void InteractionFinish()  //Esto se llama cuando la interaccion finalizó.
    {
        print("Finish");
        gameManager.eventEnded();
        this.gameObject.GetComponent<Animator>().SetTrigger("InteractionOver");        
        dialogBox.GetComponent<Animator>().SetTrigger("Fade Out");
        dialogBox.GetComponent<Animator>().ResetTrigger("Fade In");
        Invoke("selfDestroy", timeFadeOut);
    }
    public void selfDestroy() 
    {
        dialogBox.text = "";
        dialogBox.GetComponent<Animator>().ResetTrigger("Fade Out");
        Destroy(this.gameObject); 
    }

    /* public void OnDrop(PointerEventData eventData)
     {
         if (eventData.pointerDrag != null)
         {
             if (eventData.pointerDrag.gameObject == itemLost)
             {

                 dialogBox.text = $"{ chatCorrect }";

                 Destroy(eventData.pointerDrag.gameObject);
                 Debug.Log(eventData.pointerDrag.gameObject);

                 dialogBox.text = $"{ chatCorrect }";

                 Destroy(this.gameObject);
                 //llamar animador y destruir persona
             }
             /*else if (eventData.pointerDrag.gameObject.value > itemLost.value)
                 {
                     dialogBox.text = $"{chatAcceptfraud}";
                     gameManager._instance.amountOfErrors++;
                     Debug.Log(gameManager._instance.amountOfErrors);
                     Destroy(eventData.pointerDrag.gameObject);
                     Debug.Log(eventData.pointerDrag.gameObject);
                     Destroy(this.gameObject);
                     //llamar animador y destruir persona
                 }
             else
             {
                 dialogBox.text = $"{ chatWrong }";
                 gameManager._instance.amountOfErrors++;
                 Debug.Log(gameManager._instance.amountOfErrors);
             }
         }
     }*/

}





