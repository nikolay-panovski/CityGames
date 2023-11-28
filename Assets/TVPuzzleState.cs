using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RiddleState
{
    TV_Q1           = 0,
    TV_Q2           = 1,
    TV_Q3           = 2,
    TV_COMPLETED    = 3,
    SCR_Q1          = 4,
    SCR_COMPLETED   = 5,
    MORSE_Q1        = 6,
    MORSE_Q2        = 7,
    MORSE_Q3        = 8,
    MORSE_COMPLETED = 9
}

public class TVPuzzleState : MonoBehaviour
{
    public int pointsOnAdvance;
    public int pointsOnComplete;

    public RoomTrigger thisRoom;
    public List<PhoneScreen> phoneScreensSprites;

    public RiddleState currentState = RiddleState.TV_Q1;
    public TVStaticDial tvDial;

    public GameObject currentQuestionSprite;
    public List<Sprite> questionsSprites;

    private PhoneController phone;

    // Start is called before the first frame update
    void Start()
    {
        phone = FindObjectOfType<PhoneController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdvanceState()
    {
        if (currentState < RiddleState.TV_COMPLETED)
        {
            currentState++;
            tvDial.ResetStatic();
            currentQuestionSprite.GetComponent<SpriteRenderer>().sprite = questionsSprites[(int)currentState];
            thisRoom.phoneScreen = phoneScreensSprites[(int)currentState];
            phone.UpdateScreen(thisRoom.phoneScreen);

            FindObjectOfType<UIScore>().AddPoints(pointsOnAdvance);
        }

        if (currentState == RiddleState.TV_COMPLETED)
        {
            FindObjectOfType<UIScore>().AddPoints(pointsOnAdvance);
            FindObjectOfType<UIScore>().AddPoints(pointsOnComplete);
        }
    }

    public void DisplayWrongAnswerScreen()
    {
        FindObjectOfType<UIScore>().AddPoints(-pointsOnAdvance / 5);
        phone.wrongAnswerScreen.gameObject.SetActive(true);
    }
}
