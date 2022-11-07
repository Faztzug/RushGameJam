using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


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

    public Candidato candidatoVencedor;
    public static Candidato CandidatoVencedor
    { get => gameState.candidatoVencedor; 
    set => gameState.candidatoVencedor = value;}
    
    public static TurnSystem turnSystem;
    public static Movimentos lulaMove;
    public static Movimentos bolsonaroMove;
    public static CandidatoInGame Lula;
    public static CandidatoInGame Bolsonaro;
    
    private AudioSource audioSource;
    public static AudioSource GetAudioSource { get => gameState.audioSource; }

    private void Awake() 
    {
        var otherGameState = GameObject.FindGameObjectWithTag("GameState");
        if(otherGameState != null && otherGameState.gameObject != this.gameObject) 
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        gameState = this;
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    public static async void FinishMovesChoice()
    {
        bolsonaroMove.QuickEffect(Bolsonaro);
        lulaMove.QuickEffect(Lula);

        if(Bolsonaro.iniciativa > Lula.iniciativa)
        {
            await turnSystem.UsedMove((Bolsonaro.nome + " usou " + bolsonaroMove.nome).ToUpper());
            bolsonaroMove.MoveEffect(Bolsonaro);
            await turnSystem.MoveResult(bolsonaroMove.effectDescription.ToUpper());

            turnSystem.CheckGameOver();

            await turnSystem.UsedMove((Lula.nome + " usou " + lulaMove.nome).ToUpper());
            lulaMove.MoveEffect(Lula);
            await turnSystem.MoveResult(lulaMove.effectDescription.ToUpper());
        }
        else
        {

            await turnSystem.UsedMove((Lula.nome + " usou " + lulaMove.nome).ToUpper());
            lulaMove.MoveEffect(Lula);
            await turnSystem.MoveResult(lulaMove.effectDescription.ToUpper());
            
            turnSystem.CheckGameOver();
            
            await turnSystem.UsedMove((Bolsonaro.nome + " usou " + bolsonaroMove.nome).ToUpper());
            bolsonaroMove.MoveEffect(Bolsonaro);
            await turnSystem.MoveResult(bolsonaroMove.effectDescription.ToUpper());
        }
        
        turnSystem.CheckGameOver();
        turnSystem.NextTurn();
    }
}
