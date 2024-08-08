using System.Collections.Generic;
using UnityEngine;


namespace CardGame_Uno
{
    [CreateAssetMenu(fileName = "New Deck Data", menuName = "Create new Model Data/Deck", order = 2)]
    public class DeckData_SO : ScriptableObject
    {
        [SerializeField] private int _cardsCopiesAmount = 4;
        [SerializeField] private List<UnoCardData_SO> _unoCards;

        public int CardsCopiesAmount => _cardsCopiesAmount;
        public List<UnoCardData_SO> UnoCards => _unoCards;
    }
}
