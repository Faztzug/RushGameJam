using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

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
        return Task.Delay(3000);
    }

    public Task MoveResult(string moveResult)
    {
        textLog.text = moveResult;
        return Task.Delay(4000);
    }

    public void NextTurn()
    {
        currentTurn++;
        Debug.Log("Next Turn: " + currentTurn);
        textLog.text = "";

        actionsHolder.SetActive(true);
        GameState.Lula.IAMove();
        GameState.Bolsonaro.IAMove();
        if(GameState.candidato == Candidato.NULL) GameState.FinishMovesChoice();
    }
    
    public void CheckGameOver()
    {
        if(GameState.Lula.currentHP <= 0) GameState.CandidatoVencedor = Candidato.Bolsonaro;
        else if(GameState.Bolsonaro.currentHP <= 0) GameState.CandidatoVencedor = Candidato.Lula;
        else return;
        SceneManager.LoadScene("GameOver");

    }
}
