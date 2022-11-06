using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartState : MonoBehaviour
{
    public CandidatoInGame lula;
    public CandidatoInGame bolsonaro;
    public TurnSystem turnSystem;
    public Image actionBG;
    public Sprite lulaActionBG;
    public Sprite bolsonaroActionBG;

    private void Start() 
    {
        GameState.turnSystem = turnSystem;
        GameState.Lula = lula;
        GameState.Bolsonaro = bolsonaro;
        if(GameState.candidato == Candidato.Lula) actionBG.sprite = lulaActionBG;
        else actionBG.sprite = bolsonaroActionBG;
    }
}
