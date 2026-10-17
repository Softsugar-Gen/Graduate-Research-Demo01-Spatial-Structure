using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FurnitureControl : MonoBehaviour
{
    MouseControl mouseControl;
    private GameObject[] furnitures;
    GameObject list;

    private void Start()
    {
        mouseControl = FindAnyObjectByType<MouseControl>();
        list = GameObject.Find("FurniturePanel");
        furnitures = Resources.LoadAll<GameObject>("Prefabs");
        //Debug.Log(furnitures.Length);

    }
    public void FurnitureSelect(string furnitureName)
    {
        foreach (GameObject furniture in furnitures)
        {
           if(furniture.name == furnitureName)
           {
               mouseControl.SetFurniture(furniture);
               Debug.Log(furnitureName);
           }
        }
    }

}
