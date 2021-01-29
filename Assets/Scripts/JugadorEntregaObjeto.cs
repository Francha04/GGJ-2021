using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorEntregaObjeto : MonoBehaviour
{
    int IDOfItem;
    float timeBeforeCheck;
    private void Start()
    {
        IDOfItem = GetComponentInParent<NPCBehaivor>().itemLost.GetComponent<DataItem>().id;
    }
    private void OnTriggerEnter2D(Collider2D collision) //Entra algo en el collider
    {
        if (collision.gameObject.CompareTag("Objeto"))  //Chequeamos si es un objeto.
        {
            GetComponentInParent<NPCBehaivor>().ReceivingItem(collision.gameObject); //Se lo damos al NPC behaviour para que haga lo suyo.
        }
    }
}
