using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class GameSystem : MonoBehaviourPunCallbacks
{
    GameObject player;
    GameObject enemy;
    GameObject canvas;
    GameObject yukidama;
    GameObject kessho;
    GameObject kesshoPoint;
    Player enemyPlayer;
    Hashtable properties;
    float countTime;
    float comeTime;
    float randomX;
    float randomZ;


    
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        comeTime = 10.0f;
        kesshoPoint = GameObject.Find("KesshoPoint");
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        if (comeTime < countTime)
        {
            Kessho();
        }
    }

    public override void OnConnectedToMaster()
    {
        var opt = new RoomOptions();
        opt.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom("Game Room", opt, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        player = PhotonNetwork.Instantiate("yukigassenPlayer",new Vector3(0,2,0),Quaternion.identity, 0);
        player.GetComponent<player>().SetPlayerFlag(true);
        GameObject.Find("Main Camera").GetComponent<camera>().SetTarget(player);
        GameObject.Find("Up").GetComponent<Up>().SetPlayerUp(player);
        GameObject.Find("Down").GetComponent<Down>().SetPlayerDown(player);
        GameObject.Find("Left").GetComponent<Left>().SetPlayerLeft(player);
        GameObject.Find("Right").GetComponent<Right>().SetPlayerRight(player);
        GameObject.Find("shootButton").GetComponent<Shoot>().SetPlayerShoot(player);
        var prps = PhotonNetwork.LocalPlayer.CustomProperties;
        prps["kessho"] = 0;
        PhotonNetwork.LocalPlayer.SetCustomProperties(prps);
        foreach (var p in PhotonNetwork.PlayerList)
        {
            if (PhotonNetwork.LocalPlayer.UserId != p.UserId)
            {
                enemyPlayer = p;
                break;
            }
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        enemyPlayer = newPlayer;
    } 

    public void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        CheckEnemy();
    }

    public void CheckEnemy()
    {
        foreach(var ob in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (ob != player)
            {
                enemy = ob;
                break;
            }
        }
    }

    public void Check()
    {
        if (PhotonNetwork.LocalPlayer == null) {return; }
        if (enemyPlayer == null) {return; }
        var k = PhotonNetwork.LocalPlayer.CustomProperties["kessho"] is int value ? value : 1; 
        var ek = enemyPlayer.CustomProperties["kessho"] is int value2 ? value2 : 1;
        if (k == 10)
        {
            Win();
        }
        if (ek == 10)
        {
            Lose();
        }
    }

    public void GetKessho()
    {
        var k = PhotonNetwork.LocalPlayer.CustomProperties["kessho"] is int value ? value : 1; 
        PhotonNetwork.LocalPlayer.CustomProperties["kessho"] = k + 1;
        PhotonNetwork.LocalPlayer.SetCustomProperties(PhotonNetwork.LocalPlayer.CustomProperties["kessho"]);
        Debug.Log(PhotonNetwork.LocalPlayer.CustomProperties["kessho"]);
    }

    public void DamageKessho()
    {
        var k = PhotonNetwork.LocalPlayer.CustomProperties["kessho"] is int value ? value : 1; 
        if (k != 0)
        {
            PhotonNetwork.LocalPlayer.CustomProperties["kessho"] = k - 1;
            PhotonNetwork.LocalPlayer.SetCustomProperties(PhotonNetwork.LocalPlayer.CustomProperties["kessho"]);
            Debug.Log(PhotonNetwork.LocalPlayer.CustomProperties["kessho"]);
        }
    }



    public void Yukidama(Vector3 vector3)
    {
        yukidama = PhotonNetwork.Instantiate("yukidama", vector3 ,Quaternion.identity, 0);
        yukidama.GetComponent<yukidama>().SetPlayer(player);
    }

    public void Kessho()
    {
        randomX = Random.Range(-40.0f, 40.0f);
        randomZ = Random.Range(-40.0f, 40.0f);
        kessho = PhotonNetwork.Instantiate("kessho", new Vector3(randomX, 3.7f ,randomZ) ,Quaternion.identity, 0);
        countTime = 0f;
    }

    public void Win()
    {
        Debug.Log("Win");
    }

    public void Lose()
    {
        Debug.Log("Lose");
    }

    public void UpdateKesshoPoint()
    {
        var k = PhotonNetwork.LocalPlayer.CustomProperties["kessho"] is int value ? value : 1; 
        var ek = enemyPlayer.CustomProperties["kessho"] is int value2 ? value2 : 1;
        kesshoPoint.GetComponent<KesshoPoint>().UpdateKesshoPoint(k,ek);
    }
}
