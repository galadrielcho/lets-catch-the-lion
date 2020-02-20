using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilescript : MonoBehaviour
{
    public void Clicky()
    {

        Tile script = GetComponent<Tile>();
        Debug.Log(script.animal);

        int[] tileAttributes = new int[4]{(int)script.position.x, (int)script.position.y, script.animal, script.owner };
        GameManagerScript.Instance.getNewLocation(tileAttributes);
        }

}
