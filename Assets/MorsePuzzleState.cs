using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MorsePuzzleState : MonoBehaviour
{
    public int pointsOnAdvance;
    public int pointsOnComplete;

    public RoomTrigger thisRoom;
    public List<PhoneScreen> phoneScreensSprites;

    public RiddleState currentState = RiddleState.MORSE_Q1;

    //public GameObject currentQuestionSprite;      // TODO replace with blinking
    //public List<Sprite> questionsSprites;

    private PhoneController phone;
    private MorseBlinkLoop loop;

    public List<string> correctAnswers;     // all correct answers at once, regardless of state, AKA no protection against
                                            // guessing any answer at any time (OR submitting the same answer 3 times)
    public TMP_InputField thisInputField;
    public List<TMP_InputField> allInputFields;

    // Start is called before the first frame update
    void Start()
    {
        phone = FindObjectOfType<PhoneController>();
        loop = GetComponent<MorseBlinkLoop>();

        loop.StartNewWordLoop(correctAnswers[0]);
    }

    public void AdvanceState()
    {
        if (currentState < RiddleState.MORSE_COMPLETED)
        {
            currentState++;
            int localCurrentState = (int)currentState - (int)RiddleState.MORSE_Q1;  // ~~because of the very clever idea to put all states in one enum
            thisInputField = allInputFields[Mathf.Min(localCurrentState, allInputFields.Count - 1)];    // ~~spaghetti
            loop.StartNewWordLoop(correctAnswers[localCurrentState]);   // ~~more spaghetti (this stops the loop gracefully after the last word because of switch/case handling in loop itself)
            thisRoom.phoneScreen = phoneScreensSprites[localCurrentState];
            phone.UpdateScreen(thisRoom.phoneScreen);

            FindObjectOfType<UIScore>().AddPoints(pointsOnAdvance); // also runs while the state is turning into COMPLETED,
                                                                    // so COMPLETED points = this + pointsOnComplete (as intended)
        }

        if (currentState == RiddleState.MORSE_COMPLETED)
        {
            FindObjectOfType<UIScore>().AddPoints(pointsOnComplete);
        }
    }

    public void DisplayWrongAnswerScreen()
    {
        FindObjectOfType<UIScore>().AddPoints(-pointsOnAdvance / 10);
        phone.wrongAnswerScreen.gameObject.SetActive(true);
    }

    public void CheckInputAnswerFromInputField()
    {
        CheckInputAnswer(thisInputField.text);
    }

    public void CheckInputAnswer(string answer)
    {
        bool isCorrectAnswer = false;

        foreach (string cAnswer in correctAnswers)
        {
            if (answer.ToLower() == cAnswer.ToLower())
            {
                isCorrectAnswer = true;
                break;
            }
        }

        if (isCorrectAnswer)
        {
            AdvanceState();
        }
        else
        {
            DisplayWrongAnswerScreen();
        }
    }
}
