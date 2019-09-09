using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ModuloKart.CustomVehiclePhysics;
using ModuloKart.Controls;

public class GameLogicManager : MonoBehaviour
{
    public static GameLogicManager Instance;

    [HideInInspector] private bool isGameStarted;
    [HideInInspector] private bool isGameFinished;

    public bool IsGameStarted { get { return isGameStarted; } set { isGameStarted = value; } }
    public bool IsGameFinished { get { return isGameFinished; } set { isGameFinished = value; } }

    private void Awake()
    {
        Instance = this;
    }

    public void CheckPlayersCompletedRace()
    {
        foreach (VehicleBehavior flickballarenaPlayer in ControllerHandler.Instance.vehicles)
        {
            if (flickballarenaPlayer.isControllerInitialized)
            {
                if (flickballarenaPlayer.GetComponent<VehicleLapData >().IsPlayerFinishedRace == false)
                {
                    return;
                }
            }
        }
        IsGameFinished = true;
        Debug.Log("ALL " + LapManager.Instance.playerLapDataList.Count + " PLAYERS HAVE COMPLETED THE RACE");
    }

}
