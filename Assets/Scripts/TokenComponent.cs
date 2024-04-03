﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenComponent : MonoBehaviour {

    public bool isColliding = false;
    public bool isInteractedWith = false;
    public Token tokenInstance;
    public PlayerType playerType;

    PhotonView View;


    private void Start()
    {
        if (tokenInstance == null)
            return;

        View = GetComponent<PhotonView>();

    }

    private void Update()
    {
        if (tokenInstance == null)
            return;
    }

    private void OnMouseDown()
    {
      //  View.RPC(nameof(OnMouse_Down), RpcTarget.AllBuffered);


        PhotonView photonView = PhotonView.Get(this);

        switch (playerType)
        {
            case PlayerType.BLUE:
                if (PhotonNetwork.LocalPlayer.ActorNumber == 1 && View.IsMine)
                {
                    photonView.RPC(nameof(OnMouse_Down), RpcTarget.All);
                }
                else
                {
                    ShareValues.Color_No = 5;
                    Debug.LogError("Dont touch");
                }
                break;
            
            case PlayerType.GREEN:
                if (PhotonNetwork.LocalPlayer.ActorNumber == 2 && View.IsMine)
                {
                    photonView.RPC(nameof(OnMouse_Down), RpcTarget.All);
                }
                else
                {
                    ShareValues.Color_No = 5;
                    Debug.LogError("Dont touch");
                }
                break;
        }
        }
    [PunRPC]
    private void OnMouse_Down()
    {
        tokenInstance.Interact();
    }

    private void OnMouseOver()
    {
      //  View.RPC(nameof(OnMousse_Over), RpcTarget.AllBuffered);

        PhotonView photonView = PhotonView.Get(this);

        if (photonView.IsMine)

            photonView.RPC(nameof(OnMousse_Over), RpcTarget.All);

    }
    [PunRPC]
    private void OnMousse_Over()
    {
        tokenInstance.Highlight();
    }

    private void OnMouseExit()
    {
        //  View.RPC(nameof(OnMouse_Exit), RpcTarget.AllBuffered);

        //   PhotonView photonView = PhotonView.Get(this);
        //
        //   if (photonView.IsMine)
        //
        //       photonView.RPC(nameof(OnMouse_Exit), RpcTarget.All);
        OnMouse_Exit();
    }
   ///// [PunRPC]
    private void OnMouse_Exit()
    {
        tokenInstance.Unhighlight();
    }

    void OnTriggerEnter(Collider other)
    {
     //   View.RPC(nameof(Ontrigger_Enter), RpcTarget.AllBuffered);

      // PhotonView photonView = PhotonView.Get(this);
      //
      // if (photonView.IsMine)
      //
      //     photonView.RPC(nameof(Ontrigger_Enter), RpcTarget.All);

        Ontrigger_Enter();

    }
    //[PunRPC]
    private void Ontrigger_Enter()
    {
        isColliding = true;
    }

    void OnTriggerExit(Collider other)
    {
        //   View.RPC(nameof(OnTrigger_Exit), RpcTarget.AllBuffered);

        //  PhotonView photonView = PhotonView.Get(this);
        //
        //  if (photonView.IsMine)
        //
        //      photonView.RPC(nameof(OnTrigger_Exit), RpcTarget.All);
        OnTrigger_Exit();
    }
    //[PunRPC]
    private void OnTrigger_Exit()
    {
        isColliding = false;
    }
}








   