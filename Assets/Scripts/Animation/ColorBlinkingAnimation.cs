using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Animation
{
    public class ColorBlinkingAnimation : MonoBehaviour
    {
        [SerializeField] private Color startColor;
        [SerializeField] private Color endColor;
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        private void Start()
        {
            StartCoroutine(Blinking());
        }
        
        private IEnumerator Blinking()
        {
            while (true)
            {
                spriteRenderer.DOColor(startColor, 2f);
                yield return new WaitForSeconds(2.5f);
                spriteRenderer.DOColor(endColor, 2f);
                yield return new WaitForSeconds(2.5f);
            }
        }
    }
}