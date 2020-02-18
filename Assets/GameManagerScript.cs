using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject canvas;
    private bool repeat = true;
    private GameObject[,] board = new GameObject[3, 4];
    public Sprite[] sprites;
    public static int turn = 0;


    void Awake()
    {
        int xcoord = -150;
        int column = 0;
        int owner = 0;
        int subtract = 0;

        for (int i = 0; i < 6; i++)
        {
            GameObject tile = Instantiate(tilePrefab);

            tile.transform.position = new Vector3(xcoord, 100 - 100 * (i + subtract), 15);

            tile.transform.SetParent(canvas.transform, false);
            Tile tileScript = tile.GetComponent<Tile>();


            tileScript.owner = owner;

            if (i == 3)
            {
                tile.GetComponent<Image>().sprite = sprites[2];

            }
            else if (i == 5)
            {
                tile.GetComponent<Image>().sprite = sprites[0];

            }
            else
            {
                tile.GetComponent<Image>().sprite = sprites[i + subtract];

            }

            // tile.transform.Rotate(0, 0, 90 * (1 + 2 * owner));
            tile.transform.localScale = new Vector3(.9f, .9f, .9f);

            board[i + subtract, column] = tile;
            if (i == 2)
            {
                xcoord = 150;
                column = 3;
                owner = 1;
                subtract = -3;
            }

        }

        for (int x = 0; x < 2; x++)
        {
            GameObject chick = Instantiate(tilePrefab);
            chick.transform.position = new Vector3(-50 + 100 * x, 0, 0);

            chick.transform.SetParent(canvas.transform, false);

            board[1, x + 1] = chick;

            Tile tileScript = chick.GetComponent<Tile>();

            tileScript.owner = x;
            Debug.Log(x);
            
            chick.GetComponent<Image>().sprite = sprites[3];

            Debug.Log(tileScript.owner);
            chick.transform.Rotate(0, 0, -90 + (tileScript.owner + 2 * tileScript.owner));
            chick.transform.localScale = new Vector3(.9f, .9f, .9f);




        }

    }
     

   void  getNewLocation(object[] tileAttributes)
    {
        Vector2 tileposition = (Vector2)tileAttributes[0];

        int animal = (int)tileAttributes[1];
        int owner = (int)tileAttributes[2];
        int currentrow = (int)tileposition[0];
        int currentcolumn = (int)tileposition[1];

        List<Vector2> possiblePositions = new List<Vector2>();

        if (animal == 1)
        {
            // lion
            // add up, down, right, left

            possiblePositions.Add(new Vector2(currentrow, currentcolumn + 1));
            possiblePositions.Add(new Vector2(currentrow, currentcolumn - 1));
            possiblePositions.Add(new Vector2(currentrow + 1, currentcolumn));
            possiblePositions.Add(new Vector2(currentrow - 1, currentcolumn));
            // diagonal directions	
            possiblePositions.Add(new Vector2(currentrow + 1, currentcolumn + 2));
            possiblePositions.Add(new Vector2(currentrow + 1, currentcolumn - 2));
            possiblePositions.Add(new Vector2(currentrow - 1, currentcolumn + 2));
            possiblePositions.Add(new Vector2(currentrow - 1, currentcolumn - 2));
        }
        else if (animal == 2)
        {
            // chick
            if (owner == 0)
            {
                possiblePositions.Add(new Vector2(currentrow, currentcolumn + 1));
            }
            if (owner == 1)
            {
                possiblePositions.Add(new Vector2(currentrow, currentcolumn - 1));
            }

        else if (animal == 3)
        {
            // elephant
            possiblePositions.Add(new Vector2(currentrow + 1, currentcolumn + 2));
            possiblePositions.Add(new Vector2(currentrow + 1, currentcolumn - 2));
            possiblePositions.Add(new Vector2(currentrow - 1, currentcolumn + 2));
            possiblePositions.Add(new Vector2(currentrow - 1, currentcolumn - 2));
        }
        else if (animal == 4)
        {
            // giraffe
            possiblePositions.Add(new Vector2(currentrow, currentcolumn + 1));
            possiblePositions.Add(new Vector2(currentrow, currentcolumn - 1));
            possiblePositions.Add(new Vector2(currentrow + 1, currentcolumn));
            possiblePositions.Add(new Vector2(currentrow - 1, currentcolumn));
        }
        else if (animal == 5)
        {
            // chicken

            possiblePositions.Add(new Vector2(currentrow, currentcolumn + 1));
            possiblePositions.Add(new Vector2(currentrow, currentcolumn - 1));
            possiblePositions.Add(new Vector2(currentrow + 1, currentcolumn));
            possiblePositions.Add(new Vector2(currentrow - 1, currentcolumn));
            // diagonal directions	
            possiblePositions.Add(new Vector2(currentrow + 1, currentcolumn + 2));
            possiblePositions.Add(new Vector2(currentrow - 1, currentcolumn + 2));
        }
            int length = possiblePositions.Count;
            int n = 0;

        while (n < length)
           {
                Vector2 temp = possiblePositions[n];
                if (temp[0] < 0 || temp[0] > 2 || temp[1] < 0 || temp[2] > 3)
                {
                    possiblePositions.RemoveAt(n);
                    length--;
                }
                n++;
            }
    }

}
}