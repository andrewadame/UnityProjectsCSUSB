using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GmeCtrlr : MonoBehaviour
{
    public BseTwr twr;
    public BseTwr[] twrs;

    public Transform[] waypoints;

    public float mxHlth;

    [SerializeField]
    float hlth;
    public float LrpSpd;

    public Image hlthImg;
    [HideInInspector]
    public float crntTwrCst;

    public Text mnyTxt;
    public float mny;

    public float tmeBtwnSpwnLw;
    public float tmeBtwnSpwnHi;

    float cools;
    public GameObject spwnPos;
    public GameObject[] Enems;

    public bool gmeOvr;
    public GameObject gmeOvrUI;

    private void Awake()
    {
        hlth = mxHlth;
        hlthImg.fillAmount = hlth / mxHlth;
        //hlthImg.fillAmount = Mathf.Lerp(hlthImg.fillAmount, hlth / mxHlth, LrpSpd * Time.deltaTime);
        UpdateTwr(0);
        gmeOvr = false;
    }

    public void UpdateTwr(int i)
    {
        twr = twrs[i];
        crntTwrCst = twrs[i].cost;

    }

    void SpwnEnmy()
    {
        Instantiate(Enems[Random.Range(0, Enems.Length)], spwnPos.transform.position, Quaternion.Euler(0,0,-90));
        cools = Random.Range(tmeBtwnSpwnLw, tmeBtwnSpwnHi);

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mnyTxt.text = "MONEY: " + mny.ToString();
        if (!gmeOvr)
        {
            if (cools > 0)
            {
                cools -= Time.deltaTime;
            }
            else
            {
                SpwnEnmy();
            }
        }

        if(gmeOvr && Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void TakeDamage(float dmg)
    {
        hlth -= dmg;
        if(hlth <= 0)
        {
            gmeOvr = true;
            gmeOvrUI.SetActive(true);
            Time.timeScale = 0f;
        }
        hlthImg.fillAmount = hlth / mxHlth;
    }

    public void GveMny(float amt)
    {
        mny += amt;
    }
}
