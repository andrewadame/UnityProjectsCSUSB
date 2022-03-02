using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GmeCtrlr : MonoBehaviour
{

    public GameObject[] enemies;
    public float tmeBtwnSpwnLw = 0.5f;
    public float timeBtwnSpwnHi = 3f;

    float spwnCls;
    Vector2 bnds;
    Vector3 spwnPos;

    public Text screTxt;
    int scres = 0;

    public GameObject gameOverUI;
    public bool gmeOvr;

    // Start is called before the first frame update
    void Start()
    {
        bnds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        spwnCls = Random.Range(tmeBtwnSpwnLw, timeBtwnSpwnHi);
        screTxt.text = "Scores: " + scres.ToString();
        gmeOvr = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(spwnCls > 0)
        {
            spwnCls -= Time.deltaTime;
        }
        else
        {
            SpwnEn();
        }

        screTxt.text = "Scores: " + scres.ToString();

        if (gmeOvr && Input.anyKeyDown)
            Restart();
    }

    void SpwnEn()
    {
        spwnPos = new Vector3(Random.Range(-bnds.x + 1f, bnds.x - 1f), bnds.y + Random.Range(0.25f, 3f), 0f);
        Instantiate(enemies[Random.Range(0, enemies.Length)], spwnPos, Quaternion.Euler(0,0,180));
        spwnCls = Random.Range(tmeBtwnSpwnLw, timeBtwnSpwnHi);
    }

    public void AddScre(int amount)
    {
        scres += amount;
    }

    void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
}
