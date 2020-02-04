using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int ownersetup;
    public int tiletype;
    public int owner;
    private GameManagerScript manager = gameobjectformanager.GetComponent<GameManagerScript>(); // The script name is the variable type ? 
    public Tuple<int,int> coordinates;
    public float speed = 1.0F;
    private float startTime;


    void Start()
    {
        owner = ownersetup;
        animal = tiletype;
        position = row_column;

    }

    void click()
    {
        turn = manager.turn;
        if (turn == owner){
            move();
        }
    }
    void move()
    {
        Tuple<int, int> location = manager.getNewLocation(animal, position);

        
    }


}
