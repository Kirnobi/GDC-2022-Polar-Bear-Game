using UnityEngine;
using TMPro;
using System.Collections;

[RequireComponent(typeof(CanvasGroup))]
public class DisplayCollisions : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private CanvasGroup _group;

    private void Awake()
    {
        _group = GetComponent<CanvasGroup>();
        _group.alpha = 0;
    }

    private IEnumerator AnimateCoroutine()
    {
        LeanTween.alphaCanvas(_group, 1, 0.5f);
        yield return new WaitForSeconds(1f);
        LeanTween.alphaCanvas(_group, 0, 0.5f);
    }

    public void ChangeText(string newText)
    {
        text.SetText(newText);
        StartCoroutine(AnimateCoroutine());
    }
}