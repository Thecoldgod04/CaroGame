using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePiece : MonoBehaviour
{
    public GameObject X;
    public GameObject O;


    int childNumber = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && childNumber == 0)
        {         
            if (GameManager.gameOver == true)
            {
                return;
            }
            if (GameManager.turn == 0)
            {
                GameManager.turn = 1;

                GameObject theNewX = Instantiate(X, transform.position, Quaternion.identity);
                GameManager.xList.Add(theNewX);
                childNumber++;
                theNewX.gameObject.transform.parent = this.gameObject.transform;
                GameManager.modified = true;
            }
            else if (GameManager.turn == 1)
            {
                GameManager.turn = 0;

                GameObject theNewO = Instantiate(O, transform.position, Quaternion.identity);
                GameManager.oList.Add(theNewO);
                childNumber++;
                theNewO.gameObject.transform.parent = this.gameObject.transform;
                GameManager.modified = true;
            }
            //Debug.Log(GameManager.turn);
        }
    }
}
