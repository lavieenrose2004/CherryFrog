using DG.Tweening;
using TMPro;
using UnityEngine;

public class PlayerStatusFeedbackUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject textUIPrefab;

    void OnEnable() {
        player.OnStatusApplied += ShowFXUI;
    }

    void OnDisable() {
        player.OnStatusApplied -= ShowFXUI;
    }
    
    void ShowFXUI(string txt, Color color) {
        GameObject textUIObj = Instantiate(textUIPrefab, transform.position, Quaternion.identity, transform);
        Transform objTrans = textUIObj.transform;
        TMP_Text textField = textUIObj.GetComponent<TMP_Text>();

        textField.text = txt;
        textField.color = color;

        Sequence sequence = DOTween.Sequence()
            .Join(textField.DOFade(1, 0.5f).SetEase(Ease.OutBack))
            .Join(objTrans.DOLocalMoveY(objTrans.localPosition.y + 0.2f, 0.5f).SetEase(Ease.OutBack))
            .AppendInterval(1)
            .Append(textField.DOFade(0, 0.5f).SetEase(Ease.OutBack))
            .AppendCallback(() => objTrans.localPosition = Vector3.zero);
    }
}
