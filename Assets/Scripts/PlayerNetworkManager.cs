using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
public class PlayerNetworkManager : NetworkBehaviour
{
    private PlayerManager playerManager;
    public TMP_Text userNameText;

    [SyncVar(hook = nameof(SetUserName))] 
    public string userName = "Default UserName"; 


    void Start()
    {
        userNameText = gameObject.GetComponentInChildren<TMP_Text>();
        playerManager = GetComponent<PlayerManager>();
        if (!isLocalPlayer)
        {
            userNameText.SetText(userName);
            if (gameObject.GetComponentInChildren<Camera>() != null)
            {
                gameObject.GetComponentInChildren<Camera>().gameObject.SetActive(false);
            }
        }
        else
        {
            userName = GameObject.FindObjectOfType<WorldNetworkManager>().playerUserName;
            CmdSetUserName(userName);
            if (gameObject.GetComponentInChildren<Camera>() != null)
            {
                gameObject.GetComponentInChildren<Camera>().gameObject.SetActive(true);
            }

        }
    }

    public void SetUserName(string oldvalue, string newvalue) {
        userNameText.SetText(newvalue);
        if (!oldvalue.Equals(newvalue)) {
            userName = newvalue;
        }
    }

    void Update()
    {
    }

    [Command]
    void CmdSetUserName(string name) {
        userName = name;
    }
}
