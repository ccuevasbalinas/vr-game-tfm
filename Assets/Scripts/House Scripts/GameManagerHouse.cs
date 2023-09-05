using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerHouse : MonoBehaviour
{
    public static int idBookPlacedCorrectly = 0;            // Id of the latest book placed in the bookshelf correctly.

    [Header("Puzzle no.1 Books in the bookshelf")]
    public GameObject[] books;                              // Array that contains all books of the puzzle.
    public GameObject[] clues;                              // Array that contains all clues for the following password' puzzle.
    public ScriptableEvent scriptableEventGameObject;       // Game objects associated to the puzzle once its has finished.

    private int _countBooksPlacedCorrectly = 0;             // Books placed in the bookshelf.


    // Function that put the correct books in the bookshelf.
    public void UpdateBookshelf()
    {
        // Increment the number of books placed correctly.
        _countBooksPlacedCorrectly++;

        Debug.Log(idBookPlacedCorrectly);

        // You've receive the ID of the book's placed in the bookshelf. Disable it and make appear its corresponding clue.
        books[idBookPlacedCorrectly - 1].SetActive(false);
        clues[idBookPlacedCorrectly - 1].SetActive(true);

        // If the number of books that has been placed in the bookshelf are four, i.e. all the books, it means the puzzle has been solved.
        if (_countBooksPlacedCorrectly == books.Length) scriptableEventGameObject.Raise();
    }
}
