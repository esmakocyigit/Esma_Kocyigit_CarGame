using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerMove playerMove = other.GetComponent<PlayerMove>();

        if (playerMove != null && other.transform.gameObject == InputManager.Instance.Players[InputManager.Instance.playerIndex])
        {

            InputManager.Instance.ActiveCar();
        }
    }
}
