using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public int tiletype;
    public int owner;   
    public Vector2 position;
    public int animal;
    public GameManagerScript ManagerScript;


    void onMouseDown()
    {

        Debug.Log("hi");
        int[] tileAttributes = new int[4]{(int)position.x, (int)position.y, animal, owner };
        Debug.Log(tileAttributes.Length);

        ManagerScript.getNewLocation(tileAttributes);

        }





}
