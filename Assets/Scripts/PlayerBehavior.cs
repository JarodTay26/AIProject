using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Linq;
using System.Runtime.CompilerServices;

public class PlayerBehavior : MonoBehaviour
{
    bool safeAIUsed = true;
    public class Player
    {
        public int card_played;
        public List<int> cards_owned = new List<int>();
        public int rank;
        public int score;

        public void Reset_cards()
        {
            cards_owned.Clear();
            cards_owned = new List<int>();
            for (int i = 1; i < 10; ++i)
            {
                cards_owned.Add(i);
            }
            card_played = 0;
        }
    }
    public Player[] Players = new Player[4];


    public GameObject playerOne;
    public GameObject playerTwo;
    public GameObject playerThree;
    public GameObject playerFour;

    public List<GameObject> PlayerPosition = new List<GameObject>();
    public Text cardTextOne; // for number selection (1-9) and scores
    public Text cardTextTwo;
    public Text cardTextThree;
    public Text cardTextFour;

    public Text scoreTextOne; // for each players score
    public Text scoreTextTwo;
    public Text scoreTextThree;
    public Text scoreTextFour;
    public int round_count = 0;
    private Vector3[] desiredPos = new Vector3[4];

    void Start(){
        //create 4 players

        Array.Clear(Players,0,Players.Length);

        int a = 1;
        for (int i = 0; i < 4; ++i)
        {
            Players[i] = new Player();
        }
        foreach (Player player in Players)
        {
            for (int i = 1; i < 10; ++i) {
                player.cards_owned.Add(i);
            }
            player.card_played = 0;
            player.rank = a;
            a++;
        }
        cardTextOne.text = "0";
        cardTextTwo.text = "0";
        cardTextThree.text = "0";
        cardTextFour.text = "0";

        scoreTextOne.text = "0";
        scoreTextTwo.text = "0";
        scoreTextThree.text = "0";
        scoreTextFour.text = "0";
        //desiredPos[0] = new Vector3(2.455911f, 0.45f, -0.229504f);
        for(int i = 0; i < desiredPos.Length;++i){
            desiredPos[i] = PlayerPosition[i].transform.position;
        }
    }
    void InputCardPlayed(int playerCard){
        if (round_count % 9 == 0)
        {
            foreach(Player player in Players)
            {
                player.Reset_cards();
            }
        }
        // Players[0].card_played = gameObject.GetComponent<AiRiskyDecisionScript>().PlayCard(Players[0].card_played, Players[1].card_played, Players[2].card_played, Players[3].card_played,
        // Players[0].rank,Players[1].rank,Players[2].rank,Players[3].rank);
        // Players[0].cards_owned.Remove(Players[0].card_played);
        // Players[1].card_played = 9;
        Players[0].card_played = playerCard;
        Players[0].cards_owned.Remove(Players[0].card_played);
        if(safeAIUsed){
            Players[1].card_played = gameObject.GetComponent<AiDecisionScript>().PlayCard(Players[1].card_played, Players[0].card_played, Players[2].card_played, Players[3].card_played);
            Players[1].cards_owned.Remove(Players[1].card_played);
        }
        else{
            Players[1].card_played = gameObject.GetComponent<AiRiskyDecisionScript>().PlayCard(Players[1].card_played, Players[0].card_played, Players[2].card_played, Players[3].card_played,
            Players[1].rank,Players[0].rank,Players[2].rank,Players[3].rank);
            Players[1].cards_owned.Remove(Players[1].card_played);
        }
        Players[2].card_played = gameObject.GetComponent<AiSmallestToBiggest>().PlayCard();
        Players[2].cards_owned.Remove(Players[2].card_played);
        Players[3].card_played = gameObject.GetComponent<AiBiggestToSmallest>().PlayCard();
        Players[3].cards_owned.Remove(Players[3].card_played);
    }
    void RenderCardPlayed(){
        cardTextOne.text = Players[0].card_played.ToString();
        cardTextTwo.text = Players[1].card_played.ToString();
        cardTextThree.text = Players[2].card_played.ToString();
        cardTextFour.text = Players[3].card_played.ToString();
        scoreTextOne.text = Players[0].score.ToString();
        scoreTextTwo.text = Players[1].score.ToString();
        scoreTextThree.text = Players[2].score.ToString();
        scoreTextFour.text = Players[3].score.ToString();
        switch(Players[0].rank){
            case 1:
                playerOne.transform.position = desiredPos[0];
                break;
            case 2:
                playerOne.transform.position = desiredPos[1];
                break;
            case 3:
                playerOne.transform.position = desiredPos[2];
                break;
            case 4:
                playerOne.transform.position = desiredPos[3];
                break;
        }
        switch(Players[1].rank){
            case 1:
                playerTwo.transform.position = desiredPos[0];
                break;
            case 2:
                playerTwo.transform.position = desiredPos[1];
                break;
            case 3:
                playerTwo.transform.position = desiredPos[2];
                break;
            case 4:
                playerTwo.transform.position = desiredPos[3];
                break;
        }
        switch(Players[2].rank){
            case 1:
                playerThree.transform.position = desiredPos[0];
                break;
            case 2:
                playerThree.transform.position = desiredPos[1];
                break;
            case 3:
                playerThree.transform.position = desiredPos[2];
                break;
            case 4:
                playerThree.transform.position = desiredPos[3];
                break;
        }
        switch(Players[3].rank){
            case 1:
                playerFour.transform.position = desiredPos[0];
                break;
            case 2:
                playerFour.transform.position = desiredPos[1];
                break;
            case 3:
                playerFour.transform.position = desiredPos[2];
                break;
            case 4:
                playerFour.transform.position = desiredPos[3];
                break;
        }
    }
    void GameLogic(){
        List<Player> round_cards = new List<Player>();
        List<Player> tied = new List<Player>();
        foreach (Player player in Players)
        {
            int check = 0;
            for (int i = 0; i < 4; ++i)
            {
                if (player  == Players[i])
                {
                    continue;
                }
                if ( player.card_played == Players[i].card_played)
                {
                    check++;
                }
            }
            if (check == 0)
            {
                round_cards.Add(player);
            }
            else
            {
                tied.Add(player);
            }
        }
        List<Player> sortedlist = round_cards.OrderBy(x => x.card_played).ToList();
        sortedlist.Reverse();
        List<Player> sortedtied = tied.OrderBy(x => x.rank).ToList();
        int current_rank = 1;
        foreach (Player player in sortedlist)
        {
            player.rank = current_rank;
            current_rank++;

        }
        foreach (Player player in sortedtied)
        {
            player.rank = current_rank;
            current_rank++;
        }
        foreach (Player player in Players)
        {
            if (player.rank != 4)
            {
                player.score++;
            }
        }
        round_count++;
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.T)&&round_count%9==0){
            safeAIUsed = !safeAIUsed;
        }
    }
    public void GameUpdate(int playerCard){
        InputCardPlayed(playerCard);
        GameLogic();
        RenderCardPlayed();
    }
}