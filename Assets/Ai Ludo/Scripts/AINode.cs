using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.bhambhoo.fairludo;

public class AINode : MonoBehaviour
{

    public List<PlayerToken> allPlayer,redPlayers, yellowPlayers, greenPlayers, bluePlayers;
    List<PlayerAI> playersIndex = new List<PlayerAI>();
    PlayerAI player;
    public List<int> playerIndexeres;
    public int playerIndex=0;
    public bool isSafeNode;

    private void Start()
    {
        for (int i=0; i < PlayersManager.Players.Count; i++)
        {

            //playersIndex[i].playerIndex= PlayersManager.Players[i].GetPlayerIndex();
            //player.playerIndex = playersIndex[i].GetPlayerIndex();
            Debug.LogError("the Player Index is : " + PlayersManager.Players[i].playerIndex);
            //playerIndex = (int)PlayersManager.Players[i].GetPlayerIndex();
            player.playerIndex = PlayersManager.Players[i].playerIndex;
            Debug.LogError("the Player Index is _sf  : " + player.playerIndex);

        }
        //Debug.LogError("the Node Local Position is : " + this.transform.localPosition);

    }


    private void OnTriggerEnter(Collider other)
    {

        Debug.LogError("Triggered Added");
        if (isSafeNode)
        {
            allPlayer.Add(other.gameObject.GetComponent<PlayerToken>());
            if (allPlayer.Count == 1)
            {
                Debug.LogError("Triggered Added all 1");
                //allPlayer[0].transform.localScale = Vector3.Slerp(allPlayer[0].transform.localScale, new Vector3(3,3,3), .5f);;

                allPlayer[0].transform.localPosition =this.transform.localPosition;
                Debug.LogError("the Player Pos is : " + allPlayer[0].transform.localPosition);
                //direction = Vector3.Slerp(Vector3.zero, GetPosition() - allPlayer[0].tokenTransform.position, smoothness);
                //allPlayer[0].tokenTransform.Translate(direction);



                return;
            }
            if (allPlayer.Count == 2)
            {
                Debug.LogError("Triggered Added all 2");
                //allPlayer[i].tokenTransform.localScale = Vector3.Slerp(allPlayer[i].tokenTransform.localScale, allPlayer[i].originalScale * scaleMultipliers[count - 2], smoothness);
                //direction = Vector3.Slerp(Vector3.zero, aux.GetChild(i).position - allPlayer[i].tokenTransform.position, smoothness);
                //allPlayer[i].tokenTransform.Translate(direction);

                Vector3 firstCubePosition = this.transform.localPosition + new Vector3(-.3f, 0f, 0f);

                // Calculate the position for the second cube
                Vector3 secondCubePosition = this.transform.localPosition + new Vector3(.3f, 0f, 0f);

                allPlayer[0].transform.localScale = Vector3.Slerp(allPlayer[0].transform.localScale, new Vector3(2.5f,2.5f,2.5f), .5f); ;
                allPlayer[0].transform.localPosition = firstCubePosition;

                allPlayer[1].transform.localScale = Vector3.Slerp(allPlayer[1].transform.localScale, new Vector3(2.5f, 2.5f, 2.5f), .5f); ;
                allPlayer[0].transform.localPosition = secondCubePosition;

                //// Create the first cube
                //GameObject firstCube = Instantiate(cubePrefab, firstCubePosition, Quaternion.identity);

                //// Create the second cube
                //GameObject secondCube = Instantiate(cubePrefab, secondCubePosition, Quaternion.identity);

                // Optionally, you can set other properties of the cubes such as scale, rotation, etc.
                // For example:
                //allPlayer[0].transform.localScale = new Vector3(allPlayer[0].transform.localScale.x / 2f, allPlayer[0].transform.localScale.y / 2f, allPlayer[0].transform.localScale.z / 2f);
                //allPlayer[1].transform.localScale = new Vector3(allPlayer[1].transform.localScale.x / 2f, allPlayer[1].transform.localScale.y / 2f, allPlayer[1].transform.localScale.z / 2f);


            }
            Debug.LogError("ALL Players Added Triggered Triggered");
        }
        else
        {

            switch (playerIndex)
            {
                case 1:
                    Debug.LogError("the Player Index is : " + playerIndex);
                    bluePlayers.Add(other.gameObject.GetComponent<PlayerToken>());
                    Debug.LogError("Blue Players Added Triggered Triggered");

                    return;


                case 2:
                    Debug.LogError("the Player Index is : " + playerIndex);
                    redPlayers.Add(other.gameObject.GetComponent<PlayerToken>());
                    Debug.LogError("Red Players Added Triggered Triggered");
                    return;

                case 3:
                    Debug.LogError("the Player Index is : " + playerIndex);
                    greenPlayers.Add(other.gameObject.GetComponent<PlayerToken>());
                    Debug.LogError("Green Players Added Triggered Triggered");
                    return;

                case 4:
                    Debug.LogError("the Player Index is : " + playerIndex);
                    yellowPlayers.Add(other.gameObject.GetComponent<PlayerToken>());
                    Debug.LogError("Yellow Players Added Triggered Triggered");
                    return;
                default:
                    return;
            }


            //if (PlayersManager.Players[0].GetPlayerIndex()==1)
            //{
            //    Debug.LogError("the Player Index is : " + PlayersManager.Players[0].playerIndex);
            //    bluePlayers.Add(other.gameObject.GetComponent<PlayerToken>());
            //    Debug.LogError("Blue Players Added Triggered Triggered");

            //    return;
            //}
            //else if (PlayersManager.Players[1].GetPlayerIndex() == 2)
            //{
            //    Debug.LogError("the Player Index is : " + PlayersManager.Players[1].playerIndex);
            //    redPlayers.Add(other.gameObject.GetComponent<PlayerToken>());
            //    Debug.LogError("Red Players Added Triggered Triggered");
            //    return;
            //}
            //else if (PlayersManager.Players[2].GetPlayerIndex() == 3)
            //{
            //    Debug.LogError("the Player Index is : " + PlayersManager.Players[2].playerIndex);
            //    greenPlayers.Add(other.gameObject.GetComponent<PlayerToken>());
            //    Debug.LogError("Green Players Added Triggered Triggered");
            //    return;
            //}
            //else if (PlayersManager.Players[3].GetPlayerIndex() == 4)
            //{
            //    Debug.LogError("the Player Index is : " + PlayersManager.Players[3].playerIndex);
            //    yellowPlayers.Add(other.gameObject.GetComponent<PlayerToken>());
            //    Debug.LogError("Yellow Players Added Triggered Triggered");
            //    return;
            //}


        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.LogError("Triggered Removed");

        if (isSafeNode)
        {
            //if(allPlayer.Count==1)
            //{
                allPlayer.Remove(other.gameObject.GetComponent<PlayerToken>());

            //allPlayer[0].transform.localScale = Vector3.Slerp(allPlayer[0].transform.localScale, new Vector3(4, 4, 4), .5f);

            other.gameObject.GetComponent<PlayerToken>().transform.localScale = new Vector3(3, 3, 3);
            //}
            //else if(allPlayer.Count>=1)
            //{
            //    for (int i = 0; i < allPlayer.Count; i++)
            //    {
            //        //allPlayer.Remove(other.gameObject.GetComponent<PlayerToken>());
            //        allPlayer.RemoveAt(i);

            //        allPlayer[i].transform.localScale = Vector3.Slerp(allPlayer[i].transform.localScale, new Vector3(4, 4, 4), .5f);

            //    }

            //}

            Debug.LogError("All Players Removed Triggered Triggered");
        }
        else
        {
            Debug.LogError("the Player Index is : " + playerIndex);
            switch (playerIndex)
            {
                case 1:
                    bluePlayers.Remove(other.gameObject.GetComponent<PlayerToken>());
                    other.gameObject.GetComponent<PlayerToken>().transform.localScale = new Vector3(3, 3, 3);
                    Debug.LogError("Blue Players Removed Triggered Triggered");
                    return;

                case 2:
                    redPlayers.Remove(other.gameObject.GetComponent<PlayerToken>());
                    other.gameObject.GetComponent<PlayerToken>().transform.localScale = new Vector3(3, 3, 3);
                    Debug.LogError("Red Players Removed Triggered Triggered");
                    return;

                case 3:
                    greenPlayers.Remove(other.gameObject.GetComponent<PlayerToken>());
                    other.gameObject.GetComponent<PlayerToken>().transform.localScale = new Vector3(3, 3, 3);
                    Debug.LogError("Green Players Removed Triggered Triggered");
                    return;

                case 4:
                    yellowPlayers.Remove(other.gameObject.GetComponent<PlayerToken>());
                    other.gameObject.GetComponent<PlayerToken>().transform.localScale = new Vector3(3, 3, 3);
                    Debug.LogError("Yellow Players Removed Triggered Triggered");
                    return;


                default:
                    return;
            }
        }
    }
   
}
