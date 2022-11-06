using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : MonoBehaviour
{
    public CandidatoInGame lula;
    public CandidatoInGame bolsonaro;
    public TurnSystem turnSystem;

    private void Start() 
    {
        GameState.turnSystem = turnSystem;
        GameState.Lula = lula;
        GameState.Bolsonaro = bolsonaro;
    }
}
