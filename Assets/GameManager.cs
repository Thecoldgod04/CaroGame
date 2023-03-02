using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static List<GameObject> xList = new List<GameObject>();
    public static List<GameObject> oList = new List<GameObject>();

    private float xDistance;
    private float oDistance;

    public static bool modified = false;

    public static bool gameOver = false;

    public static int turn = 0;

    private void Start()
    {
        Debug.LogError("The number of x is: " + xList.Count);
        Debug.LogError("The number of o is: " + xList.Count);
    }

    // Update is called once per frame
    void Update()
    { 
        if(modified == true)
        {
            modified = false;
            Debug.Log("The number of x is now: " + xList.Count);
            //WinCheck();
            if (xList.Count >= 5)
            {
                WinCheck();
                
            }
        }

        //Reset all variable when game is over
        if(gameOver == true)
        {
            resetAll();
        }

        else if(xList.Count + oList.Count == 81)
        {
            //Draw
            Debug.LogError("Draw");
        }
    }

    void WinCheck()
    {
        for (int i = 0; i < xList.Count-1; i++)
        {
            for (int j = xList.Count-1; j >= i+1; j--)
            {
                Vector2 createdVector = xList[j].transform.position - xList[i].transform.position;
                float a = createdVector.x;
                float b = createdVector.y;
                float checkingDistance = Mathf.Sqrt(a * a + b * b);
                if(checkingDistance == 4 || checkingDistance == 4*Mathf.Sqrt(2))
                {
                    xDistance = checkingDistance;

                    //Create lines
                    Debug.DrawLine(xList[i].transform.position, xList[j].transform.position, Color.black, Mathf.Infinity);
                    LineCheck(i, createdVector, xDistance);
                }
            }
        }

        for (int i = 0; i < oList.Count - 1; i++)
        {
            for (int j = oList.Count - 1; j >= i + 1; j--)
            {
                Vector2 createdVector = oList[j].transform.position - oList[i].transform.position;
                float a = createdVector.x;
                float b = createdVector.y;
                float checkingDistance = Mathf.Sqrt(a * a + b * b);
                if (checkingDistance == 4 || checkingDistance == 4 * Mathf.Sqrt(2))
                {
                    oDistance = checkingDistance;

                    //Create lines
                    Debug.DrawLine(oList[i].transform.position, oList[j].transform.position, Color.black, Mathf.Infinity);
                    LineCheck(i, createdVector, oDistance);
                }
            }
        }
    }

    void LineCheck(int from, Vector2 dir, float dis)
    {
        int xOnLine = 1;
        int oOnLine = 1;

        RaycastHit2D[] xHit;
        RaycastHit2D[] oHit;

        Physics2D.queriesStartInColliders = false;

        xHit = Physics2D.RaycastAll(xList[from].transform.position, dir, dis);
        oHit = Physics2D.RaycastAll(oList[from].transform.position, dir, dis);
        foreach (RaycastHit2D xHitted in xHit)
        {
            if (xHitted.collider.tag == "XPiece")
            {
                xOnLine++;
            }
        }
        foreach (RaycastHit2D oHitted in oHit)
        {
            if (oHitted.collider.tag == "OPiece")
            {
                oOnLine++;
            }
        }

        if (xOnLine >= 5 || oOnLine >= 5)
        {
            //Win
            Debug.LogError("Win");
            gameOver = true;

            //If xOnline == 5 then x wins, the other case, o wins
        }
    }

    public void restartGame()
    {
        gameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Reset all stats when restart
    void resetAll()
    {
        //Set all the elements in the list of pieces to null
        for (int i = 0; i < xList.Count; i++)
        {
            xList.RemoveAt(i);
        }
        for (int j = 0; j < oList.Count; j++)
        {
            oList.RemoveAt(j);
        }

        //Reset the turn
        turn = 0;

        //Reset modified boolean
        modified = false;
    }

}
