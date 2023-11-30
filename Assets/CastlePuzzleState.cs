using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastlePuzzleState : MonoBehaviour
{
    public int pointsOnComplete;

    public RoomTrigger thisRoom;
    public List<PhoneScreen> phoneScreensSprites;

    public RiddleState currentState = RiddleState.CASTLE_Q1;

    private PhoneController phone;

    // Start is called before the first frame update
    void Start()
    {
        phone = FindObjectOfType<PhoneController>();
    }

    public void AdvanceState()
    {
        if (currentState < RiddleState.CASTLE_COMPLETED)
        {
            currentState++;
            int localCurrentState = (int)currentState - (int)RiddleState.CASTLE_Q1;  // ~~see MorsePuzzleState for the spaghetti complaints
            thisRoom.phoneScreen = phoneScreensSprites[(int)localCurrentState];
            phone.UpdateScreen(thisRoom.phoneScreen);
            FindObjectOfType<GlobalInputHandler>().TogglePhoneDisplay();    // force quit the phone screen since it is more important to see the area after every question
        }

        if (currentState == RiddleState.CASTLE_COMPLETED)
        {
            FindObjectOfType<UIScore>().AddPoints(pointsOnComplete);
        }
    }
}
