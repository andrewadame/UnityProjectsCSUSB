using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GmeCtrlr : MonoBehaviour
{
    public int laps;
    public Text winTxt;
    bool endGme = false;

    public Text cntdwn;
    public float tmeToStrt = 3f;
    public bool strtd = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tmeToStrt > 0)
        {
            tmeToStrt -= Time.deltaTime;
            cntdwn.text = Mathf.RoundToInt(tmeToStrt).ToString();
        }
        else
        {
            strtd = true;

            cntdwn.gameObject.SetActive(false);
        }


        if (endGme && Input.anyKeyDown)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void EndGame(int num)
    {
        endGme = true;
        winTxt.gameObject.SetActive(true);
        winTxt.text = "Player " + num + " wins! Press any key to restart!";
    }
}
