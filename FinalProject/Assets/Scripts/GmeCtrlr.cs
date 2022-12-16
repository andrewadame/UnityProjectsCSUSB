using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GmeCtrlr : MonoBehaviour
{
    public GameObject gmeStrtUI;
    public bool gmeStrt;
    public GameObject gameOverUI;
    public bool gmeOvr;

    // Start is called before the first frame update
    void Start()
    {
        gmeOvr = false;
        gmeStrt = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gmeStrt)
        {
            StartScreen();
        }

        if (gmeOvr && Input.anyKeyDown)
        {
            Restart();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }

    void StartScreen()
    {
        gmeStrtUI.SetActive(true);
        Time.timeScale = 0;

        if(Input.anyKeyDown)
        {
            gmeStrt = true;
            gmeStrtUI.SetActive(false);
            Time.timeScale = 1f;
        }

    }
}
