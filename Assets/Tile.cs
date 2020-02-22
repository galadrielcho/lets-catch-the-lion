using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerDownHandler
{
    public int tiletype;
    public int owner;   
    public Vector2 position;
    public int animal;


    public void OnPointerDown(PointerEventData eventData)
    {



        Debug.Log("Run");

        int[] tileAttributes = new int[4]{(int)position.x, (int)position.y, animal, owner};

        if (animal != 3) {
            if (GameManagerScript.turn == owner) {
                
                GameManagerScript.TileSelected = new Vector2((float)position.x, (float)position.y);

                GameManagerScript.Instance.getNewLocation(tileAttributes);

            }

        }
        else {
            GameManagerScript.Instance.board[(int)position.x, (int)position.y] = null;

            gameObject.SetActive(false);
        }
        }

}
