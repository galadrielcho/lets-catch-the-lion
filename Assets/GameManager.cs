using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int[,] array = new int[3, 4] { { 1, 2 }, { 3, 4 }, { 5, 6 }};
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Tuple<int, int> getNewLocation(string animal, Tuple<int, int> position)
    {
        if (animal == "giraffe") {
            

        }
    }
}
