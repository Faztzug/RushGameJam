using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Candidato", menuName = "ScriptableObjects/Novo Candidato", order = 1)]
public class CandidatoData : ScriptableObject
{
    public string nome;
    public string partido;
    public int numero;
    public Sprite spriteDeFrente;
    public Sprite spriteDeCostas;
    public int maxHP;
    public int startHP;
    public List<Movimentos> movimentos;
    public string fraseDeInicio;
    public string fraseDeVitoria;
    public List<Sound> soms;
}
