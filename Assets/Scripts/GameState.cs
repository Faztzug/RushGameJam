using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Candidato
{
    NULL,
    Lula,
    Bolsonaro,
}
public class GameState : MonoBehaviour
{
    private static GameState gameState;
    private GameState() { }
    public static GameState GameStateInstance => gameState;
    public Candidato selectedCandidato;
    public static Candidato candidato 
    { get => gameState.selectedCandidato; 
    set => gameState.selectedCandidato = value;}
    
    public static Movimentos lulaMove;
    public static Movimentos bolsonaroMove;
    public static CandidatoInGame Lula;
    public static CandidatoInGame Bolsonaro;

    private void Awake() 
    {
        gameState = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
