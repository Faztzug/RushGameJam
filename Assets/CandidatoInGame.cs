using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    public bool imunidade;
    [HideInInspector] public AudioSource audioSource;
    [HideInInspector] public Animator animator;
    public Image HPBar;

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
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

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
            
        }
        UpdateHealthBar();
    }

    public void IAMove()
    {
        imunidade = false;
        var validMoves = data.movimentos.FindAll(m => m.usosAtuais > 0);
        var rng = Random.Range(0, validMoves.Count);
        if(data.candidatoEnum == Candidato.Bolsonaro) GameState.bolsonaroMove = validMoves[rng];
        if(data.candidatoEnum == Candidato.Lula) GameState.lulaMove = validMoves[rng];
    }

    public void DamageHealth(int value, bool isEspecial = false)
    {
        if(value > 0) value = -value;
        if(isEspecial) value += defesaEspecial;
        else value += defesa;
        if(value > 0 || imunidade) value = 0;
        currentHP += value;
        HPText.text = "HP " + currentHP+"/"+data.maxHP;
        if(!imunidade) 
        {
            animator.SetTrigger("Dano");
            data.somAoLevarDano.PlayOn(audioSource);
        }
        UpdateHealthBar();
    }
    public void GainHealth(int value)
    {
        currentHP += value;
        if(currentHP > data.maxHP) currentHP = data.maxHP;
        HPText.text = "HP " + currentHP+"/"+data.maxHP;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float porcent = (float)currentHP / (float)data.maxHP;
        Debug.Log("porcent " + porcent);
        HPBar.fillAmount = porcent;
    }
}
