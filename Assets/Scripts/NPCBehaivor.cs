using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NPCBehaivor : MonoBehaviour, IDropHandler
{
    [SerializeField] Text dialogBox;
    [SerializeField] Canvas canvas;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject[] buttons;

    [SerializeField] string[] textoBotones; // Aca guardamos el texto de todos los botones que necesita el NPC (entre 1 y 4, segun el length que le pongamos al array)

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
                IlostThis();
                break;
        }
    }

    void FoundThis()
    {
        dialogBox.text = $"{ chatIntro }";
        GameObject cloneFound = Instantiate(itemFound);
        cloneFound.transform.SetParent(canvas.transform, false);
        cloneFound.SetActive(true);
    }

    void OnCollisionExit(Collision other)
    {
        
    }

    void IlostThis()
    {
        dialogBox.text = $"{ chatIntro }";
    }

    public void AskForDetails()
    {
        dialogBox.text = $"{ chatDetail }";
    }

    public void Noitemfound()
    {

        dialogBox.text = $"{ chatDeny }";
        if (itemLost != null)
        {
            gameManager._instance.amountOfErrors++;
            Debug.Log(gameManager._instance.amountOfErrors);
        }

        //llamar animador y destruir persona
        Destroy(this.gameObject);

    }

    public void OnDrop(PointerEventData eventData)
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
                }*/
            else
            {
                dialogBox.text = $"{ chatWrong }";
                gameManager._instance.amountOfErrors++;
                Debug.Log(gameManager._instance.amountOfErrors);
            }
        }
    }
}





