using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string VersioName = "0.1";
    [SerializeField] private GameObject ControlPanel;
    [SerializeField] private InputField CreateGameInput;
    [SerializeField] private InputField JoinGameInput;

    public GameObject[] players;
    public int playerChoice;


    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(VersioName);
        
    }


    void Start()
    {
        ControlPanel.SetActive(true);
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }

    [System.Obsolete]
    public void CreateGame()
    {
        PlayerPrefs.SetInt("playerChoice", playerChoice);
        PhotonNetwork.CreateRoom(CreateGameInput.text, new RoomOptions() { maxPlayers = 3 }, null);
    }

    [System.Obsolete]
    public void JoinGame()
    {
        PlayerPrefs.SetInt("playerChoice", playerChoice);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.maxPlayers = 3;
        PhotonNetwork.JoinRoom(JoinGameInput.text);

    }

    private void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("MainGame");
    }


    public void playerChoiceFunction(int i)
    {
        playerChoice = i;

    }

}
