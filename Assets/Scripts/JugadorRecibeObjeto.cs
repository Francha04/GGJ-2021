using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorRecibeObjeto : MonoBehaviour
{
    // Este script debe estar en un children del gameobject persona. Solo si la persona va a ENTREGARLE un objeto al jugador. El children que lo contenga debe tener un box collider 2D marcado como trigger.
    int IDOfItem;
    private void Awake()
    {
        IDOfItem = GetComponentInParent<NPCBehaivor>().itemFound.GetComponent<DataItem>().id;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Objeto") && collision.gameObject.GetComponent<DataItem>().id == IDOfItem) 
        {
            GetComponentInParent<NPCBehaivor>().InteractionFinish();
            this.gameObject.SetActive(false);            
        }
    }
}
