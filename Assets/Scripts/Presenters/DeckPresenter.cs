using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CardGame_Uno
{
   public static class DeckPresenter
    {
        private static List<UnoCardData> _deckList;

        public static Stack<UnoCardData> CreateDeck(DeckData_SO deckData, CardSkinsData_SO skinData)
        {
            _deckList = new();

            foreach (var unoCard in deckData.UnoCards)
            {
                var cardCopies = CreateCardCopies(unoCard, deckData, skinData);
                _deckList.AddRange(cardCopies);
            }

            // deck will be shuffled
            _deckList.Shuffle();

            return new Stack<UnoCardData>(_deckList);
        }

        private static List<UnoCardData> CreateCardCopies(
            UnoCardData_SO cardData, 
            DeckData_SO deckData, 
            CardSkinsData_SO skinData)
        {
            List<UnoCardData> _ = new();

            for (int i = 0; i < deckData.CardsCopiesAmount; i++)
            {
                Sprite cardSprite = skinData.GetCardSpriteSkin(cardData.Type, cardData.Color);

                _.Add(new UnoCardData(cardData.Type,
                    cardData.Color,
                    cardData.IsActionCard,
                    cardSprite,
                    skinData.VerseCardSprite
                    ));
            }

            return _;
        }
    }
}
