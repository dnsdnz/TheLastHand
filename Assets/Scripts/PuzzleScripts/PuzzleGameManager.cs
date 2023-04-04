using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGameManager : MonoBehaviour
{
    public GameObject BlockHolder;
    public GameObject[] Blocks;

    [SerializeField]
    int totalBlock = 0;
    [SerializeField]
    int correctedBlocks = 0;

    public GameObject WinText;

    // Start is called before the first frame update
    void Start()
    {
        WinText.SetActive(false);
        totalBlock = BlockHolder.transform.childCount;
        Debug.Log(totalBlock);
        Blocks = new GameObject[totalBlock];

        for (int i = 0; i < Blocks.Length; i++)
        {
            Blocks[i] = BlockHolder.transform.GetChild(i).gameObject;
        }
        
    }

    public void correctMove()
    {
        correctedBlocks += 1;

        //Debug.Log("correct Move");

        if(correctedBlocks == totalBlock)
        {
            Debug.Log("You win!");
            WinText.SetActive(true);
        }
    }

    public void wrongMove()
    {
        correctedBlocks -= 1;
    }
}
