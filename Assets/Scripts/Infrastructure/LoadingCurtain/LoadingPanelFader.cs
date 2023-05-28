using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPanelFader : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(Fade(2f));
    }

    IEnumerator Fade(float FadeTime)
    {
        float time = 0;
        float alpha;
        while (time <= FadeTime)
        {
            alpha = 1 - (time / FadeTime);
            _canvasGroup.alpha = alpha;
            time += Time.deltaTime;
            yield return null;
        }
    }

}
