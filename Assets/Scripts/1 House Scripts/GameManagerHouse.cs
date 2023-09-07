using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerHouse : MonoBehaviour
{
    #region Variables
    [Header("Puzzle no.1 Books in the bookshelf")]
    /// <summary>
    /// Id of the latest book placed in the bookshelf correctly.
    /// </summary>
    public static int idBookPlacedCorrectly = 0;            

    /// <summary>
    /// Array that contains all books of the puzzle.
    /// </summary>
    public GameObject[] books;                              

    /// <summary>
    /// Array that contains all clues for the following password' puzzle.
    /// </summary>
    public GameObject[] clues;                              

    /// <summary>
    /// Game objects associated to the puzzle once its has finished.
    /// </summary>
    public ScriptableEvent scriptableEventGameObject;       

    /// <summary>
    /// Books placed in the bookshelf.
    /// </summary>
    private int _countBooksPlacedCorrectly = 0;
    #endregion

    #region Functions
    /// <summary>
    /// Function that put the correct books in the bookshelf.
    /// </summary>
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
    #endregion
}
