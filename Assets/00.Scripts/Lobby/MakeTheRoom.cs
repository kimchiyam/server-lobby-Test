using System;
using TMPro;
using UnityEngine;

namespace _00.Scripts.Lobby
{
    public class MakeTheRoom : MonoBehaviour
    {
        [SerializeField]TMP_InputField inputField;
        public event Action OnMaked;
        public void Make()
        {
            if (string.IsNullOrEmpty(inputField.text) || inputField.text == "     " ||  inputField.text == "    " ||  inputField.text == "   " ||  inputField.text == "   " ||  inputField.text == "  " ||  inputField.text == " ")
            {
                Debug.Log("name is null or empty");
                return;
            }
            
            LobbyManager.instance.CreateRoom(inputField.text);
            OnMaked?.Invoke();
        }
    }
}
