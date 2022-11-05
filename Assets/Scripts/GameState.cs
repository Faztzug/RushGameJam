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
    public static Candidato candidato;

    private void Awake() 
    {
        gameState = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
