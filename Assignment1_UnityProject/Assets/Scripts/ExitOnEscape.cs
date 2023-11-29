using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitOnEscape : MonoBehaviour
{
    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Call the ExitGame method
            ExitGame();
        }
    }

    void ExitGame()
    {
        // This method is called to exit the application
#if UNITY_EDITOR
        // If running in the Unity Editor, stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // If running in a built application, quit the application
            Application.Quit();
#endif
    }
}
