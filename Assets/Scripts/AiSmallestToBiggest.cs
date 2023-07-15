using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AiSmallestToBiggest : MonoBehaviour
{
    private const int maxCards = 9;
    private bool[] cardsPlayed = new bool[maxCards];
    // Start is called before the first frame update
    public void PlayCard(){
        for(int i = 0; i < maxCards;++i){
            if(!cardsPlayed[i]){
                gameObject.GetComponent<PlayerBehavior>().randomNumberTwo = i + 1;
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
