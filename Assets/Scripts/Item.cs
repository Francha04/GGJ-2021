using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item : MonoBehaviour
{
    [System.Serializable]

    /* Cuando instanciamos uno de estos objetos, hay que pasar la ID usando un codigo como el siguiente:
      GameObject nuevoObjeto = Instantiate(Item);
      nuevoObjeto.id = 1;
     */ 
    public enum ITEMTYPE
    {
        Cellphone,
        Money,
        Purse,
        Key
    }

    public int id;
    public ITEMTYPE itemType;
    public List<string> descriptions;
<<<<<<< HEAD
=======
    public List<Sprite> sprites; // Aca guardamos los sprites de los diferentes objetos, segun id.
    private void Awake()
    {
        switch (itemType)
        {
            case ITEMTYPE.Cellphone:
                AddCellphoneDescriptions(id);
                break;
            case ITEMTYPE.Money:
                AddWalletDescriptions(id);
                break;
            case ITEMTYPE.Purse:
                AddPurseDescriptions(id);
                break;
            case ITEMTYPE.Key:
                AddKeyDescriptions(id);
                break;
            default:
                break;
        }
        this.gameObject.GetComponent<Image>().sprite = sprites[id - 10]; // Le restamos 10 a la id porque las ids arrancan en 10. En la posicion de indice 0 de este array de sprites deberia estar el sprite que corresponde con el objeto de id 0, and so on.
    }

    private void AddPurseDescriptions(int codigo)
    {
        if (codigo == 15) //Monedero de 1000 pesos.
        {
            descriptions.Add("Dinero: $1000");
            descriptions.Add("Foto: Perros");
            descriptions.Add("Dni: Julia Paredes");
        }
        else { print("Error. Esa ID no corresponde con ningun monedero"); }
    }

    private void AddWalletDescriptions(int codigo)
    {
        if (codigo == 13) // Billetera de 100 pesos.
        {
            descriptions.Add("Dinero: $100");
        }
        else if (codigo == 14) // Billetera de 1500 pesos.
        {
            descriptions.Add("Dinero: $1500");
        }
        else { print("Error. Esa ID no corresponde con ninguna billetera"); }
    }

    private void AddCellphoneDescriptions(int codigo)
    {
        if (codigo == 10)     // Celular Gama Baja
        {
            descriptions.Add("Marca: Croto");
            descriptions.Add("Modelo: Malo");
        }
        else if (codigo == 11) // Celular Gama Media
        {
            descriptions.Add("Marca: Autorola");
            descriptions.Add("Modelo: Deagle Desert");
        }
        else if (codigo == 12) // Celular Gama Alta
        {
            descriptions.Add("Marca: Samsung");
            descriptions.Add("Modelo: S10");
        }
        else { print("Esa ID no corresponde con ningun celular");   ;}
    }
    private void AddKeyDescriptions(int codigo) 
    {
        if (codigo == 16)     // Llave con llaves multiples
        {
            descriptions.Add("Un llavero con multiples llaves.");
        }
        else if (codigo == 17)  // LLavero simple
        {
            descriptions.Add("Las llaves de un auto.");
        }
    }
>>>>>>> 6cd37d6a615b5cfac7fbe4380e98986603f7d5a7
}
