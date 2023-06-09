using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MapOverview : MonoBehaviour
{
    public GameObject goToWork;
    public GameObject goToBar;
    public GameObject goToGym;

    // Start is called before the first frame update


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider.name == "shop")
            {
                shop();
            }
            else if(hit.collider.name == "work")
            {
                work();
            }
            else if (hit.collider.name == "gym")
            {
                gym();
            }
            else if (hit.collider.name == "house")
            {
                house();
            }
            else if (hit.collider.name == "bar")
            {
                bar();
            }
            else if (hit.collider.name == "invest")
            {
                invest();
            }
            else
            {
               /* goToWork.SetActive(false);
                goToBar.SetActive(false);
                goToGym.SetActive(false);*/
            }

        }


    }
    public void work()
    {
        goToBar.SetActive(false);
        goToGym.SetActive(false);
        goToWork.SetActive(true);

    }

    public void shop()
    {
        State shopState = new ShopState();
        GameController.Instance.changeState.Invoke(shopState);
       
        
    }

    public void bar()
    {
        goToWork.SetActive(false);
        goToGym.SetActive(false);
        goToBar.SetActive(true);
        
        
    }
    public void invest()
    {
        State investState = new InvestState();
        GameController.Instance.changeState.Invoke(investState);

    }

    public void gym()
    {
        goToWork.SetActive(false);
        goToBar.SetActive(false);
        goToGym.SetActive(true);
    }

    public void house()
    {
        State houseState = new HouseState();
        GameController.Instance.changeState.Invoke(houseState);

    }

    public void barEntry()
    {
        Debug.Log("in here");
        if (GameController.Instance.player.Money >= 10)
        {
            PlayerStatsEventArgs args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.DecreaseMoney, 10);
            GameController.Instance.player.StatsChangeEvent.Invoke(args);
            State barState = new BarState();
            GameController.Instance.changeState.Invoke(barState);
        }
       
    }
    public void gymEntry()
    {
        if (GameController.Instance.player.Money >= 10)
        {
            PlayerStatsEventArgs args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.DecreaseMoney, 10);
            GameController.Instance.player.StatsChangeEvent.Invoke(args);
            State gymState = new GymState();
            GameController.Instance.changeState.Invoke(gymState);
        }
        
    }

}
