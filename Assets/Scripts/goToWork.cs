using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToWork : MonoBehaviour
{
   
   public void walkButton()
   {
        buttonClickHandler();
   }

   public void busButton()
   {
        buttonClickHandler();
   }

   public void carButton()
   {
        buttonClickHandler();
   }

    private void buttonClickHandler()
    {
        // Define the event type with a string parameter

        // Invoke the event with a string parameter
        State travelState = new TravelState();
        GameController.Instance.changeState.Invoke(travelState);
        Debug.Log("clicked");
    }
}
