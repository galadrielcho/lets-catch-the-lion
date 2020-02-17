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
        int turn = ManagerScript.turn;
        if (turn == owner){
            StartCoroutine("getNewLocation");
        }
    }

    // IEnumerator move()
    // {
    //     float speed = 1.0F;
    //     newlocation = new Vector2(ManagerScript.getNewLocation(position, animal, owner));
    //     while (transform.position != newlocation) {
    //         float step = speed * Time.deltaTime;
    //         transform.position = Vector2.MoveTowards(transform.position, newlocation, step);
    //         yield return null;
    //     }
    // }



}
