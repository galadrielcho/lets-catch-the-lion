  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CircleScript : MonoBehaviour, IPointerDownHandler
{
      
    public static bool wasClicked = false;
    public static Vector2 location;

    public void OnPointerDown(PointerEventData eventData)
    {

        wasClicked = true;

        location = new Vector2(2 - (transform.localPosition.y + 100)/100, (transform.localPosition.x + 150 ) / 100);

        GameManagerScript.newLocation = location;
    }
}