using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataItem : MonoBehaviour
{
    public int id;
    public string descripcion;
    public ITEMTYPE itemType;
    public enum ITEMTYPE
    {
        Cellphone,
        Money,
        Purse,
        Key
    }
}
