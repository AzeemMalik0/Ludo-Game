using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.bhambhoo.fairludo;

public class AINode : MonoBehaviour
{

    public List<PlayerToken> redPLayers, yellowPlayers, greenPlayers, bluePlayers;
    PlayerAI Player;

    //private void Start()
    //{
    //    this.Player = Player.GetPlayerIndex();
    //}


    private void OnTriggerEnter(Collider other)
    {

        Debug.LogError("Triggered Added");
        
        switch (Player.GetPlayerIndex())
        {
            case 1:
                    bluePlayers.Add(other.gameObject.GetComponent<PlayerToken>());
                Debug.LogError("Blue Players Added Triggered Triggered");
                return;

            case 2:
                redPLayers.Add(other.gameObject.GetComponent<PlayerToken>());
                Debug.LogError("Red Players Added Triggered Triggered");
                return;

            case 3:
                greenPlayers.Add(other.gameObject.GetComponent<PlayerToken>());
                Debug.LogError("Green Players Added Triggered Triggered");
                return;

            case 4:
                yellowPlayers.Add(other.gameObject.GetComponent<PlayerToken>());
                Debug.LogError("Yellow Players Added Triggered Triggered");
                return;

            default:
                return;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.LogError("Triggered Removed");

        switch (Player.GetPlayerIndex())
        {
            case 1:
                bluePlayers.Remove(other.gameObject.GetComponent<PlayerToken>());
                Debug.LogError("Blue Players Removed Triggered Triggered");
                return;

            case 2:
                redPLayers.Remove(other.gameObject.GetComponent<PlayerToken>());
                Debug.LogError("Red Players Removed Triggered Triggered");
                return;

            case 3:
                greenPlayers.Remove(other.gameObject.GetComponent<PlayerToken>());
                Debug.LogError("Green Players Removed Triggered Triggered");
                return;

            case 4:
                yellowPlayers.Remove(other.gameObject.GetComponent<PlayerToken>());
                Debug.LogError("Yellow Players Removed Triggered Triggered");
                return;

            default:
                return;
        }
    }
   
}
