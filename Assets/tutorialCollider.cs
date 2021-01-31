using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialCollider : MonoBehaviour
{
    public GameManager gameM;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Objeto")) 
        {
            gameM.TutorialDialogue();
            Destroy(this.gameObject);
        }
    }
}
