using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FollowMouse : MonoBehaviour, IPointerClickHandler
{
    public bool isPickedUp;

    private void Start()
    {
        isPickedUp = false;
    }
    private void Update()
    {
        if (isPickedUp)
        {
            Vector3 newPosition = Input.mousePosition;
            newPosition.z = 0;
            this.transform.position = newPosition;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        isPickedUp = !isPickedUp;
    }
}
