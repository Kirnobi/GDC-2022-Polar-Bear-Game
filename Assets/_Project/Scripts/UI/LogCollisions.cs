using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class LogCollisions : MonoBehaviour
{
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    public void ChangeText(string collisionText)
    {
        _text.SetText(collisionText);
    }
}
