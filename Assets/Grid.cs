using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

    public int[,] Grid;


    // Start is called before the first frame update
    void Start() {
        
        float screenHeightInUnits = Camera.main.orthographicSize * 2;
        float screenWidthInUnits = screenHeightInUnits * Screen.width/ Screen.height;


        
        int[,] array2D = new int[][,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };



    }

}