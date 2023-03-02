using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMessage : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameOver == true)
        {
            transform.Find("GameOver").gameObject.SetActive(true);
            transform.Find("Restart Button").gameObject.SetActive(true);
        }

        if(GameManager.turn == 1)
        {
            transform.Find("X turn").gameObject.SetActive(false);
            transform.Find("O turn").gameObject.SetActive(true);
        }
        else
        {
            transform.Find("X turn").gameObject.SetActive(true);
            transform.Find("O turn").gameObject.SetActive(false);
        }
    }
}
