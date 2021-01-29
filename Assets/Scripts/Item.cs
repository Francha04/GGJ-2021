using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [System.Serializable]
    public enum ITEMTYPE
    {
        Cellphone,
        Money,
        Purse
    }

    public int id;
    public ITEMTYPE itemType;
    public List<string> descriptions;
}
