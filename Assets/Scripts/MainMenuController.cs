using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
   public void PlayGame()
    {
        //Parse it from string into an int:
        int selectedCharacter = 
        int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name); //this will get access to the name of the button that we press
       
        GameManager.instance.CharIndex = selectedCharacter; //we call on the GameManager object, and then its instance static object and then the method of GameManager and store selectedCharacter in it

        SceneManager.LoadScene("Gameplay");
    }
}
