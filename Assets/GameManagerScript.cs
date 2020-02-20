﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject circlePrefab;
    public GameObject canvas;
    private bool repeat = true;
    private GameObject[,] board = new GameObject[3, 4];
    public Sprite[] sprites;
    public static int turn = 0;
    private Vector2 newLocation;
    public List<Vector2> possibilities;
    public static GameManagerScript Instance;
    public Tile tileScript;


    void Awake()
    {
        Instance = this;
        float xcoord = -150f;
        int column = 0;
        int owner = 0;
        int subtract = 0;

        for (int i = 0; i < 6; i++)
        {
            GameObject tile = Instantiate(tilePrefab);

            tile.transform.position = new Vector3(xcoord, 100f - 100f * (i + subtract), 15f);

            tile.transform.SetParent(canvas.transform, false);
            
            tileScript = tile.GetComponent<Tile>();


            tileScript.owner = owner;

            if (i == 3)
            {
                tile.GetComponent<Image>().sprite = sprites[2];
                tileScript.animal = 2;


            }
            else if (i == 5)
            {
                tile.GetComponent<Image>().sprite = sprites[0];
                tileScript.animal = 0;

            }
            else
            {
                tile.GetComponent<Image>().sprite = sprites[i + subtract];
                tileScript.animal = i + subtract;

            }

            tile.transform.Rotate(0, 0, -90  + (180 * tileScript.owner));
            tile.transform.localScale = new Vector3(.9f, .9f, .9f);

            board[i + subtract, column] = tile;

            tileScript.position = new Vector2(i + subtract, column);

            if (i == 2)
            {
                xcoord = 150f;
                column = 3;
                owner = 1;
                subtract = -3;
            }


        }

        for (int x = 0; x < 2; x++)
        {
            GameObject chick = Instantiate(tilePrefab);
            chick.transform.position = new Vector3(-50f + 100 * x, 0f, 0f);

            chick.transform.SetParent(canvas.transform, false);

            board[1, x + 1] = chick;

            Tile tileScript = chick.GetComponent<Tile>();

            tileScript.owner = x;
            tileScript.animal = 3;

            tileScript.position = new Vector2(1, 1 + x);
            
            chick.GetComponent<Image>().sprite = sprites[3];


            chick.transform.Rotate(0, 0, -90  + (180 * tileScript.owner));
            chick.transform.localScale = new Vector3(.9f, .9f, .9f);




        }

    }

    
    
    public void  getNewLocation(int[] tileAttributes)
    {

        int currentrow = (int)tileAttributes[0];
        int currentcolumn = (int)tileAttributes[1];
        int animal = (int)tileAttributes[2];
        int owner = (int)tileAttributes[3];

        List<Vector2> possiblePositions = new List<Vector2>();

        if (animal == 1)
        {

            Debug.Log("Lion!");
            // lion
            // add up, down, right, left

            possiblePositions.Add(new Vector2(currentrow, currentcolumn + 1));
            possiblePositions.Add(new Vector2(currentrow, currentcolumn - 1));
            possiblePositions.Add(new Vector2(currentrow + 1, currentcolumn));
            possiblePositions.Add(new Vector2(currentrow - 1, currentcolumn));
            // // diagonal directions	
            possiblePositions.Add(new Vector2(currentrow + 1, currentcolumn + 1));
            possiblePositions.Add(new Vector2(currentrow + 1, currentcolumn - 1));
            possiblePositions.Add(new Vector2(currentrow - 1, currentcolumn + 1));
            possiblePositions.Add(new Vector2(currentrow - 1, currentcolumn - 1));
        }
        else if (animal == 3)
        {
            Debug.Log("Chick!");
            // chick
            // if (owner == 0)
            // {
            //     possiblePositions.Add(new Vector2(currentrow, currentcolumn + 1));

            // }
            
            possiblePositions.Add(new Vector2(currentrow, currentcolumn + 1));

            // if (owner == 1)
            // {
            //     possiblePositions.Add(new Vector2(currentrow, currentcolumn - 1));
            // }
        }

        else if (animal == 0)
        {

            Debug.Log("Elephant!");
            // // elephant
            // possiblePositions.Add(new Vector2(currentrow + 1, currentcolumn + 1));
            // possiblePositions.Add(new Vector2(currentrow + 1, currentcolumn - 1));
            // possiblePositions.Add(new Vector2(currentrow - 1, currentcolumn + 1)); 
            // possiblePositions.Add(new Vector2(currentrow - 1, currentcolumn - 1));
        }
        else if (animal == 2)
        {
            Debug.Log("Giraffe!");
            // giraffe
            // possiblePositions.Add(new Vector2(currentrow, currentcolumn + 1));
            // possiblePositions.Add(new Vector2(currentrow, currentcolumn - 1));
            // possiblePositions.Add(new Vector2(currentrow + 1, currentcolumn));
            // possiblePositions.Add(new Vector2(currentrow - 1, currentcolumn));
        }
        else if (animal == 4)
        {
            Debug.Log("Chicken!");
            // chicken

            // possiblePositions.Add(new Vector2(currentrow, currentcolumn + 1));
            // possiblePositions.Add(new Vector2(currentrow, currentcolumn - 1));
            // possiblePositions.Add(new Vector2(currentrow + 1, currentcolumn));
            // possiblePositions.Add(new Vector2(currentrow - 1, currentcolumn));
            // // diagonal directions	
            // possiblePositions.Add(new Vector2(currentrow + 1, currentcolumn + 1));
            // possiblePositions.Add(new Vector2(currentrow - 1, currentcolumn + 1));
        }

        
        int n = 0;
        int length = possiblePositions.Count;

        while (n<length)
        {
            Vector2 temp = possiblePositions[n];
            Debug.Log(temp);

            if (temp.x < 0 || temp.x > 2 || temp.y < 0 || temp.y > 3)
            {

                possiblePositions.Remove(temp);
                length--;
            }

            else if(board[(int)temp.x, (int)temp.y] != null)
            {
                if (board[(int)temp.x, (int)temp.y].GetComponent<Tile>().owner == owner)
                {
                    possiblePositions.Remove(temp);
                    length--;
                }
            }
            else
            {
                n++;
            }

        }

        
        possibilities = possiblePositions;
      


       //  StartCoroutine("chooseCircle");
    

}

    IEnumerator chooseCircle() {

        List<GameObject> circles = new List<GameObject>();
        foreach (Vector2 possibility in possibilities) {
            
            GameObject circle = Instantiate(circlePrefab);
            
            circle.transform.position = new Vector3(-150 + 100 * possibility.y, 100 - possibility.x * 100); // -  100x + 100

           if (board[(int)possibility.x, (int)possibility.y] != null) {
                circle.transform.SetParent(board[(int)possibility.x, (int)possibility.y].transform, false);

            }
           else
            {
                circle.transform.SetParent(canvas.transform, false);
            }
            circles.Add(circle);
    
        }
        
        while (!CircleScript.wasClicked) {
            yield return null;
        }

        newLocation = CircleScript.location;
        foreach (GameObject circle in circles) {
            Destroy(circle);
        }

        yield return null;




    }
}