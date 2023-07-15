using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AiBiggestToSmallest : MonoBehaviour
{
    private const int maxCards = 9;
    private bool[] cardsPlayed = new bool[maxCards];
    public void PlayCard(){
        for(int i = maxCards; i > -1;--i){
            if(!cardsPlayed[i]){
                gameObject.GetComponent<PlayerBehavior>().randomNumberTwo = i + 1;
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
