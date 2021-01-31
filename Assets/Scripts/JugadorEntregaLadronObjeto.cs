using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorEntregaLadronObjeto : MonoBehaviour
{
    int IDOfItem;
    float timeBeforeCheck;
    private void Start()
    {
        IDOfItem = GetComponentInParent<LadronaBehaviour>().itemLost.GetComponent<DataItem>().id;
    }
    private void OnTriggerEnter2D(Collider2D collision) //Entra algo en el collider
    {
        if (collision.gameObject.CompareTag("Objeto"))  //Chequeamos si es un objeto.
        {
            GetComponentInParent<LadronaBehaviour>().ReceivingItem(collision.gameObject);
        }
    }
}
