using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;




public class PlayerBehavior : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;
    public GameObject playerThree;
    public GameObject playerFour;

    public Text codeTextOne; // for number selection (1-9) and scores
    public Text codeTextTwo;
    public Text codeTextThree;
    public Text codeTextFour;

    public Text scoreTextOne; // for each players score
    public Text scoreTextTwo;
    public Text scoreTextThree;
    public Text scoreTextFour;

    public float checkRadius = 0.25f;

    public static int scoreOne;
    public static int scoreTwo;
    public static int scoreThree;
    public static int scoreFour;

    private Vector3 desiredPos1 = new Vector3(2.455911f, 0.45f, -0.229504f);
    private Vector3 desiredPos2 = new Vector3(0.955911f, 0.45f, -0.229504f);
    private Vector3 desiredPos3 = new Vector3(-0.655911f, 0.45f, -0.229504f);
    private Vector3 desiredPos4 = new Vector3(-2.155911f, 0.45f, -0.229504f);

    public Vector3 targetPosition = new Vector3(-2.155911f, 0.45f, -0.229504f);

    //private Vector3 desiredPos5 = new Vector3(-3.655911f, 0.45f, -0.229504f);


    private Vector3 playerOneTempPos; 
    private Vector3 playerTwoTempPos; 
    private Vector3 playerThreeTempPos; 
    private Vector3 playerFourTempPos;

    private bool randomBool = false;

    public int randomNumberOne;
    public int randomNumberTwo;
    public int randomNumberThree;
    public int randomNumberFour;



    void Start(){
        codeTextOne.text = "0";
        codeTextTwo.text = "0";
        codeTextThree.text = "0";
        codeTextFour.text = "0";

        scoreTextOne.text = "0";
        scoreTextTwo.text = "0";
        scoreTextThree.text = "0";
        scoreTextFour.text = "0";
    }
    
    void GameLogic(){
        //Debug.Log(IsPlayerAtLocation(desiredPos5, 0.1f));
        
        // Generate a random integer between 1 and 10 using Random.Range, 10 exclusive 1 inclusive
        randomNumberTwo = Random.Range(1, 10);
        randomNumberThree = Random.Range(1, 10);
        randomNumberFour = Random.Range(1, 10);

        // private Vector3 playerOneTempPos; 
        // private Vector3 playerTwoTempPos; 
        // private Vector3 playerThreeTempPos; 
        // private Vector3 playerFourTempPos;
        // int randomNumberOne = 5;
        // int randomNumberTwo = 3;
        // int randomNumberThree = 5;
        // int randomNumberFour = 3;

        // int scoreOne = 0;
        // int scoreTwo = 0;
        // int scoreThree = 0;
        // int scoreFour = 0;

        // Convert the random number to a string, UI
        codeTextOne.text = randomNumberOne.ToString();
        codeTextTwo.text = randomNumberTwo.ToString();
        codeTextThree.text = randomNumberThree.ToString();
        codeTextFour.text = randomNumberFour.ToString();

        scoreTextOne.text = scoreOne.ToString();
        scoreTextTwo.text = scoreTwo.ToString();
        scoreTextThree.text = scoreThree.ToString();
        scoreTextFour.text = scoreFour.ToString();

        playerOne.transform.position = desiredPos1;
        playerTwo.transform.position = desiredPos2;
        playerThree.transform.position = desiredPos3;
        playerFour.transform.position = desiredPos4;

        playerOneTempPos = playerOne.transform.position;
        playerTwoTempPos = playerTwo.transform.position;
        playerThreeTempPos = playerThree.transform.position;
        playerFourTempPos = playerFour.transform.position;

        // 9 tie scenarios
        if ((randomNumberOne==randomNumberTwo) && (randomNumberOne!=randomNumberThree) && (randomNumberOne!=randomNumberFour) && (randomNumberThree!=randomNumberFour)){
               if (randomNumberThree < randomNumberFour){
                    playerThree.transform.position = desiredPos2;
                    playerThreeTempPos = playerThree.transform.position;

                    playerFour.transform.position = desiredPos1;
                    playerFourTempPos = playerFour.transform.position;
                }
                if (randomNumberFour < randomNumberThree){
                    playerThree.transform.position = desiredPos1;
                    playerThreeTempPos = playerFour.transform.position;

                    playerFour.transform.position = desiredPos2;
                    playerFourTempPos = playerFour.transform.position;
                }
            for (int i = 0; i < 2; i++){
                if (ArePositionsApproximatelyEqual(playerOneTempPos, desiredPos4, 0.1f) == false) {
                    if (ArePositionsApproximatelyEqual(playerOneTempPos, desiredPos3, 0.1f) && CheckPlayerPosition()){
                        randomBool = true;
                        Debug.Log("entered randombool true");
                    }
                // move playerOne back by 1.5f
                //Vector3 currentPosition1 = playerOne.transform.position;
                if (randomBool == false){
                        // Calculate the new position by adding the desired distance to the X coordinate
                    Vector3 newPosition1 = new Vector3(playerOneTempPos.x - 1.5f, playerOneTempPos.y, playerOneTempPos.z);
                           
                    // Move the GameObject to the new position
                    playerOne.transform.position = newPosition1;
                    //update playerOnePos
                    playerOneTempPos = playerOne.transform.position;
                }            
                }
                randomBool = false;
                if (ArePositionsApproximatelyEqual(playerTwoTempPos, desiredPos4, 0.1f) == false) {
                    if (ArePositionsApproximatelyEqual(playerTwoTempPos, desiredPos3, 0.1f) && CheckPlayerPosition()){
                        randomBool = true;
                        Debug.Log("entered randombool true");
                    }
                // move playerOne back by 1.5f
                //Vector3 currentPosition1 = playerOne.transform.position;
                if (randomBool == false){
                        // Calculate the new position by adding the desired distance to the X coordinate
                    Vector3 newPosition2 = new Vector3(playerTwoTempPos.x - 1.5f, playerTwoTempPos.y, playerTwoTempPos.z);
                           
                    // Move the GameObject to the new position
                    playerTwo.transform.position = newPosition2;
                    //update playerOnePos
                    playerTwoTempPos = playerTwo.transform.position;
                }   
                }
                randomBool = false;  
            }
        
            ScoreSettlement();
        }
            else if ((randomNumberOne==randomNumberThree) && (randomNumberOne!=randomNumberTwo) && (randomNumberOne!=randomNumberFour) && (randomNumberTwo!=randomNumberFour)){
                if (randomNumberTwo < randomNumberFour){
                    playerTwo.transform.position = desiredPos2;
                    playerTwoTempPos = playerTwo.transform.position;

                    playerFour.transform.position = desiredPos1;
                    playerFourTempPos = playerFour.transform.position;
                }
                if (randomNumberFour < randomNumberTwo){
                    playerTwo.transform.position = desiredPos1;
                    playerTwoTempPos = playerTwo.transform.position;

                    playerFour.transform.position = desiredPos2;
                    playerFourTempPos = playerFour.transform.position;
                }
                for (int i = 0; i < 2; i++){
                    if (ArePositionsApproximatelyEqual(playerOneTempPos, desiredPos4, 0.1f) == false){
                        Debug.Log(ArePositionsApproximatelyEqual(playerOneTempPos, desiredPos3, 0.1f));
                        if (ArePositionsApproximatelyEqual(playerOneTempPos, desiredPos3, 0.1f) && CheckPlayerPosition()){
                            randomBool = true;
                        }
                        if(randomBool == false){
                                // Calculate the new position by adding the desired distance to the X coordinate
                            Vector3 newPosition1 = new Vector3(playerOneTempPos.x - 1.5f, playerOneTempPos.y, playerOneTempPos.z);
                            
                            // Move the GameObject to the new position
                            playerOne.transform.position = newPosition1;
                            //update playerOnePos
                            playerOneTempPos = playerOne.transform.position;
                        }        
                    }
                    randomBool = false;
                    
                    if (ArePositionsApproximatelyEqual(playerThreeTempPos, desiredPos4, 0.1f) == false){
                        Debug.Log(ArePositionsApproximatelyEqual(playerThreeTempPos, desiredPos3, 0.1f));
                        if (ArePositionsApproximatelyEqual(playerThreeTempPos, desiredPos3, 0.1f) && CheckPlayerPosition()){
                            randomBool = true;
                        }
                        if (randomBool == false){
                                // Calculate the new position by adding the desired distance to the X coordinate
                            Vector3 newPosition3 = new Vector3(playerThreeTempPos.x - 1.5f, playerThreeTempPos.y, playerThreeTempPos.z);
                            
                            // Move the GameObject to the new position
                            playerThree.transform.position = newPosition3;
                            //update playerOnePos
                            playerThreeTempPos = playerThree.transform.position;
                        }    
               
                
                    }
                    randomBool = false;
                }
        
             

                ScoreSettlement();
            }
            else if ((randomNumberOne==randomNumberFour) && (randomNumberOne!=randomNumberThree) && (randomNumberOne!=randomNumberTwo) && (randomNumberTwo!=randomNumberThree)){
                if (randomNumberTwo < randomNumberThree){
                    playerTwo.transform.position = desiredPos2;
                    playerTwoTempPos = playerTwo.transform.position;

                    playerThree.transform.position = desiredPos1;
                    playerThreeTempPos = playerThree.transform.position;
                }
                if (randomNumberThree < randomNumberTwo){
                    playerTwo.transform.position = desiredPos1;
                    playerTwoTempPos = playerTwo.transform.position;

                    playerThree.transform.position = desiredPos2;
                    playerThreeTempPos = playerThree.transform.position;
                }
                for (int i = 0; i < 2; i++){
                    if (ArePositionsApproximatelyEqual(playerOneTempPos, desiredPos4, 0.1f) == false){
                        if(ArePositionsApproximatelyEqual(playerOneTempPos, desiredPos3, 0.1f) && CheckPlayerPosition()){
                            randomBool = true;
                        }
                    if (randomBool == false){
                           // Calculate the new position by adding the desired distance to the X coordinate
                        Vector3 newPosition1 = new Vector3(playerOneTempPos.x - 1.5f, playerOneTempPos.y, playerOneTempPos.z);
                           
                        // Move the GameObject to the new position
                        playerOne.transform.position = newPosition1;
                        //update playerOnePos
                        playerOneTempPos = playerOne.transform.position;
                    }   
                    randomBool = false;
                
                    }
                    if ((ArePositionsApproximatelyEqual(playerFourTempPos, desiredPos4, 0.1f) == false) && (IsPlayerAtLocation(desiredPos4, 0.5f) && (ArePositionsApproximatelyEqual(playerFourTempPos, desiredPos3, 0.1f) == false))){
                        if(ArePositionsApproximatelyEqual(playerFourTempPos, desiredPos3, 0.1f) && CheckPlayerPosition()){
                            randomBool = true;
                        }
                    if (randomBool == false){
                         // Calculate the new position by adding the desired distance to the X coordinate
                        Vector3 newPosition4 = new Vector3(playerFourTempPos.x - 1.5f, playerFourTempPos.y, playerFourTempPos.z);
                           
                        // Move the GameObject to the new position
                        playerFour.transform.position = newPosition4;
                        //update playerOnePos
                        playerFourTempPos = playerFour.transform.position;
                    }
                   
                    randomBool = false;
                    }
                }              
                ScoreSettlement();
            }
            else if ((randomNumberTwo==randomNumberThree) && (randomNumberTwo!=randomNumberOne) && (randomNumberTwo!=randomNumberFour) && (randomNumberOne!=randomNumberFour)) {
                //Debug.Log("should not enter this");
                if (randomNumberOne < randomNumberFour){
                    playerOne.transform.position = desiredPos2;
                    playerOneTempPos = playerOne.transform.position;

                    playerFour.transform.position = desiredPos1;
                    playerFourTempPos = playerFour.transform.position;
                }
                if (randomNumberFour < randomNumberOne){
                    playerOne.transform.position = desiredPos1;
                    playerOneTempPos = playerOne.transform.position;

                    playerFour.transform.position = desiredPos2;
                    playerFourTempPos = playerFour.transform.position;
                }
                for (int i = 0; i < 2; i++){
                    if (ArePositionsApproximatelyEqual(playerTwoTempPos, desiredPos4, 0.1f) == false){
                        Debug.Log(ArePositionsApproximatelyEqual(playerTwoTempPos, desiredPos3, 0.1f));
                        Debug.Log(CheckPlayerPosition());
                        if(ArePositionsApproximatelyEqual(playerTwoTempPos, desiredPos3, 0.1f) && CheckPlayerPosition()){
                            
                            randomBool = true;
                        }
                    if (randomBool == false){
                          // Calculate the new position by adding the desired distance to the X coordinate
                        Vector3 newPosition2 = new Vector3(playerTwoTempPos.x - 1.5f, playerTwoTempPos.y, playerTwoTempPos.z);
                           
                        // Move the GameObject to the new position
                        playerTwo.transform.position = newPosition2;
                        //update playerOnePos
                        playerTwoTempPos = playerTwo.transform.position;
                    }
                    randomBool = false;
                
                    }
                    if (ArePositionsApproximatelyEqual(playerThreeTempPos, desiredPos4, 0.1f) == false){
                        if(ArePositionsApproximatelyEqual(playerThreeTempPos, desiredPos3, 0.1f) && CheckPlayerPosition()){
                            randomBool = true;
                        }

                    if(randomBool == false){
                        // Calculate the new position by adding the desired distance to the X coordinate
                        Vector3 newPosition3 = new Vector3(playerThreeTempPos.x - 1.5f, playerThreeTempPos.y, playerThreeTempPos.z);
                           
                        // Move the GameObject to the new position
                        playerThree.transform.position = newPosition3;
                        //update playerOnePos
                        playerThreeTempPos = playerThree.transform.position;
                
                    }        
                    randomBool = false;
                    }
                }
        

                // make orange move 1.5f right
                           
                // Move the GameObject to the new position
                playerTwo.transform.position = new Vector3(playerTwoTempPos.x + 1.5f, playerTwoTempPos.y, playerTwoTempPos.z);
                //update playerOnePos
                playerTwoTempPos = playerTwo.transform.position;
                ScoreSettlement();
            }
            else if ((randomNumberTwo==randomNumberFour) && (randomNumberTwo!=randomNumberOne) && (randomNumberTwo!=randomNumberThree) && (randomNumberOne != randomNumberThree)){
                  if (randomNumberOne < randomNumberThree){
                    playerOne.transform.position = desiredPos2;
                    playerOneTempPos = playerOne.transform.position;

                    playerThree.transform.position = desiredPos1;
                    playerThreeTempPos = playerThree.transform.position;
                }
                if (randomNumberThree < randomNumberOne){
                    playerOne.transform.position = desiredPos1;
                    playerOneTempPos = playerOne.transform.position;

                    playerThree.transform.position = desiredPos2;
                    playerThreeTempPos = playerThree.transform.position;
                }
                for (int i = 0; i < 2; i++){
                    if (ArePositionsApproximatelyEqual(playerTwoTempPos, desiredPos4, 0.1f) == false)
                    {
                        if(ArePositionsApproximatelyEqual(playerTwoTempPos, desiredPos3, 0.1f) && CheckPlayerPosition()){
                            randomBool = true;
                        }
                    if(randomBool == false){
                          // Calculate the new position by adding the desired distance to the X coordinate
                        Vector3 newPosition2 = new Vector3(playerTwoTempPos.x - 1.5f, playerTwoTempPos.y, playerTwoTempPos.z);
                           
                        // Move the GameObject to the new position
                        playerTwo.transform.position = newPosition2;
                        //update playerOnePos
                        playerTwoTempPos = playerTwo.transform.position;
                    }
                    randomBool = false;
                
                    }
                     
                    if (ArePositionsApproximatelyEqual(playerFourTempPos, desiredPos4, 0.1f) == false){
                        if(ArePositionsApproximatelyEqual(playerTwoTempPos, desiredPos3, 0.1f) && CheckPlayerPosition()){
                            randomBool = true;
                        }
                    if(randomBool == false){
                        // Calculate the new position by adding the desired distance to the X coordinate
                        Vector3 newPosition4 = new Vector3(playerFourTempPos.x - 1.5f, playerFourTempPos.y, playerFourTempPos.z);
                           
                        // Move the GameObject to the new position
                        playerFour.transform.position = newPosition4;
                        //update playerOnePos
                        playerFourTempPos = playerFour.transform.position;
                    }    
                            
                    randomBool = false;
                
                    }
                }
        
             
                // Move the GameObject to the new position
                        playerTwo.transform.position = new Vector3(playerTwoTempPos.x + 1.5f, playerTwoTempPos.y, playerTwoTempPos.z);
                        //update playerOnePos
                        playerTwoTempPos = playerTwo.transform.position;
                ScoreSettlement();
            }
            else if ((randomNumberThree==randomNumberFour) && (randomNumberThree!=randomNumberOne) && (randomNumberThree!=randomNumberTwo)){
                for (int i = 0; i < 2; i++){
                    if ((ArePositionsApproximatelyEqual(playerThreeTempPos, desiredPos4, 0.1f) == false) && (IsPlayerAtLocation(desiredPos4, 0.5f) && (ArePositionsApproximatelyEqual(playerThreeTempPos, desiredPos3, 0.1f) == false))){
                            
                    // Calculate the new position by adding the desired distance to the X coordinate
                    Vector3 newPosition3 = new Vector3(playerThreeTempPos.x - 1.5f, playerThreeTempPos.y, playerThreeTempPos.z);
                           
                    // Move the GameObject to the new position
                    playerThree.transform.position = newPosition3;
                    //update playerOnePos
                    playerThreeTempPos = playerThree.transform.position;
                
                    }
                    if ((ArePositionsApproximatelyEqual(playerFourTempPos, desiredPos4, 0.1f) == false) && (IsPlayerAtLocation(desiredPos4, 0.5f) && (ArePositionsApproximatelyEqual(playerFourTempPos, desiredPos3, 0.1f) == false))){
                            
                    // Calculate the new position by adding the desired distance to the X coordinate
                    Vector3 newPosition4 = new Vector3(playerFourTempPos.x - 1.5f, playerFourTempPos.y, playerFourTempPos.z);
                           
                    // Move the GameObject to the new position
                    playerFour.transform.position = newPosition4;
                    //update playerOnePos
                    playerFourTempPos = playerFour.transform.position;
                
                    }
                }
        
           

                if (randomNumberOne < randomNumberTwo){
                    playerOne.transform.position = desiredPos2;
                    playerOneTempPos = playerOne.transform.position;

                    playerTwo.transform.position = desiredPos1;
                    playerTwoTempPos = playerTwo.transform.position;
                }
                if (randomNumberTwo < randomNumberOne){
                    playerOne.transform.position = desiredPos1;
                    playerOneTempPos = playerOne.transform.position;

                    playerTwo.transform.position = desiredPos2;
                    playerTwoTempPos = playerTwo.transform.position;
                }
                ScoreSettlement();
            }
            else if ((randomNumberOne==randomNumberTwo) && (randomNumberOne==randomNumberThree)){
                playerFour.transform.position = desiredPos1;
                playerFourTempPos = playerTwo.transform.position;
                for (int i = 0; i < 3; i++){
                    if (ArePositionsApproximatelyEqual(playerOneTempPos, desiredPos4, 0.1f) == false) {
                        if(ArePositionsApproximatelyEqual(playerOneTempPos, desiredPos3, 0.1f) && CheckPlayerPosition()){
                            randomBool = true;
                        }
                    if(randomBool == false){
                         // Calculate the new position by adding the desired distance to the X coordinate
                        Vector3 newPosition1 = new Vector3(playerOneTempPos.x - 1.5f, playerOneTempPos.y, playerOneTempPos.z);
                           
                        // Move the GameObject to the new position
                        playerOne.transform.position = newPosition1;
                        //update playerOnePos
                        playerOneTempPos = playerOne.transform.position;
                    }
                   
                    randomBool = false;
                    }
                    if ((ArePositionsApproximatelyEqual(playerTwoTempPos, desiredPos4, 0.1f) == false)){
                        if(ArePositionsApproximatelyEqual(playerTwoTempPos, desiredPos3, 0.1f) && CheckPlayerPosition()){
                            randomBool = true;
                        }
                    if (randomBool == false){
                          // Calculate the new position by adding the desired distance to the X coordinate
                        Vector3 newPosition2 = new Vector3(playerTwoTempPos.x - 1.5f, playerTwoTempPos.y, playerTwoTempPos.z);
                           
                        // Move the GameObject to the new position
                        playerTwo.transform.position = newPosition2;
                        //update playerOnePos
                        playerTwoTempPos = playerTwo.transform.position;
                
                    }     
                    randomBool = false;
                    }

                if ((ArePositionsApproximatelyEqual(playerThreeTempPos, desiredPos4, 0.1f) == false)){
                    if(ArePositionsApproximatelyEqual(playerTwoTempPos, desiredPos3, 0.1f) && CheckPlayerPosition()){
                            randomBool = true;
                        }
                    if(randomBool == false){
                         // Calculate the new position by adding the desired distance to the X coordinate
                        Vector3 newPosition3 = new Vector3(playerThreeTempPos.x - 1.5f, playerThreeTempPos.y, playerThreeTempPos.z);
                           
                        // Move the GameObject to the new position
                        playerThree.transform.position = newPosition3;
                        //update playerOnePos
                        playerThreeTempPos = playerThree.transform.position;
                    }    
                            
                    randomBool = false;
                
                    }
                }
            // move red by 3.0f, orange by 3.0f          
                        // Move the GameObject to the new position
                        playerOne.transform.position = new Vector3(playerOneTempPos.x + 3.0f, playerOneTempPos.y, playerOneTempPos.z);
                        //update playerOnePos
                        playerOneTempPos = playerOne.transform.position;
                  
                        // Move the GameObject to the new position
                        playerTwo.transform.position =  new Vector3(playerTwoTempPos.x + 3.0f, playerTwoTempPos.y, playerTwoTempPos.z);
                        //update playerOnePos
                        playerTwoTempPos = playerTwo.transform.position;

            
            ScoreSettlement();
            }
            else if ((randomNumberOne==randomNumberTwo) && (randomNumberOne==randomNumberFour)){
                playerThree.transform.position = desiredPos1;
                playerThreeTempPos = playerThree.transform.position;
                for (int i = 0; i < 3; i++){
                    if ((ArePositionsApproximatelyEqual(playerOneTempPos, desiredPos4, 0.1f) == false) && (IsPlayerAtLocation(desiredPos4, 0.5f) && (ArePositionsApproximatelyEqual(playerOneTempPos, desiredPos3, 0.1f) == false))){
                            
                    // Calculate the new position by adding the desired distance to the X coordinate
                    Vector3 newPosition1 = new Vector3(playerOneTempPos.x - 1.5f, playerOneTempPos.y, playerOneTempPos.z);
                           
                    // Move the GameObject to the new position
                    playerOne.transform.position = newPosition1;
                    //update playerOnePos
                    playerOneTempPos = playerOne.transform.position;
                
                    }
                    if ((ArePositionsApproximatelyEqual(playerTwoTempPos, desiredPos4, 0.1f) == false) && (IsPlayerAtLocation(desiredPos4, 0.5f) && (ArePositionsApproximatelyEqual(playerTwoTempPos, desiredPos3, 0.1f) == false))){
                            
                    // Calculate the new position by adding the desired distance to the X coordinate
                    Vector3 newPosition2 = new Vector3(playerTwoTempPos.x - 1.5f, playerTwoTempPos.y, playerTwoTempPos.z);
                           
                    // Move the GameObject to the new position
                    playerTwo.transform.position = newPosition2;
                    //update playerOnePos
                    playerTwoTempPos = playerTwo.transform.position;
                
                    }
                    if ((ArePositionsApproximatelyEqual(playerFourTempPos, desiredPos4, 0.1f) == false) && (IsPlayerAtLocation(desiredPos4, 0.5f) && (ArePositionsApproximatelyEqual(playerFourTempPos, desiredPos3, 0.1f) == false))){
                            
                    // Calculate the new position by adding the desired distance to the X coordinate
                    Vector3 newPosition4 = new Vector3(playerFourTempPos.x - 1.5f, playerFourTempPos.y, playerFourTempPos.z);
                           
                    // Move the GameObject to the new position
                    playerFour.transform.position = newPosition4;
                    //update playerOnePos
                    playerFourTempPos = playerFour.transform.position;
                
                    }
                }
          
                
                   // move red by 3.0f, orange by 3.0f          
                        // Move the GameObject to the new position
                        playerOne.transform.position = new Vector3(playerOneTempPos.x + 3.0f, playerOneTempPos.y, playerOneTempPos.z);
                        //update playerOnePos
                        playerOneTempPos = playerOne.transform.position;
                  
                        // Move the GameObject to the new position
                        playerTwo.transform.position =  new Vector3(playerTwoTempPos.x + 3.0f, playerTwoTempPos.y, playerTwoTempPos.z);
                        //update playerOnePos
                        playerTwoTempPos = playerTwo.transform.position;
                ScoreSettlement();
            }
            else if ((randomNumberTwo==randomNumberThree) && (randomNumberTwo==randomNumberFour)){
                for (int i = 0; i < 3; i++){
                    if (ArePositionsApproximatelyEqual(playerTwoTempPos, desiredPos4, 0.1f) == false){
                        if (IsPlayerAtLocation(desiredPos4, 0.5f) && ArePositionsApproximatelyEqual(playerTwoTempPos, desiredPos3, 0.1f)){
                            randomBool = true;
                        }
                    if(randomBool == false){
                         // Calculate the new position by adding the desired distance to the X coordinate
                        Vector3 newPosition2 = new Vector3(playerTwoTempPos.x - 1.5f, playerTwoTempPos.y, playerTwoTempPos.z);
                           
                        // Move the GameObject to the new position
                        playerTwo.transform.position = newPosition2;
                        //update playerOnePos
                        playerTwoTempPos = playerTwo.transform.position;
                    }        
                   
                
                    }
                    randomBool = false;
                    if (ArePositionsApproximatelyEqual(playerThreeTempPos, desiredPos4, 0.1f) == false){
                        if (IsPlayerAtLocation(desiredPos4, 0.5f) && ArePositionsApproximatelyEqual(playerThreeTempPos, desiredPos3, 0.1f)){
                            randomBool = true;
                        }
                    if (randomBool == false){
                           // Calculate the new position by adding the desired distance to the X coordinate
                        Vector3 newPosition3 = new Vector3(playerThreeTempPos.x - 1.5f, playerThreeTempPos.y, playerThreeTempPos.z);
                           
                        // Move the GameObject to the new position
                        playerThree.transform.position = newPosition3;
                        //update playerOnePos
                        playerThreeTempPos = playerThree.transform.position;
                    } 
                    randomBool = false;
                
                    }
                    if (ArePositionsApproximatelyEqual(playerFourTempPos, desiredPos4, 0.1f) == false){
                        if (IsPlayerAtLocation(desiredPos4, 0.5f) && ArePositionsApproximatelyEqual(playerFourTempPos, desiredPos3, 0.1f)){
                            randomBool = true;
                        }
                    if(randomBool == false){
                           // Calculate the new position by adding the desired distance to the X coordinate
                        Vector3 newPosition4 = new Vector3(playerFourTempPos.x - 1.5f, playerFourTempPos.y, playerFourTempPos.z);
                           
                        // Move the GameObject to the new position
                        playerFour.transform.position = newPosition4;
                        //update playerOnePos
                        playerFourTempPos = playerFour.transform.position;
                    }
                    randomBool = false;
                
                    }
                }
              
                playerOne.transform.position = desiredPos1;
                playerOneTempPos = playerOne.transform.position;
                // move orange 4.5f right
                playerTwo.transform.position =  new Vector3(playerTwoTempPos.x + 4.5f, playerTwoTempPos.y, playerTwoTempPos.z);
                    //update playerOnePos
                    playerTwoTempPos = playerTwo.transform.position;
                ScoreSettlement();
            }
            else if ((randomNumberOne != randomNumberTwo) && (randomNumberOne != randomNumberThree) && (randomNumberOne != randomNumberFour)){
                List<int> numbers = new List<int> { randomNumberOne, randomNumberTwo, randomNumberThree, randomNumberFour };
                int minNumber = numbers.Min();
                if (minNumber == randomNumberOne){
                    playerOne.transform.position = desiredPos4;
                }
                else if (minNumber == randomNumberTwo){
                    playerTwo.transform.position = desiredPos4;
                }
                else if (minNumber == randomNumberThree){
                    playerThree.transform.position = desiredPos4;
                }
                else if (minNumber == randomNumberFour){
                    playerFour.transform.position = desiredPos4;
                }
                numbers.Remove(minNumber);

                int minNumber1 = numbers.Min();
                if (minNumber1 == randomNumberOne){
                    playerOne.transform.position = desiredPos3;
                }
                else if (minNumber1 == randomNumberTwo){
                    playerTwo.transform.position = desiredPos3;
                }
                else if (minNumber1 == randomNumberThree){
                    playerThree.transform.position = desiredPos3;
                }
                else if (minNumber1 == randomNumberFour){
                    playerFour.transform.position = desiredPos3;
                }
                numbers.Remove(minNumber1);

                int minNumber2 = numbers.Min();
                if (minNumber2 == randomNumberOne){
                    playerOne.transform.position = desiredPos2;
                }
                else if (minNumber2 == randomNumberTwo){
                    playerTwo.transform.position = desiredPos2;
                }
                else if (minNumber2 == randomNumberThree){
                    playerThree.transform.position = desiredPos2;
                }
                else if (minNumber2 == randomNumberFour){
                    playerFour.transform.position = desiredPos2;
                }
                numbers.Remove(minNumber2);

                int minNumber3 = numbers.Min();
                  if (minNumber3 == randomNumberOne){
                    playerOne.transform.position = desiredPos1;
                }
                else if (minNumber3 == randomNumberTwo){
                    playerTwo.transform.position = desiredPos1;
                }
                else if (minNumber3 == randomNumberThree){
                    playerThree.transform.position = desiredPos1;
                }
                else if (minNumber3 == randomNumberFour){
                    playerFour.transform.position = desiredPos1;
                }
                numbers.Remove(minNumber3);

                ScoreSettlement();
            }
            else if((randomNumberOne == randomNumberThree) && (randomNumberTwo == randomNumberFour)){
                ScoreSettlement();
            }
            else if ((randomNumberOne == randomNumberFour) && (randomNumberTwo == randomNumberThree)){
                //move player1 3.0f left
                    // Move the GameObject to the new position
                    // playerOne.transform.position = new Vector3(playerOneTempPos.x + 3.0f, playerOneTempPos.y, playerOneTempPos.z);
                    // //update playerOnePos
                    // playerOneTempPos = playerOne.transform.position;
                ScoreSettlement();
            }
            // 1,2,3,4 tied
            else{
                ScoreSettlement();
                //break;
            }
    }

    GameObject FindObjectAtPosition(string tag, Vector3 position)
    {
        
        Collider[] colliders = Physics.OverlapSphere(position, checkRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(tag))
            {
                return collider.gameObject;
            }
        }
        return null;
    }
    
    bool IsPlayerAtLocation(Vector3 location, float radius)
    {
        Collider[] colliders = Physics.OverlapSphere(location, radius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }

    
    private bool CheckPlayerPosition()
    {
        // Get all game objects with the "player" tag
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players)
        {
            // Check if the player's position matches the target position
            if (player.transform.position == targetPosition)
            {
                return true; // Player is at the target position
            }
        }

        return false; // Player is not at the target position
    }
    
    bool ArePositionsApproximatelyEqual(Vector3 positionA, Vector3 positionB, float tolerance)
    {   
        float distance = Vector3.Distance(positionA, positionB);
        return distance <= tolerance;
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.R)){
            // assign player number to correct rng numbeer
            // playerOneTempPos = new Vector3();
            // playerTwoTempPos = new Vector3();
            // playerThreeTempPos = new Vector3();
            // playerFourTempPos = new Vector3();
            
            GameLogic();
            // playerOneTempPos = desiredPos1;
            // playerTwoTempPos = desiredPos2;
            // playerThreeTempPos = desiredPos3;
            // playerFourTempPos = desiredPos4;
            
        }

        if(Input.GetKeyDown(KeyCode.Alpha1)){
            Debug.Log("Key 1 down registered by unity");
            //GetObjectAtPosition(desiredPos1, "Player").transform.Translate(new Vector3(-1.5f, 0f, 0f));
            //transform.Translate(Vector3.up * Time.deltaTime, Space.World);
            //playerOne.transform.Translate(Vector3.right * Time.deltaTime, Space.World);
            //playerOne.transform.Translate(Vector3.right*100);
            // Calculate the target position to move the GameObject to the right
            // Vector3 currentPosition1 = GetObjectAtPosition(desiredPos1, "Player").transform.position;
                          
            // Vector3 newPosition1 = new Vector3(currentPosition1.x - 1.5f, currentPosition1.y, currentPosition1.z);
            
            // GetObjectAtPosition(desiredPos1, "Player").transform.position = newPosition1;
            Vector3 currentPosition = playerOne.transform.position;

            // Calculate the new position by adding the desired distance to the X coordinate
            Vector3 newPosition = new Vector3(currentPosition.x -1.5f, currentPosition.y, currentPosition.z);

            // Move the GameObject to the new position
            playerOne.transform.position = newPosition;
            //playerThree.transform.position = desiredPos1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            Debug.Log("Key 2 down registered by unity");
            // Get the current position of the GameObject
            Vector3 currentPosition = playerTwo.transform.position;

            // Calculate the new position by adding the desired distance to the X coordinate
            Vector3 newPosition = new Vector3(currentPosition.x -1.5f, currentPosition.y, currentPosition.z);

            // Move the GameObject to the new position
            playerTwo.transform.position = newPosition;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            Debug.Log("Key 3 down registered by unity");
            // Get the current position of the GameObject
            Vector3 currentPosition = playerThree.transform.position;

            // Calculate the new position by adding the desired distance to the X coordinate
            Vector3 newPosition = new Vector3(currentPosition.x -1.5f, currentPosition.y, currentPosition.z);

            // Move the GameObject to the new position
            playerThree.transform.position = newPosition;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            Debug.Log("Key 4 down registered by unity");
            // Get the current position of the GameObject
            Vector3 currentPosition = playerFour.transform.position;

            // Calculate the new position by adding the desired distance to the X coordinate
            Vector3 newPosition = new Vector3(currentPosition.x -1.5f, currentPosition.y, currentPosition.z);

            // Move the GameObject to the new position
            playerFour.transform.position = newPosition;
        }
    }
    // void ScoreSettlement(){
    //     if (FindObjectAtPosition("Player", desiredPos4) == playerOne){
    //         Debug.Log(playerOneTempPos);
    //         Debug.Log("player1 ended up last");
    //         scoreTwo += 1;  //all other players +1 score
    //         scoreThree += 1;
    //         scoreFour += 1;
    //         }
    //         else if (FindObjectAtPosition("Player", desiredPos4) == playerTwo){
    //             Debug.Log(playerTwoTempPos);
    //             Debug.Log("player2 ended up last");
    //             scoreOne += 1;
    //             scoreThree += 1;
    //             scoreFour += 1;
    //         }
    //         else if (FindObjectAtPosition("Player", desiredPos4) == playerThree){
    //             Debug.Log(playerThreeTempPos);
    //             Debug.Log("player3 ended up last");
    //             scoreOne += 1;
    //             scoreTwo += 1;
    //             scoreFour += 1;
    //         }
    //         else if (FindObjectAtPosition("Player", desiredPos4) == playerFour){
    //             Debug.Log(playerFourTempPos);
    //             Debug.Log("player4 ended up last");
    //             scoreOne += 1;
    //             scoreTwo += 1;
    //             scoreThree += 1;
    //         }
    //         else{
    //             //continue;
    //         }
    //     scoreTextOne.text = scoreOne.ToString();
    //     scoreTextTwo.text = scoreTwo.ToString();
    //     scoreTextThree.text = scoreThree.ToString();
    //     scoreTextFour.text = scoreFour.ToString();
    // }
    void ScoreSettlement(){
        if (ArePositionsApproximatelyEqual(playerOne.transform.position, desiredPos4, 0.25f)){
            Debug.Log(playerOneTempPos);
            Debug.Log("player1 ended up last");
            scoreTwo += 1;  //all other players +1 score
            scoreThree += 1;
            scoreFour += 1;
            }
            else if (ArePositionsApproximatelyEqual(playerTwo.transform.position, desiredPos4, 0.25f)){
                Debug.Log(playerTwoTempPos);
                Debug.Log("player2 ended up last");
                scoreOne += 1;
                scoreThree += 1;
                scoreFour += 1;
            }
            else if (ArePositionsApproximatelyEqual(playerThree.transform.position, desiredPos4, 0.25f)){
                Debug.Log(playerThreeTempPos);
                Debug.Log("player3 ended up last");
                scoreOne += 1;
                scoreTwo += 1;
                scoreFour += 1;
            }
            else if (ArePositionsApproximatelyEqual(playerFour.transform.position, desiredPos4, 0.25f)){
                Debug.Log(playerFourTempPos);
                Debug.Log("player4 ended up last");
                scoreOne += 1;
                scoreTwo += 1;
                scoreThree += 1;
            }
            else{
                //continue;
            }
        scoreTextOne.text = scoreOne.ToString();
        scoreTextTwo.text = scoreTwo.ToString();
        scoreTextThree.text = scoreThree.ToString();
        scoreTextFour.text = scoreFour.ToString();
    }
}
