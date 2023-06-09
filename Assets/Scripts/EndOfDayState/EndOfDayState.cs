using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfDayState : BaseState
{

    invest classInvest = new invest();
    public EndOfDayState() : base()
    {
        Debug.Log("In end of day state");
    }


    void Start()
    {
        classInvest.endOfDay();
    }

    public override void OnEnter()
    {
        SceneManager.LoadScene("EndOfDayScene");
        changeScene();
    }



    IEnumerator changeScene()
    {
        // Code to execute after 2 seconds
        yield return new WaitForSeconds(5f);
        State homeState = new HomeState();
        GameController.Instance.changeState.Invoke(homeState);
    }
}