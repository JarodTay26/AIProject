using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    public int value = 0; 
    public GameObject Canvas;
    

    void Start() {
        
    }
    public void OnMouseDown(){
        Debug.Log("OnMouseDown entered");

        //Canvas.GetComponent<PlayerBehavior>().randomNumberFour = value;
        //Debug.Log(Canvas.GetComponent<PlayerBehavior>().randomNumberFour);
        Canvas.GetComponent<PlayerBehavior>().GameUpdate(value);
        
        // Canvas.GetComponent<PlayerBehavior>().CardDeck.Remove(Canvas.GetComponent<PlayerBehavior>().CardDeck.find(gameObject.name));
        Destroy(gameObject);
    }

}
