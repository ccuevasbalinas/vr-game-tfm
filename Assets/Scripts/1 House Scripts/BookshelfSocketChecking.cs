using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BookshelfSocketChecking : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// Reference to a scriptable event for placing a book correctly.
    /// </summary>
    public ScriptableEvent OnBookPlacedCorrectly;               

    /// <summary>
    /// Tag that 'real' book of the bookshelf has.
    /// </summary>
    private string _tagBook;                                    

    /// <summary>
    /// Socket where the book is trying to be placed.
    /// </summary>
    private XRSocketInteractor _socket;                         

    /// <summary>
    /// Identificator of the socket.
    /// </summary>
    private int _socketId;                                     

    /// <summary>
    /// Flag to controll the socket's book checking process.
    /// </summary>
    private bool _checkingBook;
    #endregion

    #region Functions
    /// <summary>
    /// At the beginning, extract the book' socket and its ID.
    /// </summary>
    void Start()
    {
        _socket = GetComponent<XRSocketInteractor>();
        _socketId = int.Parse(transform.name.Split(' ')[2]);
        _checkingBook = false;
        _tagBook = "Book";
    }


    /// <summary>
    /// Every frame checks if in the socket has been placed a game object.
    /// </summary>
    void Update() => SocketCheck();


    /// <summary>
    /// Function used for says: "okey, a new book wants to be placed in the bookshelf. Can we put this book on it?"
    /// </summary>
    public void BookPlaced() => _checkingBook = true;


    /// <summary>
    /// Function that checks if a book has been placed correctly.
    /// </summary>
    public void SocketCheck()
    {
        // A new book is trying to be placed in the bookshelf. Let's check if it can or not..
        if (_checkingBook)
        {
            // Has the socket received a book to be placed in the bookshelf? 
            if ( _socket.GetOldestInteractableSelected() != null)
            {
                // If so, is the book that is trying to be placed in the socket from the bookshelft was actually a book?
                // (note: remember that there's more bojects to interact with that do not belong to the bokshelf. Just to make the game more difficult.)
                IXRSelectInteractable objName = _socket.GetOldestInteractableSelected();
                if (objName.transform.tag == _tagBook)
                {
                    // Which of the four books is the one that has been placed? Communicate to the GameManager by the ScriptableObject
                    int bookId = int.Parse(objName.transform.name.Split(' ')[1]);
                    Debug.Log("book ID: " + bookId);
                    GameManagerHouse.idBookPlacedCorrectly = bookId;
                    OnBookPlacedCorrectly.Raise();

                    // Make the mesh renderer of the gap's book visible. The idea is to disable the grabbable book and make visibility the one that is in the gap.
                    this.GetComponent<MeshRenderer>().enabled = true;
                    this.GetComponent<XRSocketInteractor>().enabled = false;
                }
            }

            // Once we have chck if the book can be placed in the bookshelf or not, let's give the oportunity to another one.
            _checkingBook = false;
        }
    }
    #endregion
}
