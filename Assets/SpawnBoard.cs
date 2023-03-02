using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoard : MonoBehaviour
{
    public GameObject squares;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 9; i++)
        {
            for(int j = 0; j < 9; j++)
            {
                Vector2 pos = new Vector2(i, j);
                Instantiate(squares, pos, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
