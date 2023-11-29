using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorseBlinkLoop : MonoBehaviour
{
    private Coroutine currentLoop;

    public List<Renderer> blinkers;
    public Material blinkMaterialOff;
    public Material blinkMaterialOn;

    public float timeUnit = 0.25f;
    private float BLINK_DOT;
    private float BLINK_DASH;
    private float BLINK_SPACE_LOCAL;    // between parts of the same letter, "LOCAL" is for brevity
    private float BLINK_SPACE_LETTERS;  // between letters
    private float BLINK_SPACE_REPEAT;   // between words, here "REPEAT" because one word loops at a time

    // IT:	    .. -
    // CITY:	-.-. .. - -.--
    // TRAIN:	- .-. .- .. -.

    // Start is called before the first frame update
    void Start()
    {
        BLINK_DOT = timeUnit * 1;
        BLINK_DASH = timeUnit * 3;
        BLINK_SPACE_LOCAL = timeUnit * 1;
        BLINK_SPACE_LETTERS = timeUnit * 3;
        BLINK_SPACE_REPEAT = timeUnit * 7;
    }

    public IEnumerator Loop(string word)
    {
        switch (word)
        {
            case "it":
                foreach (Renderer blinkerRenderer in blinkers)
                {
                    blinkerRenderer.material = blinkMaterialOn;
                    yield return new WaitForSeconds(BLINK_DOT);
                    blinkerRenderer.material = blinkMaterialOff;
                    yield return new WaitForSeconds(BLINK_SPACE_LOCAL);
                    blinkerRenderer.material = blinkMaterialOn;
                    yield return new WaitForSeconds(BLINK_DOT);

                    blinkerRenderer.material = blinkMaterialOff;
                    yield return new WaitForSeconds(BLINK_SPACE_LETTERS);
                    blinkerRenderer.material = blinkMaterialOn;
                    yield return new WaitForSeconds(BLINK_DASH);
                    blinkerRenderer.material = blinkMaterialOff;
                    yield return new WaitForSeconds(BLINK_SPACE_REPEAT);

                    StartNewWordLoop(word);
                }
                break;
            case "city":
                foreach (Renderer blinkerRenderer in blinkers)
                {
                    blinkerRenderer.material = blinkMaterialOn;
                    yield return new WaitForSeconds(BLINK_DASH);
                    blinkerRenderer.material = blinkMaterialOff;
                    yield return new WaitForSeconds(BLINK_SPACE_LOCAL);
                    blinkerRenderer.material = blinkMaterialOn;
                    yield return new WaitForSeconds(BLINK_DOT);
                    blinkerRenderer.material = blinkMaterialOff;
                    yield return new WaitForSeconds(BLINK_SPACE_LOCAL);
                    blinkerRenderer.material = blinkMaterialOn;
                    yield return new WaitForSeconds(BLINK_DASH);
                    blinkerRenderer.material = blinkMaterialOff;
                    yield return new WaitForSeconds(BLINK_SPACE_LOCAL);
                    blinkerRenderer.material = blinkMaterialOn;
                    yield return new WaitForSeconds(BLINK_DOT);

                    blinkerRenderer.material = blinkMaterialOff;
                    yield return new WaitForSeconds(BLINK_SPACE_LETTERS);
                    blinkerRenderer.material = blinkMaterialOn;
                    yield return new WaitForSeconds(BLINK_DOT);
                    blinkerRenderer.material = blinkMaterialOff;
                    yield return new WaitForSeconds(BLINK_SPACE_LOCAL);
                    blinkerRenderer.material = blinkMaterialOn;
                    yield return new WaitForSeconds(BLINK_DOT);

                    blinkerRenderer.material = blinkMaterialOff;
                    yield return new WaitForSeconds(BLINK_SPACE_LETTERS);
                    blinkerRenderer.material = blinkMaterialOn;
                    yield return new WaitForSeconds(BLINK_DASH);

                    blinkerRenderer.material = blinkMaterialOff;
                    yield return new WaitForSeconds(BLINK_SPACE_LETTERS);
                    blinkerRenderer.material = blinkMaterialOn;
                    yield return new WaitForSeconds(BLINK_DASH);
                    blinkerRenderer.material = blinkMaterialOff;
                    yield return new WaitForSeconds(BLINK_SPACE_LOCAL);
                    blinkerRenderer.material = blinkMaterialOn;
                    yield return new WaitForSeconds(BLINK_DOT);
                    blinkerRenderer.material = blinkMaterialOff;
                    yield return new WaitForSeconds(BLINK_SPACE_LOCAL);
                    blinkerRenderer.material = blinkMaterialOn;
                    yield return new WaitForSeconds(BLINK_DASH);
                    blinkerRenderer.material = blinkMaterialOff;
                    yield return new WaitForSeconds(BLINK_SPACE_LOCAL);
                    blinkerRenderer.material = blinkMaterialOn;
                    yield return new WaitForSeconds(BLINK_DASH);
                    blinkerRenderer.material = blinkMaterialOff;
                    yield return new WaitForSeconds(BLINK_SPACE_REPEAT);

                    StartNewWordLoop(word);
                }
                break;
            case "train":
                foreach (Renderer blinkerRenderer in blinkers)
                {
                    blinkerRenderer.material = blinkMaterialOn;
                    yield return new WaitForSeconds(BLINK_DASH);

                    blinkerRenderer.material = blinkMaterialOff;
                    yield return new WaitForSeconds(BLINK_SPACE_LETTERS);
                    blinkerRenderer.material = blinkMaterialOn;
                    yield return new WaitForSeconds(BLINK_DOT);
                    blinkerRenderer.material = blinkMaterialOff;
                    yield return new WaitForSeconds(BLINK_SPACE_LOCAL);
                    blinkerRenderer.material = blinkMaterialOn;
                    yield return new WaitForSeconds(BLINK_DASH);
                    blinkerRenderer.material = blinkMaterialOff;
                    yield return new WaitForSeconds(BLINK_SPACE_LOCAL);
                    blinkerRenderer.material = blinkMaterialOn;
                    yield return new WaitForSeconds(BLINK_DOT);

                    blinkerRenderer.material = blinkMaterialOff;
                    yield return new WaitForSeconds(BLINK_SPACE_LETTERS);
                    blinkerRenderer.material = blinkMaterialOn;
                    yield return new WaitForSeconds(BLINK_DOT);
                    blinkerRenderer.material = blinkMaterialOff;
                    yield return new WaitForSeconds(BLINK_SPACE_LOCAL);
                    blinkerRenderer.material = blinkMaterialOn;
                    yield return new WaitForSeconds(BLINK_DASH);

                    blinkerRenderer.material = blinkMaterialOff;
                    yield return new WaitForSeconds(BLINK_SPACE_LETTERS);
                    blinkerRenderer.material = blinkMaterialOn;
                    yield return new WaitForSeconds(BLINK_DOT);
                    blinkerRenderer.material = blinkMaterialOff;
                    yield return new WaitForSeconds(BLINK_SPACE_LOCAL);
                    blinkerRenderer.material = blinkMaterialOn;
                    yield return new WaitForSeconds(BLINK_DOT);

                    blinkerRenderer.material = blinkMaterialOff;
                    yield return new WaitForSeconds(BLINK_SPACE_LETTERS);
                    blinkerRenderer.material = blinkMaterialOn;
                    yield return new WaitForSeconds(BLINK_DASH);
                    blinkerRenderer.material = blinkMaterialOff;
                    yield return new WaitForSeconds(BLINK_SPACE_LOCAL);
                    blinkerRenderer.material = blinkMaterialOn;
                    yield return new WaitForSeconds(BLINK_DOT);
                    blinkerRenderer.material = blinkMaterialOff;
                    yield return new WaitForSeconds(BLINK_SPACE_REPEAT);

                    StartNewWordLoop(word);
                }
                break;
            default:
                if (currentLoop != null) StopCoroutine(currentLoop);   // in invalid OR COMPLETED cases don't run anything
                break;
        }
    }

    public void StartNewWordLoop(string word)
    {
        if (currentLoop != null) StopCoroutine(currentLoop);
        currentLoop = StartCoroutine(Loop(word));
    }
}
