using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class libroQuejas : MonoBehaviour
{
    public Sprite[] estados;  //El array que contiene los distintos sprites del libro.
    Image estaImagen;
    public float minTimeBeforeComplain;
    public float maxTimeBeforeComplain;
    public int errores;
    private void Start()
    {
        estaImagen = this.GetComponent<Image>();
        estaImagen.sprite = estados[0];
    }
    public void updateSprite(int x) 
    {
        errores = x;
        Invoke("spriteChange", Random.Range(minTimeBeforeComplain, maxTimeBeforeComplain));
    }
    public void spriteChange() 
    {
        switch (errores)
        {
            case 1:
                estaImagen.sprite = estados[1];
                break;
            case 2:
                estaImagen.sprite = estados[2];
                break;
            case 3:
                estaImagen.sprite = estados[2];
                break;
            case 4:
                estaImagen.sprite = estados[3];
                break;
            case 5:
                estaImagen.sprite = estados[3];
                break;
            case 6:
                estaImagen.sprite = estados[4];
                break;
            case 7:
                estaImagen.sprite = estados[4];
                break;
            default:
                estaImagen.sprite = estados[4];
                break;
        }
    }
}
