using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BookshelfSocketChecking : MonoBehaviour
{
    public ScriptableEvent OnBookPlacedCorrectly;               // Reference to a scriptable event for placing a book correctly.

    private string _tagBook;                                     // Tag that 'real' book of the bookshelf has.
    private XRSocketInteractor _socket;                         // Socket where the book is trying to be placed.
    private int _socketId;                                      // Identificator of the socket.
    private bool _checkingBook;                                 // Flag to controll the socket's book checking process.

    
    // At the beginning, extract the book' socket and its ID.
    void Start()
    {
        _socket = GetComponent<XRSocketInteractor>();
        _socketId = int.Parse(transform.name.Split(' ')[2]);
        _checkingBook = false;
        _tagBook = "Book";
        
    }

    // Update is called socketCheck() function to see if a book wants to be placed or not per frame
    void Update()
    {
        SocketCheck();
    }

    // Function used for says: "okey, a new book wants to be placed in the bookshelf. Can we put this book on it?"
    public void BookPlaced()
    {
        _checkingBook = true;
    }

    // Function that checks if a book has been placed correctly.
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
                    // If so, activate the event for placing the book correcly and desactivate the game object in order not to be 
                    // grabbed anymore because it has been placed right.
                    int pieceId = int.Parse(objName.transform.name.Split(' ')[1]);
                    GameManagerHouse.countBooksPlacedCorrectly++;
                    OnBookPlacedCorrectly.Raise();
                }
            }

            // Once we have chck if the book can be placed in the bookshelf or not, let's give the oportunity to another one.
            _checkingBook = false;
        }
    }
}
