using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NPCBehaivor : MonoBehaviour, IDropHandler
{
    public Text dialogBox;


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

    // Se revisa el caso del paciente
    void Start()
    {
        type = (int)paciente;

        Debug.Log(type);

        switch (type)
        {
            case 1:
                FoundThis();
                break;
            case 2:
                IlostThis();
                break;
        }
    }

    void FoundThis()
    {
        dialogBox.text = $"{ chatIntro }";
        //StartCoroutine(Waitfornext);
    }

    void IlostThis()
    {
        dialogBox.text = $"{ chatDetail } {itemLost.GetComponent<Item>().itemType}";
    }

    void GiveDetails()
    {
        Debug.Log(chatDetail);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.gameObject == itemLost)
            {
                Debug.Log(eventData.pointerDrag.gameObject);
                dialogBox.text = $"{ chatCorrect }";
            }
            else
            {
                dialogBox.text = $"{ chatWrong }";
            }
        }
    }
}

