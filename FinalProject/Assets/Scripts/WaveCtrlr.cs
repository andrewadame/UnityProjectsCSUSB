using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Wave
{
    public string wvNme;
    public int nmOfEn;
    public GameObject[] enType;
    public float spwnIntrvl;
}

public class WaveCtrlr : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spwnPnt;

    private Wave crntWve;
    private int crntWveNm;
    private float nxtSpwnTmer;
    public Text wveNm;

    private bool cnSpwn = true;

    private void Update()
    {
        crntWve = waves[crntWveNm];
        spwnWve();

        //Find amount of enemys on map
        GameObject[] totEn = GameObject.FindGameObjectsWithTag("Enemy");
        if(totEn.Length == 0 && !cnSpwn && crntWveNm+1 != waves.Length)
        {
            crntWveNm++;
            cnSpwn = true;
        }

        wveNm.text = "Wave: " + crntWveNm.ToString();

    }

    void spwnWve()
    {
        if (cnSpwn && nxtSpwnTmer < Time.time)
        {
            GameObject rndEn = crntWve.enType[Random.Range(0, crntWve.enType.Length)];
            Transform rndPnt = spwnPnt[Random.Range(0, spwnPnt.Length)];
            Instantiate(rndEn, rndPnt.position, Quaternion.identity);
            crntWve.nmOfEn--;

            nxtSpwnTmer = Time.time + crntWve.spwnIntrvl;

            if(crntWve.nmOfEn == 0)
            {
                cnSpwn = false;
            }
        }
    }


}
