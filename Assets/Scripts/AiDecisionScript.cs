using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AiDecisionScript : MonoBehaviour
{
    private const int playerCount = 4;
    private const int maxNumberOfCards = 9;
    private float[] valueTable = new float[maxNumberOfCards];
    private float[] currentValue = new float[maxNumberOfCards];
    private int currentNumberOfCards = maxNumberOfCards;
    private bool[,] cardTable = new bool[playerCount, maxNumberOfCards];

    int GameScore(int p, int p2, int p3, int p4)
    {
        if(p == p2){
            return 0;
        }
        if(p == p3){
            return 0;
        }
        if(p == p4){
            return 0;
        }
        if(p2 == p3 || p3 == p4 || p2 == p4){
            return 1;
        }
        if (p > p2)
        {
            return 1;
        }
        if (p > p3)
        {
            return 1;
        }
        if (p > p4)
        {
            return 1;
        }
        return 0;
    }
    void CalculateCurrentValue()
    {
        Array.Clear(currentValue, 0, currentValue.Length);
        for (int i = 0; i < maxNumberOfCards; ++i)
        {
            if (cardTable[0, i])
            {
                continue;
            }
            for (int j = 0; j < maxNumberOfCards; ++j)
            {
                if (cardTable[1, j])
                {
                    continue;
                }
                for (int k = 0; k < maxNumberOfCards; ++k)
                {
                    if (cardTable[2, k])
                    {
                        continue;
                    }
                    for (int l = 0; l < maxNumberOfCards; ++l)
                    {
                        if (cardTable[3, l])
                        {
                            continue;
                        }
                        currentValue[i] += GameScore(i, j, k, l);
                    }
                }
            }
            currentValue[i] /= currentNumberOfCards * currentNumberOfCards * currentNumberOfCards;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentNumberOfCards = maxNumberOfCards;
        Array.Clear(cardTable, 0, cardTable.Length);
        CalculateCurrentValue();
        for(int i =0; i < maxNumberOfCards;++i){
            valueTable[i] = currentValue[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
    }


    public int PlayCard(int cardPlayed1, int cardPlayed2, int cardPlayed3, int cardPlayed4)
    {
        if ((cardPlayed1 != 0) && (cardPlayed2 != 0) && (cardPlayed3 != 0) && (cardPlayed4 != 0))
        {
            --cardPlayed1;
            --cardPlayed2;
            --cardPlayed3;
            --cardPlayed4;
            cardTable[0,cardPlayed1] = true;
            cardTable[1,cardPlayed2] = true;
            cardTable[2,cardPlayed3] = true;
            cardTable[3,cardPlayed4] = true;
        }
        CalculateCurrentValue();
        int lowestUnplayedCard = maxNumberOfCards;
        for (int i = 0; i < maxNumberOfCards; ++i)
        {
            if (!cardTable[0, i])
            {
                lowestUnplayedCard = i;
                break;
            }
        }
        //Get cards played and clear cards
        int optimalChoice = lowestUnplayedCard;
        //Lowest score for aggressive AI.
        //Highest score for passive AI
        //Need to account for played cards
        float optimalScore = currentValue[lowestUnplayedCard] - valueTable[lowestUnplayedCard];
        for (int i = lowestUnplayedCard + 1; i < maxNumberOfCards && currentValue[lowestUnplayedCard] != 1 && currentValue[lowestUnplayedCard] != 0; ++i)
        {
            if (cardTable[0, i])
            {
                continue;
            }
            if (currentValue[i] == 0)
            {
                optimalChoice = i;
                break;
            }
            if (currentValue[i] == 1)
            {
                optimalChoice = i;
                break;
            }
            if (currentValue[i] - valueTable[i] > optimalScore)
            {
                optimalScore = currentValue[i] - valueTable[i];
                optimalChoice = i;
            }
        }
        // Use optimal choice
        --currentNumberOfCards;
        if(currentNumberOfCards == 0){
            Start();
        }  
        return optimalChoice + 1; 
    }
}