using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public int turn;
    public GameObject tilePrefab;
    public GameObject canvas;
    private bool continue; 
    private GameObject[,] tiles = new GameObject[3,4];
    void Awake()
    {
        int xcoord = -150;
        int column = 0;
        owner = 0;
        int subtract = 0;

        for (int i = 0 ; i < 6; i++) {
            GameObject tile = Instantiate(tilePrefab);
            
            tile.transform.position = new Vector3(xcoord, 100 - 100 * (i + subtract), 15);

            tile.transform.SetParent(canvas.transform, false);
            Tile tileScript = tile.GetComponent<Tile>();
            tileScript.owner = owner;


            tiles[i + subtract, column] = tile;            
            if (i == 2) {
                xcoord = 150;
                column = 3;
                owner = 1;
                subtract = -3;
            }
            
        }

        for (int x = 0; x < 2; x++) {
            GameObject chick = Instantiate(tilePrefab);
            chick.transform.position = new Vector3(-50 + 100 * x, 0, 0);

            chick.transform.SetParent(canvas.transform, false);

            tiles[1, x + 1] = chick;
            
            Tile tileScript = chick.GetComponent<Tile>();

            tileScript.owner = x; 
            

        

        }
        
    }

    void Start()
    {
        turn = 0;
        continue = true;



    }

}
