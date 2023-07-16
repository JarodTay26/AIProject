using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AiSmallestToBiggest : MonoBehaviour
{
    private const int maxCards = 9;
    private bool[] cardsPlayed = new bool[maxCards];
    // Start is called before the first frame update
    public int PlayCard(){
        for(int i = 0; i < maxCards;++i){
            if(!cardsPlayed[i]){
                cardsPlayed[i] = true;
                if(i == 8){
                    Start();
                }
                return i + 1;
            }
        }
        return 0;
    }
    void Start()
    {
       Array.Clear(cardsPlayed,0,cardsPlayed.Length); 
    }

    // Update is called once per frame
    void Update()
    {

    }
}
