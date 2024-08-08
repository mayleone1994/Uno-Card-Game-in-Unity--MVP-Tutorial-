using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CardGame_Uno
{
    // will be using Object Pool Pattern
    public class UnoCardFactory : MonoBehaviour
    {
        [SerializeField] private UnoCardInitializer _unoCardPrefab;
        [SerializeField] private RectTransform _tempHandArea; // temp!!

        private void Awake()
        {
            if (GameInitializer.Instance != null)
            {
                GameInitializer.Instance.DeckIsReady += CreateCards;
            }
        }

        private void CreateCards(Stack<UnoCardData> deck)
        {
            // temp boolean only to test for first time the whole system
            bool isPlayerCard = true;

            List<UnoCardData> sortedCards = Enumerable.Range(0, Constants.CARDS_PER_PLAYER).
                Select(_ => deck.Pop()).ToList();

            sortedCards = 
                sortedCards.OrderByDescending(card => card.Color).ThenByDescending(card => card.Type).ToList();

            foreach (var cardData in sortedCards)
            {
                UnoCardInitializer unoCardInstance = Instantiate(_unoCardPrefab, _tempHandArea);
                unoCardInstance.Initialize(cardData, isPlayerCard);
            }
        }

        private void OnDestroy()
        {
            if (GameInitializer.Instance != null)
            {

                GameInitializer.Instance.DeckIsReady -= CreateCards;
            }
        }
    }
}
