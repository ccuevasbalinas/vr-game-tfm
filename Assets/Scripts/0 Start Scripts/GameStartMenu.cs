using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartMenu : MonoBehaviour
{
    #region Variables
    [Header("UI Pages")]
    public GameObject mainMenu;
    public GameObject scenes;
    public GameObject options;
    public GameObject about;

    [Header("Main Menu Buttons")]
    public Button startButton;
    public Button demoButton;
    public Button optionButton;
    public Button aboutButton;
    public Button quitButton;

    public List<Button> returnButtons;
    #endregion

    #region Functions
    /// <summary>
    /// Function that makes the five menu's button ready to be pressed.
    /// </summary>
    void Start()
    {
        // First enable the main menu.
        EnableMainMenu();

        // Second, make the main menu's button ready to be pressed.
        startButton.onClick.AddListener(StartGame);
        demoButton.onClick.AddListener(EnableDemoScenes);
        optionButton.onClick.AddListener(EnableOption);
        aboutButton.onClick.AddListener(EnableAbout);
        quitButton.onClick.AddListener(QuitGame);

        // Finally, make the others menus hidden.
        foreach (var item in returnButtons) item.onClick.AddListener(EnableMainMenu);
    }

    /// <summary>
    /// Function to go out from the game.
    /// </summary>
    public void QuitGame() => Application.Quit();

    /// <summary>
    /// Function to make the game starts.
    /// </summary>
    public void StartGame()
    {
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(1);
    }

    /// <summary>
    /// Function that hide all the menus.
    /// </summary>
    public void HideAll()
    {
        mainMenu.SetActive(false);
        scenes.SetActive(false);
        options.SetActive(false);
        about.SetActive(false);
    }

    /// <summary>
    /// Enable the main menu and hide the others.
    /// </summary>   
    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        scenes.SetActive(false);
        options.SetActive(false);
        about.SetActive(false);
    }

    /// <summary>
    /// Enable the scenes menu and hide the others.
    /// </summary> 
    public void EnableDemoScenes()
    {
        mainMenu.SetActive(false);
        scenes.SetActive(true);
        options.SetActive(false);
        about.SetActive(false);
    }

    /// <summary>
    /// Enable the options menu and hide the others.
    /// </summary> 
    public void EnableOption()
    {
        mainMenu.SetActive(false);
        scenes.SetActive(false);
        options.SetActive(true);
        about.SetActive(false);
    }

    /// <summary>
    /// Enable the about menu and hide the others.
    /// </summary> 
    public void EnableAbout()
    {
        mainMenu.SetActive(false);
        scenes.SetActive(false);
        options.SetActive(false);
        about.SetActive(true);
    }
    #endregion
}
