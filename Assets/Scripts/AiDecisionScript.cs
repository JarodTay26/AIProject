using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AiDecisionScript : MonoBehaviour
{
    PlayerBehavior gameData;
    private const int playerCount = 4;
    private const int maxNumberOfCards = 9;
    private float[] valueTable = new float[maxNumberOfCards];
    private float[] currentValue = new float[maxNumberOfCards];
    private int currentNumberOfCards = maxNumberOfCards;
    private bool[,] cardTable = new bool[playerCount, maxNumberOfCards];

    int GameScore(int p, int p2, int p3, int p4){
        if(p == p2 || p == p3 || p == p4){
            return 0;
        }
        if(p > p2){
            return 1;
        }
        if(p > p3){
            return 1;
        }
        if(p > p4){
            return 1;
        }
        return 0;
    }
    void CalculateCurrentValue(){
        Array.Clear(currentValue,0,currentValue.Length);
        for(int i = 0; i < maxNumberOfCards; ++i){
            if(cardTable[0,i]){
                continue;
            }
            for(int j = 0; j < maxNumberOfCards; ++j){
                if(cardTable[1,j]){
                    continue;
                }
                for(int k = 0; k < maxNumberOfCards;++k){
                    if(cardTable[2,k]){
                        continue;
                    }
                    for(int l = 0; l < maxNumberOfCards;++l){
                        if(cardTable[3,l]){
                            continue;
                        }
                        currentValue[i] += GameScore(i,j,k,l);
                    }
                }
            }
            currentValue[i] /= currentNumberOfCards * currentNumberOfCards * currentNumberOfCards;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameData = gameObject.GetComponent<PlayerBehavior>();
        Array.Clear(cardTable, 0, cardTable.Length);
        CalculateCurrentValue();
        valueTable = currentValue;
    }

    // Update is called once per frame
    void Update()
    {
        //Get cards played and clear cards
        int optimalChoice = 0;
        //Lowest score for aggressive AI.
        //Highest score for passive AI
        //Need to account for played cards
        float optimalScore = currentValue[0] - valueTable[0];
        for(int i = 1; i < maxNumberOfCards && (optimalScore != 1 || optimalScore != 0); ++i){
            if(currentValue[i] == 0){
                optimalChoice = i;
                break;
            }
            if(currentValue[i] == 1){
                optimalChoice = i;
                break;
            }
            if(currentValue[i] - valueTable[i] > optimalScore){
                optimalScore = currentValue[i] - valueTable[i];
                optimalChoice = i;
            }
        }
        // Use optimal choice
        gameData.randomNumberOne = optimalChoice + 1;
    }
}
