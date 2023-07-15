using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AiBiggestToSmallest : MonoBehaviour
{
    private const int maxCards = 9;
    private bool[] cardsPlayed = new bool[maxCards];
    public void PlayCard(){
        for(int i = maxCards - 1; i > -1;--i){
            if(!cardsPlayed[i]){
                gameObject.GetComponent<PlayerBehavior>().randomNumberThree = i + 1;
                cardsPlayed[i] = true;
                return;
            }
        }
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
