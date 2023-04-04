using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragComponent : MonoBehaviour
{
    private Vector2 difference = Vector2.zero; //Dragging offset for mouse ScreenToWorldPoint
    public bool isCorrectlyPlaced = false; // Flag for whether the fuse is correctly placed

    PuzzleGameManager gameManager;
    public GameObject PuzzleBlockSpace; // Space for game object

    private Vector2 initialPosition; // Initial position of the fuse

    private void Awake()
    {
        gameManager = GameObject.Find("PuzzleGameManager").GetComponent<PuzzleGameManager>();
    }

    private void Start()
    {
        initialPosition = transform.position; // Get the initial position of the fuse
    }

    private void OnMouseDown()
    {
        if (PuzzleBlockSpace != null && (!isCorrectlyPlaced))
        {
            difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
        }

    }

    private void OnMouseDrag()
    {
        if (PuzzleBlockSpace != null && (!isCorrectlyPlaced))
        {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
        }
    }

    private void OnMouseUp()
    {
        if (PuzzleBlockSpace != null && (!isCorrectlyPlaced)) // Check if Fuse is being dragged
        {
            float distance = Vector2.Distance(PuzzleBlockSpace.transform.position, transform.position); // Calculate the distance between Fuse and the space

            if (distance <= 0.5f) // Check if Fuse is close enough to the space
            {
                isCorrectlyPlaced = true; // Set the flag for correct move to true
                transform.position = PuzzleBlockSpace.transform.position ; // Move the Fuse to the position of space
                gameManager.correctMove();
            }
            else
            {
                transform.position = initialPosition; // Reset the position of Fuse
            }
        }
    }

}
