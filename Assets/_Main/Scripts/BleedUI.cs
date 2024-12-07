using DG.Tweening;
using TMPro;
using UnityEngine;

public class BleedUI : MonoBehaviour
{
    [SerializeField] private Spike bleedSource;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Transform textUITrans;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    void OnEnable() {
        bleedSource.OnBleed += ShowBleedUI;
    }

    void OnDisable() {
        bleedSource.OnBleed -= ShowBleedUI;
    }
    
    void ShowBleedUI() {
        Debug.Log("Sasd");

        Sequence sequence = DOTween.Sequence()
            .Join(canvasGroup.DOFade(1, 0.5f).SetEase(Ease.OutBack))
            .Join(textUITrans.DOLocalMoveY(textUITrans.localPosition.y + 0.2f, 0.5f).SetEase(Ease.OutBack))
            .AppendInterval(1)
            .Append(canvasGroup.DOFade(0, 0.5f).SetEase(Ease.OutBack))
            .AppendCallback(() => textUITrans.localPosition = Vector3.zero);
    }
}
