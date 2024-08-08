using UnityEngine;

namespace CardGame_Uno
{

    public record UnoCardData
    {
        public readonly CardType Type;
        public readonly CardColor Color;
        public readonly bool IsActionCard;
        public readonly Sprite Sprite;
        public readonly Sprite VerseSprite;

        public UnoCardData(
            CardType type,
            CardColor color,
            bool isActionCard, 
            Sprite sprite,
            Sprite verseSprite)
        {
            Type = type;
            Color = color;
            IsActionCard = isActionCard;
            Sprite = sprite;
            VerseSprite = verseSprite;
        }
    }
}