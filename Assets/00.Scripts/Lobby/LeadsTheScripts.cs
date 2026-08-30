using System;
using TMPro;
using UnityEngine;

namespace _00.Scripts.Lobby
{
    public class LeadsTheScripts : MonoBehaviour
    {
        [SerializeField]LoadingScreen _loadingScreen;
        [SerializeField]MakeTheRoom _makeTheRoom;


        private void Start()
        {
            _makeTheRoom.OnMaked += _loadingScreen.ShowMyBody;
        }
    }
}
