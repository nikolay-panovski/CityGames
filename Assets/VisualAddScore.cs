using UnityEngine;
using TMPro;
using DG.Tweening;

public class VisualAddScore : MonoBehaviour
{
    private TextMeshProUGUI text;

    private Vector3 defaultPosition;

    public Color defaultColorOff;
    public Color maxColorGoodOn;
    public Color maxColorBadOn;

    public float maxYPosOffset;
    public float animDuration;

    private Sequence currentTweenSequence;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        defaultPosition = text.gameObject.transform.position;
    }

    public void ShowVisualScoreAdd(int addedScore)
    {
        if (currentTweenSequence != null) currentTweenSequence.Complete(withCallbacks: true);

        currentTweenSequence = DOTween.Sequence();

        bool isAddedScorePositive = addedScore > 0;
        text.text = isAddedScorePositive ? "+" + addedScore : "" + addedScore;
        Color usedColor = isAddedScorePositive ? maxColorGoodOn : maxColorBadOn;


        currentTweenSequence.Join(DOTween.To(() => text.color, x => text.color = x, usedColor, animDuration).SetLoops(2, LoopType.Yoyo));
        currentTweenSequence.Join(DOTween.To(() => text.gameObject.transform.position,
                    x => text.gameObject.transform.position = x,
                    new Vector3(text.gameObject.transform.position.x,
                                text.gameObject.transform.position.y - maxYPosOffset,
                                text.gameObject.transform.position.z),
                    animDuration * 4).SetEase(Ease.OutQuart)
                    .OnComplete(() => text.gameObject.transform.position = defaultPosition));
    }
}
