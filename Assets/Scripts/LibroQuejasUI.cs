using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibroQuejasUI : MonoBehaviour
{
    public bool isBookOn;
    public int numBookPage;
    public GameObject bookParent;
    public GameObject[] bookPages;
    public GameObject bookTutorial;
    private void Start()
    {
        isBookOn = false;
        numBookPage = 1;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            isBookOn = !isBookOn;
            if (isBookOn) 
            {
                int index = 0;
                bookTutorial.SetActive(true);
                bookParent.SetActive(true);
                foreach (GameObject page in bookPages) 
                {
                    index++;
                    if (index == numBookPage)
                    {
                        page.SetActive(true);
                    }
                    else { page.SetActive(false); }
                }
            }
            if (!isBookOn) 
            {
                bookTutorial.SetActive(false);
                bookParent.SetActive(false);
                foreach (GameObject page in bookPages) 
                {
                    page.SetActive(false);

                }
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && isBookOn && numBookPage > 1) 
        {
            int index = 0;
            numBookPage--;
            foreach (GameObject page in bookPages)
            {
                index++;
                if (index == numBookPage)
                {
                    page.SetActive(true);
                }
                else { page.SetActive(false); }
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && isBookOn && numBookPage < 4)
        {
            int index = 0;
            numBookPage++;
            foreach (GameObject page in bookPages)
            {
                index++;
                if (index == numBookPage)
                {
                    page.SetActive(true);
                }
                else { page.SetActive(false); }
            }
        }
    }
}

