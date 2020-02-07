using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public int turn;
    public GameObject tilePrefab;
    private GameObject[,] tiles = new GameObject[3,4];
    void Awake()
    {
        int xcoord = -150;
        int column = 0;

        for (int i = 0 ; i < 6; i++) {
            GameObject tile = Instantiate(tilePrefab);

            tile.transform.position = new Vector3(xcoord, -150 + 150*i, 0);

            tiles[i%4, column] = tile;            
            if (i == 3) {
                xcoord = 150;
                column = 3;
            }

        for (int x = 0; x < 2; x++) {
            GameObject chick = Instantiate(tilePrefab);
            chick.transform.position = new Vector3(-50 + x * 100, 0, 0);

            tiles[1, x + 1] = tile;

        }
     }   
    }

    // Start is called before the first frame update
    void Start()
    {
        turn = 0;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
