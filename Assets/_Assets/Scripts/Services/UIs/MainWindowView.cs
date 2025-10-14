using TMPro;
using UnityEngine;

namespace _Assets.Scripts.Services.UIs
{
    public class MainWindowView : WindowView
    {
        [SerializeField] private TextMeshProUGUI positionText;

        public void SetText(string text) => positionText.text = text;
    }
}