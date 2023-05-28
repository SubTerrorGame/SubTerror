using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;
using UnityEngine.UI;

public class EquipmentButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public TMP_Text textComponent;
    public TMP_FontAsset fontNormal;
    public TMP_FontAsset fontHovered;



    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
        //Debug.Log("Cursor Entering " + name + " GameObject");
        textComponent.font = fontHovered;
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //Output the following message with the GameObject's name
        //Debug.Log("Cursor Exiting " + name + " GameObject");
         textComponent.font = fontNormal;
    }
}
