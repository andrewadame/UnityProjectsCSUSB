using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GmeCtrlr : MonoBehaviour
{
    public GameObject twr;
    public float cost;

    public Transform[] waypoints;

    public float mxHlth;

    [SerializeField]
    float hlth;
    public float LrpSpd;

    public Image hlthImg;

    public float crntTwrCst;

    public Text mnyTxt;
    public float mny;

    private void Awake()
    {
        hlth = mxHlth;
        //hlthImg.fillAmount = hlth / mxHlth;
        hlthImg.fillAmount = Mathf.Lerp(hlthImg.fillAmount, hlth / mxHlth, LrpSpd * Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mnyTxt.text = "MONEY: " + mny.ToString();
    }

    public void TakeDamage(float dmg)
    {
        hlth -= dmg;
        hlthImg.fillAmount = hlth / mxHlth;
    }

    public void GveMny(float amt)
    {
        mny += amt;
    }
}
