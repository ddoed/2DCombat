using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    private Image _image;
    [SerializeField] private float drainTime = 0.25f;
    private float _target = 1;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void UpdateHPBar(int maxHP, int currentHP)
    {
        _target = (float)currentHP / maxHP;
        StartCoroutine(DrainHPBar());
    }

    public IEnumerator DrainHPBar()
    {
        float fillAmount = _image.fillAmount;

        Color currentColor = _image.color;

        float elapsedTime = 0f;
        while (elapsedTime < drainTime)
        {
            elapsedTime += Time.deltaTime;
            _image.fillAmount = Mathf.Lerp(fillAmount, _target, (elapsedTime / drainTime));

            yield return null;
        }
    }
}
