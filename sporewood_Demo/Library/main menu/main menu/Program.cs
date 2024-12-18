using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1); // Main Game Scene
    }

    public void ExitGame()
    {
        Debug.Log("Exiting Game..."); // Log for debugging in the editor
        Application.Quit(); // Exits the application
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}