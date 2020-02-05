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
            StarCoroutine("move");
        }
    }

    IEnumerator move()
    {
        newlocation = new Vector2(manager.getNewLocation(position, animal, owner));
        while (transform.position != newlocation) {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, newlocation, step);
            yield return null;
        }
    }



}
