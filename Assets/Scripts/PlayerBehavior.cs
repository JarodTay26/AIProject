using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;



// key 1 moves player nearest to you, 4 furthest
// R for repeat round

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

    //private bool hasStarted = false;

    List<int> compareSize = new List<int>(); // Create a new list

    // for (int i = 0; i < 4; i++)
    // {
    //     numbers.Add(20); // Add 20 to the list
    // }
    
    //public float moveDistance = 0.25f;
    //public float moveSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
       
        Debug.Log("Start called");
        // Generate a random integer between 1 and 10 using Random.Range
        int randomNumberOne = Random.Range(1, 10);
        int randomNumberTwo = Random.Range(1, 10);
        int randomNumberThree = Random.Range(1, 10);
        int randomNumberFour = Random.Range(1, 10);
        //codeText = GetComponent<Text>();
        
        // Convert the random number to a string, UI
        codeTextOne.text = randomNumberOne.ToString();
        codeTextTwo.text = randomNumberTwo.ToString();
        codeTextThree.text = randomNumberThree.ToString();
        codeTextFour.text = randomNumberFour.ToString();

        if((randomNumberOne != randomNumberTwo) && (randomNumberOne != randomNumberThree) && (randomNumberOne != randomNumberFour)){
            compareSize.Add(randomNumberOne);
        }
        if((randomNumberTwo != randomNumberOne) && (randomNumberTwo != randomNumberThree) && (randomNumberTwo != randomNumberFour)){
            compareSize.Add(randomNumberTwo);
        }
        if((randomNumberThree != randomNumberOne) && (randomNumberThree != randomNumberTwo) && (randomNumberThree != randomNumberFour)){
            compareSize.Add(randomNumberThree);
        }
        if((randomNumberFour != randomNumberOne) && (randomNumberFour != randomNumberTwo) && (randomNumberFour != randomNumberThree)){
            compareSize.Add(randomNumberFour);
        }

        if (compareSize.Count > 0){
            //compareSize.Sort(); // sorts list in ascending order
            if (compareSize.Min() == randomNumberOne){
            // move player1 to front
            // Get the current position of the GameObject
            Vector3 currentPosition = playerOne.transform.position;

            // Calculate the new position by adding the desired distance to the X coordinate
            Vector3 newPosition = new Vector3(currentPosition.x + 0.5f, currentPosition.y, currentPosition.z);

            // Move the GameObject to the new position
            playerOne.transform.position = newPosition;
            }  
            if (compareSize.Min() == randomNumberTwo){

            Vector3 currentPosition = playerTwo.transform.position;
            // Calculate the new position by adding the desired distance to the X coordinate
            Vector3 newPosition = new Vector3(currentPosition.x + 0.5f, currentPosition.y, currentPosition.z);

            // Move the GameObject to the new position
            playerTwo.transform.position = newPosition;
            }

            if (compareSize.Min() == randomNumberThree){

            Vector3 currentPosition = playerThree.transform.position;
            // Calculate the new position by adding the desired distance to the X coordinate
            Vector3 newPosition = new Vector3(currentPosition.x + 0.5f, currentPosition.y, currentPosition.z);

            // Move the GameObject to the new position
            playerThree.transform.position = newPosition;
            }
            if (compareSize.Min() == randomNumberFour){

            Vector3 currentPosition = playerFour.transform.position;
            // Calculate the new position by adding the desired distance to the X coordinate
            Vector3 newPosition = new Vector3(currentPosition.x + 0.5f, currentPosition.y, currentPosition.z);

            // Move the GameObject to the new position
            playerFour.transform.position = newPosition;
            }

            compareSize.Clear(); // clear the list after each round
        }
        
        
    }
    


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            Start();
        }

        if(Input.GetKeyDown(KeyCode.Alpha1)){
            Debug.Log("Key 1 down registered by unity");
            //transform.Translate(Vector3.up * Time.deltaTime, Space.World);
            //playerOne.transform.Translate(Vector3.right * Time.deltaTime, Space.World);
            //playerOne.transform.Translate(Vector3.right*100);
            // Calculate the target position to move the GameObject to the right

            // Get the current position of the GameObject
            Vector3 currentPosition = playerOne.transform.position;

            // Calculate the new position by adding the desired distance to the X coordinate
            Vector3 newPosition = new Vector3(currentPosition.x + 0.25f, currentPosition.y, currentPosition.z);

            // Move the GameObject to the new position
            playerOne.transform.position = newPosition;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            Debug.Log("Key 2 down registered by unity");
            // Get the current position of the GameObject
            Vector3 currentPosition = playerTwo.transform.position;

            // Calculate the new position by adding the desired distance to the X coordinate
            Vector3 newPosition = new Vector3(currentPosition.x + 0.25f, currentPosition.y, currentPosition.z);

            // Move the GameObject to the new position
            playerTwo.transform.position = newPosition;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            Debug.Log("Key 3 down registered by unity");
            // Get the current position of the GameObject
            Vector3 currentPosition = playerThree.transform.position;

            // Calculate the new position by adding the desired distance to the X coordinate
            Vector3 newPosition = new Vector3(currentPosition.x + 0.25f, currentPosition.y, currentPosition.z);

            // Move the GameObject to the new position
            playerThree.transform.position = newPosition;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            Debug.Log("Key 4 down registered by unity");
            // Get the current position of the GameObject
            Vector3 currentPosition = playerFour.transform.position;

            // Calculate the new position by adding the desired distance to the X coordinate
            Vector3 newPosition = new Vector3(currentPosition.x + 0.25f, currentPosition.y, currentPosition.z);

            // Move the GameObject to the new position
            playerFour.transform.position = newPosition;
        }
    }
}
