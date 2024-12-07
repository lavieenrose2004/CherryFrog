using DG.Tweening;
using TMPro;
using UnityEngine;

public class PlayerStatusFeedbackUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Transform textUITrans;

    private TMP_Text textUI;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;

        textUI = textUITrans.GetComponent<TMP_Text>();
    }

    void OnEnable() {
        player.OnStatusApplied += ShowFXUI;
    }

    void OnDisable() {
        player.OnStatusApplied -= ShowFXUI;
    }
    
    void ShowFXUI(string txt, Color color) {
        textUI.text = txt;
        textUI.color = color;

        Sequence sequence = DOTween.Sequence()
            .Join(canvasGroup.DOFade(1, 0.5f).SetEase(Ease.OutBack))
            .Join(textUITrans.DOLocalMoveY(textUITrans.localPosition.y + 0.2f, 0.5f).SetEase(Ease.OutBack))
            .AppendInterval(1)
            .Append(canvasGroup.DOFade(0, 0.5f).SetEase(Ease.OutBack))
            .AppendCallback(() => textUITrans.localPosition = Vector3.zero);
    }
}
