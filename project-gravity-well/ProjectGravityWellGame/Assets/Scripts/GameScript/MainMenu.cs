using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject optionsMenu;

    List<int> widths = new List<int>() {1920, 2560, 2560, 1280, 540};
    List<int> heights = new List<int>() {1080, 1440, 1080, 800, 960};
  
    public void Start()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToOptions()
    {
        mainPanel.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void SetScreenSize(int index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, fullscreen);
    }

    public void SetFullScreen(bool _fullscreen)
    {
        Screen.fullScreen = _fullscreen;
    }

}
