using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int ownersetup;
    public int tiletype;
    public int owner;   
    private GameManagerScript ManagerScript;
    public Vector2 newlocation;
    public int animal;


    void Start()
    {
        int owner = ownersetup;
        int animal = tiletype;
        GameObject GameManager = GameObject.Find("GameManager");
        ManagerScript = GameManager.GetComponent<GameManagerScript>();


    }

    void click()
    {
        int turn = GameManagerScript.turn;
        if (turn == owner){
            StartCoroutine("getNewLocation");
        }
    }





}
