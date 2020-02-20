﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerDownHandler
{
    public int tiletype;
    public int owner;   
    public Vector2 position;
    public int animal;


    public void OnPointerDown(PointerEventData eventData)
    {



        // int[] tileAttributes = new int[4]{(int)position.x, (int)position.y, animal, owner };

        int x = (int)position.x;

        int[] tileAttributes = new int[4]{(int)position.x, (int)position.y, animal, owner};

        GameManagerScript.Instance.getNewLocation(tileAttributes);
        }

}
