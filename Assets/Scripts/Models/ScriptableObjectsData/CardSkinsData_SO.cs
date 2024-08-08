using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CardGame_Uno
{
    [CreateAssetMenu(fileName = "New Card Skins Data", menuName = "Create new Model Data/Card Skin", order = 1)]

    public class CardSkinsData_SO : ScriptableObject
    {
        [SerializeField] private Sprite _verseCardSprite;
        [SerializeField] private List<CardSkinDataByColor> _skinDatasByColor;

        public Sprite VerseCardSprite => _verseCardSprite;
        public List<CardSkinDataByColor> SkinDatasByColor => _skinDatasByColor;

        public Sprite GetCardSpriteSkin(CardType cardType, CardColor cardColor)
        {
            var sprite = (from colorData in _skinDatasByColor
                          where colorData.Color == cardColor
                          from skinData in colorData.SkinDatas
                          where skinData.Type == cardType
                          select skinData.Sprite).FirstOrDefault();

            if (sprite == null)
            {
                Debug.LogWarning($"card type \"{cardType}\" with \"{cardColor}\" color was not found");
            }

            return sprite;
        }
    }

    [Serializable]
    public struct CardSkinDataByColor
    {
        public CardColor Color;
        public List<CardSkinData> SkinDatas;
    }

    [Serializable]
    public struct CardSkinData
    {
        public CardType Type;
        public Sprite Sprite;
    }
}
