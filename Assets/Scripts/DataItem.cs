using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataItem : MonoBehaviour
{
    public int id;
    public string descripcion;
    public ITEMTYPE itemType;
    public int itemValue; // El valor del objeto, en dinero. Solo para trabajo interno. Si le da un celular de alta gama al que perdió el de gama baja, lo va a aceptar al tener mayor valor.
    public enum ITEMTYPE
    {
        Cellphone,
        Money,
        Purse,
        Key,
        Watch
    }
}
