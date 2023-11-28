using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScore : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int points;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void AddPoints(int newPoints)
    { 
        points += newPoints;
        if (points < 0) points = 0;
        text.text = "Score: " + points.ToString();
    }
}
