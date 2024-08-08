using UnityEngine;
using UnityEngine.UI;

namespace CardGame_Uno
{
    public class UnoCardView : MonoBehaviour
    {
        [SerializeField] private Image _imageComponent;
        [SerializeField] private Button _buttonComponent;

        private Sprite _currentSprite;
        private Sprite _verseSprite;
        private UnoCardData _data;

        private void Awake()
        {
            _buttonComponent.onClick.AddListener(DebugCardData);
        }

        public void Initialize(UnoCardData data, Sprite currentSprite, Sprite verseSprite, bool setVerseSprite = true)
        {
            _data = data;
            _currentSprite = currentSprite;
            _verseSprite = verseSprite;

            SetCardSprite(setVerseSprite ? _verseSprite : _currentSprite);
        }

        private void SetCardSprite(Sprite sprite)
        {
            _imageComponent.sprite = sprite;
        }

        // temp method
        private void DebugCardData()
        {
            Debug.Log($"<color=yellow>Card Type: {_data.Type}\nCard color: {_data.Color}\nIs action card: {string.Format(_data.IsActionCard ? "Yes" : "No")}</color>");
        }
    }
}
