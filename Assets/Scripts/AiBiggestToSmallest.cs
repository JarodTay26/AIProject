using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AiBiggestToSmallest : MonoBehaviour
{
    private const int maxCards = 9;
    private bool[] cardsPlayed = new bool[maxCards];
    public int PlayCard(){
        for(int i = maxCards - 1; i > -1;--i){
            if(!cardsPlayed[i]){
                cardsPlayed[i] = true;
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
