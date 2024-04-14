using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Animation
{
    public class TextAppearanceAnimation : MonoBehaviour
    {
        [SerializeField] private Text text;

        private void Awake()
        {
            if (text is null) return;
            var color = text.color;
            text.color = new Color(color.r, color.g, color.b, 0f);
        }

        private void Start()
        {
            if (text is null) return;
            StartCoroutine(FadeOutCoroutine());
        }
        
        private IEnumerator FadeOutCoroutine()
        {
            yield return new WaitForSeconds(2f);
            text.DOFade(1f, 1f);
        }
    }
}