using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrPuzzleState : MonoBehaviour
{
    public int pointsOnComplete;

    public List<string> correctAnswers;

    public RoomTrigger thisRoom;
    private PhoneController phone;
    public PhoneScreen phoneSuccessScreen;

    public TMP_InputField thisInputField;
    void Start()
    {
        phone = FindObjectOfType<PhoneController>();
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
            FindObjectOfType<UIScore>().AddPoints(pointsOnComplete);
            thisRoom.phoneScreen = phoneSuccessScreen;
            phone.UpdateScreen(thisRoom.phoneScreen);
        }
        else
        {
            FindObjectOfType<UIScore>().AddPoints(-pointsOnComplete / 10);
            phone.wrongAnswerScreen.gameObject.SetActive(true);
        }
    }
}
