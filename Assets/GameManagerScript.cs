using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public int turn;
    public GameObject tilePrefab;
    public GameObject canvas;
    private bool repeat = true; 
    private GameObject[,] board = new GameObject[3,4];
    public Sprite[] sprites; 



    void Awake()
    {
        int xcoord = -150;
        int column = 0;
        int owner = 0;
        int subtract = 0;

        for (int i = 0 ; i < 6; i++) {
            GameObject tile = Instantiate(tilePrefab);
            
            tile.transform.position = new Vector3(xcoord, 100 - 100 * (i + subtract), 15);

            tile.transform.SetParent(canvas.transform, false);
            Tile tileScript = tile.GetComponent<Tile>();
            
            
            tileScript.owner = owner;

            if (i == 3){
                tile.GetComponent<Image>().sprite = sprites[2];

            }
            else if (i == 5) {
                tile.GetComponent<Image>().sprite = sprites[0];

            }
            else {
                tile.GetComponent<Image>().sprite = sprites[i + subtract];

            }

            tile.transform.Rotate(0, 0, 90 * (1 + 2 * owner));
            tile.transform.localScale = new Vector3(.9f, .9f, .9f);

            board[i + subtract, column] = tile;            
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

            board[1, x + 1] = chick;
            
            Tile tileScript = chick.GetComponent<Tile>();

            tileScript.owner = x; 
            
            chick.GetComponent<Image>().sprite = sprites[3];
            
            chick.transform.Rotate(0, 0, 90 * (1 + 2 * owner));
            chick.transform.localScale = new Vector3(.9f, .9f, .9f);
            

        

        }
        
    }

    void Start()
    {
        turn = 0;





    }

}
