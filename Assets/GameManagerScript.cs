using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    // Get references to the prefabs that would be Instantiated
    public GameObject tilePrefab; 
    public GameObject circlePrefab;
    // Get reference to the canvas to set as a parent (to allow instantiated objects to be seen)
    public GameObject canvas;
    // Get references to animal images for tiles
    public Sprite[] animalImages;    

    // Get references to win screens for playerOne and playerTwo
    public GameObject playerOne;
    public GameObject playerTwo;
    
    // Multidimensional array that holds all the tile objects
    public GameObject[,] board = new GameObject[3, 4];

    public static int turn = 0; // Player turn
    public static Vector2 newLocation; // row, column location the player chooses from the orange circles
    public static Vector2 TileSelected; // row,column of the tile the player has clicked on in order to move somewhere 
    public static GameManagerScript Instance; // to allow the GetNewLocation function of the GameManagerScript be called from other scripts


    private List<Vector2> possibilities; // possibilities where orange circles could be placed
    private Tile tileScript; // script for Tiles

    void Awake()
    {
        Instance = this; // see above comment next to variable declaration)
        float xcoord = -150f;
        int column = 0;
        int owner = 0;
        int subtract = 0;

        playerOne.SetActive(false);
        playerTwo.SetActive(false);

        // Tiles are Instantiated into the grid.

        // Instantiate Giraffe, Elephant, and Lion tiles.
        for (int i = 0; i < 6; i++)
        {
            GameObject tile = Instantiate(tilePrefab);

            tile.transform.position = new Vector3(xcoord, 100f - 100f * (i + subtract), 15f);

            tile.transform.SetParent(canvas.transform, false);
            
            tileScript = tile.GetComponent<Tile>();


            tileScript.owner = owner;

            if (i == 3)
            {
                tile.GetComponent<Image>().sprite = animalImages[2];
                tileScript.animal = 2;


            }
            else if (i == 5)
            {
                tile.GetComponent<Image>().sprite = animalImages[0];
                tileScript.animal = 0;

            }
            else
            {
                tile.GetComponent<Image>().sprite = animalImages[i + subtract];
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


        // Instantiate chick tiles.
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
            
            chick.GetComponent<Image>().sprite = animalImages[3];


            chick.transform.Rotate(0, 0, -90  + (180 * tileScript.owner));
            chick.transform.localScale = new Vector3(.9f, .9f, .9f);




        }

    }

    

    // getNewLocation function is callled whe a tile is clicked. 
    // Judging by the attributes of the tile (what kind of animal, where in the grid is, which player it belongs to),
    // possibilities for what the player could choose to move a tile to are added to a list called possiblePositions.
    
    public void  getNewLocation(int[] tileAttributes)
    {

        int currentrow = tileAttributes[0];
        int currentcolumn = tileAttributes[1];
        int animal = (int)tileAttributes[2];
        int owner = (int)tileAttributes[3];

        List<Vector2> possiblePositions = new List<Vector2>();

        possiblePositions.Clear();

        
        if (animal == 1)
        {

            // lion
            // add up, down, right, left

            possiblePositions.Add(new Vector2(currentrow, currentcolumn + 1f));
            possiblePositions.Add(new Vector2(currentrow, currentcolumn - 1f));
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
            // // chick
            if (owner == 0)
            {
                Debug.Log(possiblePositions);


                Debug.Log(new Vector2((float)currentrow, (float)currentcolumn + 1));


                // This line of code freezes Unity when uncommmented. 
                // possiblePositions.Add(new Vector2((float)currentrow, (float)currentcolumn + 1));

            }

            else if (owner == 1)
            {
                // This line of code freezes Unity when uncommented. 
                // possiblePositions.Add(new Vector2(currentrow, currentcolumn - 1));
            }
        }
        else if (animal == 0)
        {

            // elephant
            possiblePositions.Add(new Vector2(currentrow + 1, currentcolumn + 1));
            possiblePositions.Add(new Vector2(currentrow + 1, currentcolumn - 1));
            possiblePositions.Add(new Vector2(currentrow - 1, currentcolumn + 1));
            possiblePositions.Add(new Vector2(currentrow - 1, currentcolumn - 1));
        }
        else if (animal == 2)
        {
            // giraffe
            possiblePositions.Add(new Vector2(currentrow, currentcolumn + 1));
            possiblePositions.Add(new Vector2(currentrow, currentcolumn - 1));
            possiblePositions.Add(new Vector2(currentrow + 1, currentcolumn));
            possiblePositions.Add(new Vector2(currentrow - 1, currentcolumn));
        }
        else if (animal == 4)
        {
            // chicken

            possiblePositions.Add(new Vector2(currentrow, currentcolumn + 1));
            possiblePositions.Add(new Vector2(currentrow, currentcolumn - 1));
            possiblePositions.Add(new Vector2(currentrow + 1, currentcolumn));
            possiblePositions.Add(new Vector2(currentrow - 1, currentcolumn));
            // diagonal directions	
            possiblePositions.Add(new Vector2(currentrow + 1, currentcolumn + 1));
            possiblePositions.Add(new Vector2(currentrow - 1, currentcolumn + 1));
        }


        int n = 0;
        int length = possiblePositions.Count;


        // Remove incorrect possibilities -- possibilities that were outside the array index or were on a tile that was owned by the same player.
        while (n < length)
        {
            Vector2 temp = possiblePositions[n];
            if (temp.x < 0 || temp.x > 2 || temp.y < 0 || temp.y > 3)
            {
                possiblePositions.Remove(temp);
                length--;
            }

            else if (board[(int)temp.x, (int)temp.y] != null)
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


        StartCoroutine("chooseCircle");
    

}
    // Player chooses a location to move to.
    IEnumerator chooseCircle() {

        // Circles are Instanstiated in the possible locations inside the list possiblePositions.

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
        
        // Circles all share a static variable saying whether one has been clicked or not.
        while (!CircleScript.wasClicked) {
            yield return null;
        }

        // Once one of the circles has been clicked, 
        // the newLocation stored inside the CircleScript static variable for a new location
        // is stored into GameManagerScript.
        // Then, the circles are destroyed.
        newLocation = CircleScript.location;
        foreach (GameObject circle in circles) {
            Destroy(circle);
        }

        yield return null;

        StartCoroutine("processNewLocation");




    }


    // Now we have the player's chosen location, tiles must be moved / checked for a capture or win.
    IEnumerator processNewLocation()
    {

        GameObject movingTile;

        movingTile = board[(int)TileSelected.x, (int)TileSelected.y];

        GameObject TileToMoveTo = board[(int)newLocation.x, (int)newLocation.y];
        Tile movingTileScript = movingTile.GetComponent<Tile>();


        Vector3 newPosition = new Vector3(-150 + 100 * newLocation.y, 100 - newLocation.x * 100, 15f);
        
        // If the player chooses to move to an empty tile, then simply move it there.
        if (TileToMoveTo == null)
        {
            if (turn == 0) {
                turn = 1;
            }
            else{
                turn = 1;
        }


            float timeSinceStarted = 0f;

            while (movingTile.transform.localPosition != newPosition)
            {
                timeSinceStarted += Time.deltaTime;
                movingTile.transform.localPosition = Vector3.Lerp(movingTile.transform.localPosition, newPosition, timeSinceStarted);

                yield return null;

            }

            movingTileScript.position = newLocation;
            board[(int)TileSelected.x, (int)TileSelected.y] = null;
            board[(int)newLocation.x, (int)newLocation.y] = movingTile;

        }


        // If the player moves to a tile with the Lion in it, capture it! And then open the win screen.
        else if (TileToMoveTo.GetComponent<Tile>().animal == 1)
        {


            float timeSinceStarted = 0f;

            while (movingTile.transform.localPosition != newPosition)
            {
                timeSinceStarted += Time.deltaTime;
                movingTile.transform.localPosition = Vector3.Lerp(movingTile.transform.localPosition, newPosition, timeSinceStarted);

                yield return null;

            }

            win();
                    }

        // If the player has chosen to move to a space that has the other player's tile in it...
        // move there and destroy the enemy's tile.
        else
        {

            float timeSinceStarted = 0f;

            while (movingTile.transform.position != newPosition)
            {
                timeSinceStarted += Time.deltaTime;
                movingTile.transform.position = Vector3.Lerp(movingTile.transform.position, newPosition, timeSinceStarted);

                yield return null;

                if (turn == 0) {
                    turn = 1;
                }
                else{
                    turn = 0;
                }
            }
            yield return null;
            Destroy(TileToMoveTo);

            board[(int)TileSelected.x, (int)TileSelected.y] = null;
            board[(int)newLocation.x, (int)newLocation.y] = movingTile;

        }
        
        CircleScript.wasClicked = false;
    }

    void win() {
        

        // Open suitable win screen. 

            if (turn == 0 )
        {
            playerOne.SetActive(true);

        }

            if (turn == 1)
        {
            playerTwo.SetActive(true);

        }

        }
    

}
