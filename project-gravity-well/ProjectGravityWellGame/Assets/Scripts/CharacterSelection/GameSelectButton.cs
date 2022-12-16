using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSelectButton : MonoBehaviour
{
    //
    public TMP_Text Elimination, DeathMatch, CTF;

    public SpriteRenderer theSprite;

    public Sprite ButtonUp, ButtonDown;

    public bool isPressed;

    public float waitToPopUp;

    private float popupCounter;

    [SerializeField] int GameMode = 0;

    GameManager gameManager;

    [SerializeField] private AudioSource Button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() // checks if the button is pressed
    {
        if(isPressed)
        {
            popupCounter -= Time.deltaTime;
            if(popupCounter <= 0)
            {
                isPressed = false;
                theSprite.sprite = ButtonUp;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) // checks if the player is near the button
    {
        if(other.tag == "Player" && !isPressed)
        {
            PlayerController thePlayer = other.GetComponent<PlayerController>();

            if(thePlayer.rb.velocity.y < -.1f)
            {
                gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

                gameManager.gameMode = GameMode; // sets the game mode to whatever gets pressed

                Button.Play();

                if(GameMode == 0) // sets the text to active or inactive
                {
                    Elimination.gameObject.SetActive(true);
                    DeathMatch.gameObject.SetActive(false);
                    CTF.gameObject.SetActive(false);
                }
                if(GameMode == 1) // sets the text to active or inactive
                {
                    Elimination.gameObject.SetActive(false);
                    DeathMatch.gameObject.SetActive(true);
                    CTF.gameObject.SetActive(false);
                }
                if(GameMode == 2) // sets the text to active or inactive
                {
                    Elimination.gameObject.SetActive(false);
                    DeathMatch.gameObject.SetActive(false);
                    CTF.gameObject.SetActive(true);
                }

                isPressed = true;
                theSprite.sprite = ButtonDown;
                popupCounter = waitToPopUp;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player" && isPressed)
        {
            isPressed = false;
            theSprite.sprite = ButtonUp;
        }
    }
}
