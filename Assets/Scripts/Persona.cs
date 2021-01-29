using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Persona : MonoBehaviour , IDropHandler
{
    public GameObject desiredObject;
    [SerializeField] GameManager gameManager;

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.gameObject != desiredObject)
            {
                Debug.Log("No es mi  item");
                gameManager._instance.amountOfErrors++;
                Debug.Log(gameManager._instance.amountOfErrors);
            }
            else
            {
                Debug.Log("Es mi  item");
                Destroy(eventData.pointerDrag.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
