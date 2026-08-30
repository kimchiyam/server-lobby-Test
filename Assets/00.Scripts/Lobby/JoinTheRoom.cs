using TMPro;
using UnityEngine;

namespace _00.Scripts.Lobby
{
    public class JoinTheRoom : MonoBehaviour
    {
        [SerializeField]TMP_InputField inputField;
        public void Join()
        {
            LobbyManager.instance.CheckRoom(inputField.text);
        }
    }
}
