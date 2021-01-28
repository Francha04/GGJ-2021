using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemOrganizer : MonoBehaviour, IDropHandler, IPointerEnterHandler,IPointerExitHandler
{
    public List<GameObject> listOfItemSlots;
    public bool mouseInside;
    

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            foreach (var itemslot in listOfItemSlots)
            {
                if (!itemslot.GetComponent<ItemSlot>().isOccupied || itemslot.GetComponent<ItemSlot>().item == eventData.pointerDrag)
                {
                    //Establezco que va a estar ocupado por un item
                    itemslot.GetComponent<ItemSlot>().isOccupied = true;
                    //Muevo el elemento a la posicion fija del itemslot.transform
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = itemslot.GetComponent<RectTransform>().anchoredPosition;
                    eventData.pointerDrag.GetComponent<Transform>().localScale = new Vector3(0.75f, 0.75f);
                    //Obtener el item
                    itemslot.GetComponent<ItemSlot>().item = eventData.pointerDrag;
                    break;
                }
            }
        }
    }

    //Por aca iria lo contrario del OnDrop, establecer en falso el itemSlot
    public void OnExitItem(DragAndDrop dragAndDrop)
    {
        foreach (var itemSlot in listOfItemSlots)
        {           
            if (itemSlot.GetComponent<ItemSlot>().item == dragAndDrop.gameObject)
            {
                itemSlot.GetComponent<ItemSlot>().isOccupied = false;
                itemSlot.GetComponent<ItemSlot>().item = null;
                break;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseInside = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseInside = false;
    }
}
