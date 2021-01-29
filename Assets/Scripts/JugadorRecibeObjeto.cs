using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorRecibeObjeto : MonoBehaviour
{
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
            print("Objeto se fue");
            this.gameObject.SetActive(false);
            
        }
    }
}
