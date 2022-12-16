using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    public Slider slider;

    public GameManager gameManager;

    private void Start()
    {
        SetMaxScore();
    }

    private void Update()
    {
        if (gameManager.gameMode == 1)
        {
            slider.value = gameObject.GetComponentInParent<PlayerHealth>().killCounter;
        }
        else if (gameManager.gameMode == 2)
        {
            slider.value = gameObject.GetComponentInParent<PlayerHealth>().scoreCounter;
        }
    }

    public void SetMaxScore()
    {
        slider.maxValue = gameManager.maxScore;
    }
}