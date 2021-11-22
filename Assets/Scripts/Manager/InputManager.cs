using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    #region Variables
    public static InputManager Instance;
    public static event System.Action isWin;

    public List<GameObject> Players = new List<GameObject>();


    public int playerIndex;
    public bool Win = false;

    [SerializeField] float smoothness;
    [SerializeField] float forwardSpeed;

    [SerializeField] LayerMask Ground;
    [SerializeField] LayerMask Player;


    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (GameManager.Instance.isGameStarted && Players.Count>playerIndex)
        {
            Players[playerIndex].transform.Translate(Players[playerIndex].transform.forward *forwardSpeed* Time.deltaTime, Space.World);

            if (Input.GetMouseButtonDown(0))
            {

                SetTargetPosition();
            }

         
        }

        if (Players.Count > playerIndex &&  !Players[playerIndex].activeInHierarchy  )
        {
           // Players[playerIndex].SetActive(true);
            Players[playerIndex].transform.parent.gameObject.SetActive(true);
        }


        else if(Players.Count <= playerIndex)
        {
            Win = true; ;
            isWin?.Invoke();
        }

    }

    #endregion

    #region Other Methods

    public void SetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000, Ground))
        {

            var targetPos = hit.point;
            Players[playerIndex].transform.LookAt(new Vector3(targetPos.x, 0, targetPos.z));



        }

        if (Physics.Raycast(ray, out hit, 1000, Player))
        {

            var targetPos = hit.point;


        }
    }

    public void ActiveCar()
    {
       
        GameManager.Instance.isGameStarted = false;

    }



    #endregion
}
