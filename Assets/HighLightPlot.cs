using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLightPlot : MonoBehaviour
{
    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().color = new Color(0.75f, 0.75f, 0.75f, 1);
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}
