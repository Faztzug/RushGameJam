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
    
    public static TurnSystem turnSystem;
    public static Movimentos lulaMove;
    public static Movimentos bolsonaroMove;
    public static CandidatoInGame Lula;
    public static CandidatoInGame Bolsonaro;

    private void Awake() 
    {
        var otherGameState = GameObject.FindGameObjectWithTag("GameState");
        if(otherGameState != null && otherGameState.gameObject != this.gameObject) 
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        gameState = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public static async void FinishMovesChoice()
    {

        if(Bolsonaro.iniciativa > Lula.iniciativa)
        {
            await turnSystem.UsedMove((Bolsonaro.nome + " usou " + bolsonaroMove.nome).ToUpper());
            bolsonaroMove.MoveEffect(Bolsonaro);
            await turnSystem.MoveResult("RESULTADO");

            await turnSystem.UsedMove((Lula.nome + " usou " + lulaMove.nome).ToUpper());
            lulaMove.MoveEffect(Lula);
            await turnSystem.MoveResult("RESULTADO");
        }
        else
        {

            await turnSystem.UsedMove((Lula.nome + " usou " + lulaMove.nome).ToUpper());
            lulaMove.MoveEffect(Lula);
            await turnSystem.MoveResult("RESULTADO");
            
            await turnSystem.UsedMove((Bolsonaro.nome + " usou " + bolsonaroMove.nome).ToUpper());
            bolsonaroMove.MoveEffect(Bolsonaro);
            await turnSystem.MoveResult("RESULTADO");
        }
        await Task.Delay(2000);
        turnSystem.NextTurn();
    }
}
