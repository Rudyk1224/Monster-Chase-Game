using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //instance is another class with methods, and is accessed by GameManager
    [SerializeField]
    private GameObject[] characters;

    private int _charIndex;
    public int CharIndex
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }
    private void Awake()
    {
        //We need a singleton pattern which is when we have only 1 copy of our game object (1 instance)
        if (instance == null)
        {
            instance = this; //instance will be set to THIS object's instance which is the static instance class
            DontDestroyOnLoad(gameObject); //when loading a new scene, do not destroy the gameObject (in this case gameObject=gameManager)
        }
        else
        {
            Destroy(gameObject); //if there's more than 1 copy, destroy the duplicate copy
        }
    }



    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading; 

    }


    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;

    }
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Gameplay")
        {
            Instantiate(characters[CharIndex]); //create the character at the charindex (charIndex is gotten from the MainMenuController Script and is gotten from pressing the button which then gets converted into an int)

        }
    }
}
