using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPanelFader : MonoBehaviour
{
    private Color _backColor;
    private Material _backMaterial;

    private TMP_Text _text;
    private Color _textColor;

    private void Awake()
    {
        _backMaterial = GetComponent<Image>().material;
        _text = GetComponentInChildren<TMP_Text>();
        _backColor = _backMaterial.color;
        _textColor = _text.color;
        StartCoroutine(Fade(2f));
    }

    IEnumerator Fade(float FadeTime)
    {
        float time = 0;
        float alpha;
        while (time <= FadeTime)
        {
            alpha = 1 - (time / FadeTime);
            _backColor.a = alpha;
            _textColor.a = alpha;
            _backMaterial.color = _backColor;
            _text.color = _textColor;
            time += Time.deltaTime;
            yield return null;
        }
    }

}
