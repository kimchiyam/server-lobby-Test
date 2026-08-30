using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _00.Scripts.Lobby
{
    public class SessionItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI roomNameText;
        [SerializeField] private TextMeshProUGUI playerCountText;
        [SerializeField] private Button joinButton;

        private string _sessionName;

        public void SetSession(string sessionName, int playerCount, int maxPlayers)
        {
            _sessionName = sessionName;

            roomNameText.text = sessionName;
            playerCountText.text = $"{playerCount} / {maxPlayers}";

            joinButton.onClick.RemoveAllListeners();
            joinButton.onClick.AddListener(JoinRoom);
        }

        private void JoinRoom()
        {
            LobbyManager.instance.JoinRoom(_sessionName);
        }
    }
}