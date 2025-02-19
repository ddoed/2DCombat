using System.Collections;
using CustomUtility;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    [SerializeField] Image cooldownBG;
    [SerializeField] TextMeshProUGUI cooldownText;

    public float duration;
    public PlayerMeleeAttack baseAttack;

    private Tween cooldownTween;

    public virtual void Awake()
    {
        // 기본 공격 키 입력했을 때 함수를 실행
        InputUser.Instance.BaseAttack += AnimateCooldown;
    }

    public void AnimateCooldown()
    {
        if (cooldownTween == null)
        {
            // BG 애니메이션
            cooldownBG.fillAmount = 1;
            cooldownTween = cooldownBG.DOFillAmount(0, duration).OnComplete(() => cooldownTween = null);
            // Text 애니메이션
            StartCoroutine(TextCoolTime()); 
        }
    }

    public IEnumerator TextCoolTime()
    {
        float remain = duration;

        cooldownText.gameObject.SetActive(true);
        while (remain > 0)
        {
            cooldownText.text = remain.ToString("F0");
            yield return new WaitForSeconds(1f);
            remain--;
        }
        cooldownText.gameObject.SetActive(false);
    }
}
