using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Candidato", menuName = "ScriptableObjects/Novo Candidato", order = 1)]
public class CandidatoData : ScriptableObject
{
    public string nome;
    public Candidato candidatoEnum;
    public string partido;
    public int numeroDoPartido;
    public Sprite spriteDeFrente;
    public Sprite spriteDeCostas;
    public int maxHP;
    public int startHP;
    public int iniciativa;
    public int forca;
    public int forcaEspecial;
    public int defesa;
    public int defesaEspecial;
    public List<Movimentos> movimentos;
    public string fraseDeInicio;
    public string fraseDeVitoria;
    public Sound somAoLevarDano;
    public Sound somAoVencer;
}
