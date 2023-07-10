using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerHouse : MonoBehaviour
{
    public static int idBookPlacedCorrectly = 0;       // Id of the latest book placed in the bookshelf correctly.

    [Header("Puzzle no.1 Books in the bookshelf")]
    public GameObject[] books;               // Array that contains all books of the puzzle.

    private int _countBooksPlacedCorrectly = 0;            // Books placed in the bookshelf.


    // Function that put the correct books in the bookshelf.
    public void UpdateBookshelf()
    {
        // Increment the number of books placed correctly.
        _countBooksPlacedCorrectly++;

        // You've receive the ID of the book's placed in the bookshelf. Disable it.
        books[idBookPlacedCorrectly - 1].SetActive(false);
    }
}
