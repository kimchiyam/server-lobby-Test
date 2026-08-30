using System;
using System.Collections.Generic;
using Fusion;
using Fusion.Sockets;
using TMPro;
using UnityEngine;

namespace _00.Scripts.Lobby
{
    public class LobbyManager : MonoBehaviour, INetworkRunnerCallbacks
    {
        public NetworkRunner runner;
        //[SerializeField] TMP_InputField inputField;
        [SerializeField]private TextMeshProUGUI log;

        [SerializeField]private List<SessionInfo> _realSessionList;
        public static LobbyManager instance;
        
        [SerializeField] private Transform sessionContent;
        [SerializeField] private SessionItem sessionItemPrefab;

        private void Awake()
        {
            instance = this;
            _realSessionList = new List<SessionInfo>();
            runner.AddCallbacks(this);
        }

        private void Start()
        {
            JoinLobby();
        }

        public async void JoinLobby()
        {
            var result = await runner.JoinSessionLobby(SessionLobby.Shared);

            if (result.Ok)
            {
                Debug.Log("Shared Lobby 참가 성공");
            }

            else
            {
                Debug.LogError($"Lobby 참가 실패: {result.ShutdownReason}");
            }
        }
        
        
        public async void CreateRoom(string roomName)
        {
            Debug.Log($"방 생성 시도: {roomName}");

            var result = await runner.StartGame(new StartGameArgs
            {
                GameMode = GameMode.Shared,
                SessionName = roomName,
                Scene = SceneRef.FromIndex(1),
                SceneManager = runner.GetComponent<NetworkSceneManagerDefault>()
            });

            if (result.Ok)
            {
                Debug.Log($"방 생성 성공: {roomName}");
            }
            else
            {
                Debug.LogError($"방 생성 실패: {result.ShutdownReason}");
            }
        }

        public void CheckRoom(string roomName)
        {
            foreach (SessionInfo session in _realSessionList)
            {
                if (roomName == session.Name)
                {
                    JoinRoom(roomName);
                    return;
                }
            }
            Debug.Log("you can't enter the room");
            log.text = "you can't enter the room";
            

        }
    
        public async void JoinRoom(string roomName)
        {
            var result = await runner.StartGame(new StartGameArgs
            {
                GameMode = GameMode.Shared,
                SessionName = roomName,
                SceneManager = runner.GetComponent<NetworkSceneManagerDefault>()
            });

            if (result.Ok)
            {
                log.text = "joined room";
                Debug.Log("Joined room");
            }
            else
            {
                log.text = "failed to join room";
                Debug.Log($"Failed : {result.ShutdownReason}");
            }
                
        }

        public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
        {
            Debug.Log("hahaha");
            _realSessionList.Clear();
            
            foreach (Transform child in sessionContent)
            {
                Destroy(child.gameObject);
            }

            foreach (SessionInfo session in sessionList)
            {
                _realSessionList.Add(session);

                Debug.Log($"방 발견: {session.Name}");

                SessionItem item = Instantiate(
                    sessionItemPrefab,
                    sessionContent
                );

                item.SetSession(
                    session.Name,
                    session.PlayerCount,
                    session.MaxPlayers
                );
            }
        }
    
        public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
        {
            
        }

        public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
        {
            
        }

        public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {
            
        }

        public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
        {
            
        }

        public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
        {
            
        }

        public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
        {
            
        }

        public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
        {
            
        }

        public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
        {
            
        }

        public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
        {
            
        }

        public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
        {
            
        }

        public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
        {
            
        }

        public void OnInput(NetworkRunner runner, NetworkInput input)
        {
            
        }

        public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
        {
            
        }

        public void OnConnectedToServer(NetworkRunner runner)
        {
            
        }

        public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
        {
            
        }

        public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
        {
            
        }

        public void OnSceneLoadDone(NetworkRunner runner)
        {
            
        }

        public void OnSceneLoadStart(NetworkRunner runner)
        {
            
        }
    }
}
