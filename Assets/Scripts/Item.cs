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

    private void Awake()
    {
        switch (itemType)
        {
            case ITEMTYPE.Cellphone:
                AddCellphoneDescriptions();
                break;
            case ITEMTYPE.Money:
                AddMoneyDescriptions();
                break;
            case ITEMTYPE.Purse:
                AddPurseDescriptions();
                break;
            default:
                break;
        }
    }

    private void AddPurseDescriptions()
    {
        descriptions.Add("Dinero: $1000");
        descriptions.Add("Foto: Perros");
        descriptions.Add("Dni: Armando Paredes");
    }

    private void AddMoneyDescriptions()
    {
        descriptions.Add("Cantidad: $1000");
    }

    private void AddCellphoneDescriptions()
    {
        descriptions.Add("Marca: Autorola");
        descriptions.Add("Modelo: Deagle Desert");
    }
}
