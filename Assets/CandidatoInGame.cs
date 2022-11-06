using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandidatoInGame : MonoBehaviour
{
    public CandidatoData data;
    public CandidatoInGame inimigo;
    [HideInInspector] public string nome;
    [HideInInspector] public string partido;
    [HideInInspector] public int numeroDoPartido;
    private int currentHP;
    [HideInInspector] public int iniciativa;
    [HideInInspector] public int forca;
    [HideInInspector] public int forcaEspecial;
    [HideInInspector] public int defesa;
    [HideInInspector] public int defesaEspecial;
    public List<Movimentos> movimentos;

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
    }

    public void DamageHealth(int value, bool isEspecial = false)
    {
        if(isEspecial) value += defesaEspecial;
        else value += defesa;
        if(value > 0) value = 0;
        currentHP -= value;
    }
}
