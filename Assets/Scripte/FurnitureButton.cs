using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FurnitureButton : MonoBehaviour
{
    FurnitureControl control;

    void Start()
    {
        control = FindAnyObjectByType<FurnitureControl>();
    }
    public void OnFurnitureClick()
    {
        string furnitureName = this.name;
        control.FurnitureSelect(furnitureName);
    }
}
