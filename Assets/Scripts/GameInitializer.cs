using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame_Uno
{

    public class GameInitializer : MonobehaviourSingleton<GameInitializer>
    {
        // These data could be injected through DI, via some method
        [SerializeField] private CardSkinsData_SO _cardSkinsData;
        [SerializeField] private DeckData_SO _deckData;

        public Action ResetGameHandler;
        public Action<Stack<UnoCardData>> DeckIsReady;

        private void Start()
        {
            Initalize();
        }

        private void Initalize()
        {
            var deck = DeckPresenter.CreateDeck(_deckData, _cardSkinsData);
            DeckIsReady?.Invoke(deck);
        }

        public void Reset()
        {
            ResetGameHandler?.Invoke();
            Initalize();
        }
    }
}
