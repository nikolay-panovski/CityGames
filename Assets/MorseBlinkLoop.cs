using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorseBlinkLoop : MonoBehaviour
{
    private Coroutine currentLoop;

    public List<Renderer> blinkers;
    public Material blinkMaterialOff;
    public Material blinkMaterialOn;
    public Material blinkMaterialEnd;

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
        foreach (Renderer blinkerRenderer in blinkers)  // scrapped, there is now only 1 renderer (this wouldn't work with 2 anyway)
        {
            switch (word)
            {
                case "it":
                    yield return BlinkSequence(blinkerRenderer, blinkMaterialOn, blinkMaterialOff,
                        BLINK_DOT, BLINK_SPACE_LOCAL, BLINK_DOT, BLINK_SPACE_LETTERS,
                        BLINK_DASH, BLINK_SPACE_REPEAT);
                    break;

                case "city":
                    yield return BlinkSequence(blinkerRenderer, blinkMaterialOn, blinkMaterialOff,
                        BLINK_DASH, BLINK_SPACE_LOCAL, BLINK_DOT, BLINK_SPACE_LOCAL, BLINK_DASH, BLINK_SPACE_LOCAL, BLINK_DOT, BLINK_SPACE_LETTERS,
                        BLINK_DOT, BLINK_SPACE_LOCAL, BLINK_DOT, BLINK_SPACE_LETTERS,
                        BLINK_DASH, BLINK_SPACE_LETTERS,
                        BLINK_DASH, BLINK_SPACE_LOCAL, BLINK_DOT, BLINK_SPACE_LOCAL, BLINK_DASH, BLINK_SPACE_LOCAL, BLINK_DASH, BLINK_SPACE_REPEAT);
                    break;

                case "train":
                    yield return BlinkSequence(blinkerRenderer, blinkMaterialOn, blinkMaterialOff,
                        BLINK_DASH, BLINK_SPACE_LETTERS,
                        BLINK_DOT, BLINK_SPACE_LOCAL, BLINK_DASH, BLINK_SPACE_LOCAL, BLINK_DOT, BLINK_SPACE_LETTERS,
                        BLINK_DOT, BLINK_SPACE_LOCAL, BLINK_DASH, BLINK_SPACE_LETTERS,
                        BLINK_DOT, BLINK_SPACE_LOCAL, BLINK_DOT, BLINK_SPACE_LETTERS,
                        BLINK_DASH, BLINK_SPACE_LOCAL, BLINK_DOT, BLINK_SPACE_REPEAT);
                    break;

                default:
                    if (currentLoop != null) StopCoroutine(currentLoop);
                    yield break;
            }
        }
        StartNewWordLoop(word);
    }

    // refactored with ChatGPT (i % 2 == 0 is a clever move, other than that I was lazy and dead set on doing it manually)
    // ... it still hallucinated a bit with the sequences above though
    private IEnumerator BlinkSequence(Renderer blinkerRenderer, Material onMaterial, Material offMaterial, params float[] durations)
    {
        for (int i = 0; i < durations.Length; i++)
        {
            if (i == durations.Length - 1) blinkerRenderer.material = blinkMaterialEnd;
            else blinkerRenderer.material = (i % 2 == 0) ? onMaterial : offMaterial;
            yield return new WaitForSeconds(durations[i]);
        }
    }

    public void StartNewWordLoop(string word)
    {
        if (currentLoop != null) StopCoroutine(currentLoop);
        currentLoop = StartCoroutine(Loop(word));
    }
}
