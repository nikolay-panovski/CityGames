using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrMonitorButton : MonoBehaviour
{
    public ScrMonitorSprite connectedScreen;
    public List<ScrMonitorSprite> allScreens;

    private void Start()
    {
        allScreens = new List<ScrMonitorSprite>();
        foreach (ScrMonitorSprite s in FindObjectsOfType<ScrMonitorSprite>(includeInactive: true))
        {
            allScreens.Add(s);
        }
    }

    public void OnClickToggleScreens()
    {
        foreach (ScrMonitorSprite s in allScreens)
        {
            if (s == connectedScreen) s.gameObject.SetActive(true);
            else s.gameObject.SetActive(false);
        }
    }
}
