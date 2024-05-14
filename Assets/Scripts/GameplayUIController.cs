using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUIController : MonoBehaviour
{
   public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
        //or equivalently SceneManager.LoadScene(SceneManager.GetActiveScene().name); to restart current scene 
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
