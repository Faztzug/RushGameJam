using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CandidatoInGame : MonoBehaviour
{
    public CandidatoData data;
    public CandidatoInGame inimigo;
    [HideInInspector] public string nome;
    [HideInInspector] public string partido;
    [HideInInspector] public int numeroDoPartido;
    public int currentHP;
    [HideInInspector] public int iniciativa;
    public int forca;
    [HideInInspector] public int forcaEspecial;
    [HideInInspector] public int defesa;
    [HideInInspector] public int defesaEspecial;
    public List<Movimentos> movimentos;
    public Transform actionsHolder;
    public GameObject moveToUsePrefab;
    public TextMeshProUGUI HPText;

    void Start()
    {
        this.nome = data.nome;
        partido = data.partido;
        numeroDoPartido = data.numeroDoPartido;
        currentHP = data.startHP;
        iniciativa = data.iniciativa;
        forca = data.forca;
        forcaEspecial = data.forcaEspecial;
        defesa = data.defesa;
        defesaEspecial = data.defesaEspecial;
        movimentos = data.movimentos;

        foreach (var move in data.movimentos) move.SetUses();

        if(data.candidatoEnum == GameState.candidato)
        {
            foreach (var move in data.movimentos)
            {
                Debug.Log("Instatiate Move: " + move.nome);
                var moveToUse = GameObject.Instantiate(moveToUsePrefab, actionsHolder).GetComponent<MoveToUse>();
                moveToUse.Setup(move, this);
            }
        }
        else
        {
            var validMoves = data.movimentos.FindAll(m => m.usosAtuais > 0);
            var rng = Random.Range(0, validMoves.Count);
            if(data.candidatoEnum == Candidato.Bolsonaro) GameState.bolsonaroMove = validMoves[rng];
            if(data.candidatoEnum == Candidato.Lula) GameState.lulaMove = validMoves[rng];
        }
    }

    public void DamageHealth(int value, bool isEspecial = false)
    {
        if(isEspecial) value += defesaEspecial;
        else value += defesa;
        if(value > 0) value = 0;
        Debug.Log("value " + value);
        currentHP += value;
        HPText.text = "HP " + currentHP+"/"+data.maxHP;
    }
}
