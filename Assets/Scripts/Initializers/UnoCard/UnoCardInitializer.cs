using UnityEngine;

namespace CardGame_Uno
{
    public class UnoCardInitializer : MonoBehaviour
    {
        [SerializeField] private UnoCardView _view;

        private UnoCardData _data;
        private bool _isPlayerCard;

        public void Initialize(UnoCardData data, bool isPlayerCard)
        {
            _data = data;
            _isPlayerCard = isPlayerCard;
            SubscribeEvents();
            InitializeComponents();
        }

        private void SubscribeEvents()
        {
            if (GameInitializer.Instance != null)
            {
                GameInitializer.Instance.ResetGameHandler += DestroyCard;
            }
        }

        private void InitializeComponents()
        {
            _view.Initialize(_data, _data.Sprite, _data.VerseSprite, !_isPlayerCard);
        }

        private void DestroyCard()
        {

            Destroy(this.gameObject);
        }

        private void OnDestroy()
        {
            if (GameInitializer.Instance != null)
            {
                GameInitializer.Instance.ResetGameHandler -= DestroyCard;
            }
        }
    }
}
