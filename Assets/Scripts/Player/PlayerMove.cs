using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{

    public NavMeshAgent agent;
    [SerializeField] GameObject exit;
    [SerializeField] GameObject exitText;
    private Vector3 firstPos;
    private Quaternion firstRot;
    private bool canCrash;
    private bool isAgent;

    private void Start()
    {

        firstPos = transform.position;
        firstRot = transform.rotation;


    }

    private void Update()
    {


        if (GameManager.Instance.isGameStarted == false)
        {
            transform.position = firstPos;
            transform.rotation = firstRot;

            if (Input.GetMouseButtonDown(0))
            {
                GameManager.Instance.isGameStarted = true;

            }
        }

        if (GameManager.Instance.isGameStarted)
        {

            if (gameObject != InputManager.Instance.Players[InputManager.Instance.playerIndex] && gameObject.activeInHierarchy && InputManager.Instance.Win==false)
            {


                isAgent = true;
                agent.speed = 8;
                agent.SetDestination(exit.transform.position);

            }

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == exit && canCrash == false)
        {
            GameManager.Instance.isGameStarted = false;

            isAgent = true;
            exitText.SetActive(false);
            if (gameObject.activeInHierarchy)
            {
                transform.position = firstPos;
                InputManager.Instance.playerIndex += 1;
            }

            canCrash = true;

            if (isAgent == false)
            {
                exitText.SetActive(true);
            }
            else
                exitText.SetActive(false);

        }

        else
        {
            if (gameObject.activeInHierarchy && this.gameObject != InputManager.Instance.Players[InputManager.Instance.playerIndex])
            {

                InputManager.Instance.ActiveCar();


            }

        }
    }
}