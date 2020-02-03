using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int ownersetup;
    public int tiletype;
    private int owner;
    void Start()
    {
        owner = ownersetup;
        type = tiletype

    }

    void isTurn()
    {
        GameManagerScript manager = gameobjectformanager.GetComponent<GameManagerScript>(); // The script name is the variable type ? 
        turn = manager.turn;
        if (turn == owner){
            getNewLocation();
        }
    }
    Tuple<int, int> getNewLocation();
        

}
