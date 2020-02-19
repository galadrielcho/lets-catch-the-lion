using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int tiletype;
    public int owner;   
    public Vector2 position;
    public int animal;
    public GameManagerScript ManagerScript;


    void Start()
    {
        int animal = tiletype;

    }

    void onMouseDown()
    {
        int[] tileAttributes = new int[] { (int)position.x, (int)position.y, (int)animal, (int)owner };
        ManagerScript.getNewLocation(tileAttributes);

        }





}
