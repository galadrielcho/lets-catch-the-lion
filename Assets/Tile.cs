using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject = GameManager;
    public int ownersetup;
    public int tiletype;
    public int owner;
    private manager = GameManager.GetComponent<GameManager>();
    public Vector2 newlocation;
    public int animal;
    public int position;


    void Start()
    {
        int owner = ownersetup;
        int animal = tiletype;
        int position = row_column;

    }

    void click()
    {
        int turn = manager.turn;
        if (turn == owner){
            StartCoroutine("getNewLocation");
        }
    }

    IEnumerator move()
    {
        float speed = 1.0F;
        newlocation = new Vector2(manager.getNewLocation(position, animal, owner));
        while (transform.position != newlocation) {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, newlocation, step);
            yield return null;
        }
    }



}
