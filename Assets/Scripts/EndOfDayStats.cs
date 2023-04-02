using TMPro;
using UnityEngine;

public class EndOfDayStats : MonoBehaviour
{
    public TextMeshProUGUI money;
    public TextMeshProUGUI food;
    public TextMeshProUGUI strength;
    public TextMeshProUGUI social;
    private void Awake()
    {
        money.text = "Money = " + GameController.Instance.player.Money.ToString();
        food.text = "Food = " + GameController.Instance.player.Food.ToString();
        strength.text = "Strength = " + GameController.Instance.player.Strength.ToString();
        social.text = "Social = " + GameController.Instance.player.Social.ToString();
    }


    public void GoToNextDay()
    {
        State state = new HomeState();
        GameController.Instance.changeState.Invoke(state);
    }
}
