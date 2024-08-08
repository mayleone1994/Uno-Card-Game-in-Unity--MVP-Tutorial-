using UnityEngine;

namespace CardGame_Uno
{
    [CreateAssetMenu(fileName = "New Uno Card Data", menuName = "Create new Model Data/Uno Card", order = 0)]
    public class UnoCardData_SO : ScriptableObject
    {
        [SerializeField] private CardType _type;
        [SerializeField] private CardColor _color;

        public CardType Type => _type;
        public CardColor Color => _color;

        public bool IsActionCard 
        { 
            get 
            {
                return (int)_type >= (int)CardType.BLOCK;
            } 
        }
    }

    public enum CardType
    {
        ZERO,
        ONE,
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        // actions
        BLOCK,
        REVERSE,
        PLUS_TWO,
        PLUS_FOUR,
        WILD    
    }

    public enum CardColor
    {
        RED,
        YELLOW,
        GREEN,
        BLUE,
        BLACK
    }
}


