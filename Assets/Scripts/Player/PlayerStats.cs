using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{

    [System.Serializable] public class customIntEvent : UnityEvent<int, int, int, int> { } //Lets me add a float arg to event call;
    public UnityEvent<PlayerStatsEventArgs> StatsChangeEvent; 

    [SerializeField]
    [Range(0, 100)]
    private int Food = 100;

    [SerializeField]
    [Range(0, 100)]
    private int Money = 100;

    [SerializeField]
    [Range(0, 100)]
    private int Strength = 100;

    [SerializeField]
    [Range(0, 100)]
    private int Social = 100;

    private bool HasCar = false; 

    public customIntEvent updateUI;

    public PlayerStats()
    {
        StatsChangeEvent.AddListener(OnChangeStats); 
    }

    private void OnChangeStats(PlayerStatsEventArgs arg0)
    {
        switch (arg0.Command)
        {
            case PlayerStatsEventArgs.cmd.IncreaseFood:
                Food += arg0.Value; 
                break;
            case PlayerStatsEventArgs.cmd.DecreaseFood:
                Food -= arg0.Value;
                break;
            case PlayerStatsEventArgs.cmd.IncreaseMoney:
                Money += arg0.Value;
                break;
            case PlayerStatsEventArgs.cmd.DecreaseMoney:
                Money -= arg0.Value;
                break;
            case PlayerStatsEventArgs.cmd.IncreaseStreangth:
                Strength += arg0.Value; 
                break;
            case PlayerStatsEventArgs.cmd.DecreaseStreangth:
                Strength -= arg0.Value;
                break;
            case PlayerStatsEventArgs.cmd.IncreaseSocial:
                Social+= arg0.Value;
                break;
            case PlayerStatsEventArgs.cmd.DecreaseSocial: 
                Social -= arg0.Value;
                break;
            case PlayerStatsEventArgs.cmd.HasCar:
                HasCar = arg0.Truth;
                break;
        }
    }

    public void updateMoney(int diff)
    {
        this.Money += diff;
        redrawUI();
    }

    public void updateFood(int diff)
    {
        this.Food += diff;
        redrawUI();
    }

    public void updateStrength(int diff)
    {
        this.Strength += diff;
        redrawUI();
    }

    public void updateSocial(int diff)
    {
        this.Social += diff;
        redrawUI();
    }

    public void redrawUI()
    {
        updateUI.Invoke(Money, Food, Strength, Social);
    }
    private void OnValidate()
    {
        if(Food>100)
        {
            Debug.Log("WAY TOO MUCH FOOD BRo"); 
        }
        if( Food <= 0)
        {
            // ha ha you're dead 
        }
    }
}
public class PlayerStatsEventArgs : EventArgs
{
    public cmd Command;
    public int Value;
    public bool Truth; 
    public PlayerStatsEventArgs(cmd command, int val)
    {
        Command= command;
        Value= val;
    }
    public PlayerStatsEventArgs(cmd command, bool val)
    {
        Command= command;
        Truth= val;
    }
    public enum cmd
    {
        IncreaseFood,
        DecreaseFood,
        IncreaseMoney,
        DecreaseMoney,
        IncreaseStreangth,
        DecreaseStreangth, 
        IncreaseSocial,
        DecreaseSocial,
        HasCar
    }
}
