using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPFinalizeState : MonoBehaviour
{
    public int pointsOnPPComplete = 1000;
    private PPJewel[] ppJewels;

    private PhoneController phone;

    private bool wasTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        ppJewels = FindObjectsOfType<PPJewel>(includeInactive: true);
        if (ppJewels.Length <= 0) Debug.LogError("0 jewels found, PPFinalize script will be buggy!!");

        phone = FindObjectOfType<PhoneController>();
    }

    // Update is called once per frame
    void Update()
    {
        int collectedJewels = 0;

        foreach (PPJewel j in ppJewels)
        {
            if (j.gameObject.activeInHierarchy)
            {
                collectedJewels++;
            }
        }

        if (wasTriggered == false && collectedJewels == ppJewels.Length)
        {
            Invoke(nameof(FinalizePP), 1.0f);
            wasTriggered = true;
        }
    }

    private void FinalizePP()
    {
        FindObjectOfType<UIScore>().AddPoints(pointsOnPPComplete);
        phone.UpdateScreen(phone.finalScreen);
        // force final screen on, because this is (likely) the end
        if (!phone.currentScreen.gameObject.activeInHierarchy) FindObjectOfType<GlobalInputHandler>().TogglePhoneDisplay();

        foreach (PPJewel j in ppJewels) j.gameObject.SetActive(false);

        this.gameObject.SetActive(false);
    }
}
