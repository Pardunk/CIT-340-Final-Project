
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P_ButtonScript : MonoBehaviour
{
    //Paige worked on the Main Menu Script
    public void Play()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Paige_Scene");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();

#endif

    }

    public void Continue()
    {
        SceneManager.LoadScene("Paige_Scene");
    }

    public void Credits()
    {
        SceneManager.LoadScene("P_CreditsScene");
    }

    public void Back()
    {
        SceneManager.LoadScene("P_MainMenu");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("P_MainMenu");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("JM_Instructions");
    }
}


