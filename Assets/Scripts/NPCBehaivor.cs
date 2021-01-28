using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCBehaivor : MonoBehaviour
{
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
    [TextArea(3,10)]
    public string chatIntro;
    [TextArea(3, 10)]
    public string chatDetail;
    [TextArea(3, 10)]
    public string chatDeny;
    [TextArea(3, 10)]
    public string chatLostcorrect;
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
                FoundThis(itemFound);
                break;
            case 2:
                IlostThis(itemLost);
                break;          
        }
    }


    void FoundThis(GameObject item)
    {
        Debug.Log(chatIntro);
        //StartCoroutine(Waitfornext);
    }

    void IlostThis(GameObject item)
    {
        Debug.Log(chatIntro);

    }

   /* IEnumerator Waitfornext()
    {
        bool watting = true;

        while (watting)
        {
            if () 
            {
                watting = false;
            }
        }
    }*/

    void GiveDetails() 
    {
        Debug.Log(chatDetail);
    }
}

