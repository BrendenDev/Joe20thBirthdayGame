using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerCameraAttach : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Transform playerCam; 
        [SerializeField] private float camHeight; 

        void Update()
        {
            playerCam.localScale = player.localScale;
            playerCam.position = new Vector3(player.position.x, player.position.y + camHeight, player.position.z); //camera hieght
            playerCam.rotation = Quaternion.Euler(playerCam.eulerAngles.x, player.eulerAngles.y, playerCam.eulerAngles.z);  
        }
    }
}
