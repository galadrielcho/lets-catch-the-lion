  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
      
    public static bool wasClicked = false;
    public static Vector2 location;

    void OnMouseDown() {

        wasClicked = true;

        location = new Vector2(transform.position.x + 50 / 100, (transform.position.y - 100) / -100);
    }
}