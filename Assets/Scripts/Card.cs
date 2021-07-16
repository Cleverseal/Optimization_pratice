using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public bool IsClosed { get; set; }

    public Suit Suit { get; private set; }

    public CardValue CardValue { get; private set; }

    public Card NextCard { get; set; }

    public Card PreviousCard { get; set; }

    public bool CheckCardSet()
    {
        return this.CardValue == CardValue.King && CheckNextCards(true);
    }

    public bool CheckMovingAbility()
    {
        return this.CheckNextCards(false);
    }

    private bool CheckNextCards(bool toTheEnd)
    {
        if (this.IsClosed) return false;
        if (this.NextCard)
        {
            var firstCheck = this.Suit == this.NextCard.Suit;
            var secondCheck = (int)this.CardValue - (int)this.NextCard.CardValue == 1;
            var thirdCheck = this.NextCard.CheckNextCards(toTheEnd);
            return firstCheck && secondCheck && thirdCheck;
        }
        else
        {
            return toTheEnd ? (int)this.CardValue == 2 : true;
        }
    }
}

public enum Suit
{
    Heart = 0,
    Spade = 1,
    Diamond = 2,
    Club = 3
}

public enum CardValue
{
    Ace = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    Jack = 11,
    Queen = 12,
    King = 13
}
