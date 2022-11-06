using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : MonoBehaviour
{
    public CandidatoInGame lula;
    public CandidatoInGame bolsonaro;

    private void Start() 
    {
        GameState.Lula = lula;
        GameState.Bolsonaro = bolsonaro;
    }
}
