using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class TurnSystem : MonoBehaviour
{
    public int currentTurn;
    public GameObject actionsHolder;
    public TextMeshProUGUI textLog;

    void Start()
    {
        NextTurn();
    }

    void Update()
    {
        //if(Input.GetButtonDown("Fire1")) NextTurn();
    }

    public Task UsedMove(string moveText)
    {
        actionsHolder.SetActive(false);
        textLog.text = moveText;
        return Task.Delay(1000);
    }

    public Task MoveResult(string moveResult)
    {
        
        textLog.text = moveResult;
        return Task.Delay(1000);
    }

    public void NextTurn()
    {
        currentTurn++;
        Debug.Log("Next Turn: " + currentTurn);
        textLog.text = "";
        actionsHolder.SetActive(true);
    }
}
