using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SetGameOverScreen : MonoBehaviour
{
    public Image background;
    public Sprite lulaBG;
    public Sprite bolsonaroBG;
    public Image lulaPortrait;
    public Sprite lulaVenceu;
    public Sprite lulaPerdeu;
    public Image bolsonaroPortrait;
    public Sprite bolsonaroVenceu;
    public Sprite bolsonaroPerdeu;
    public TextMeshProUGUI textMesh;
    public CandidatoData lulaData;
    public CandidatoData bolsonaroData;
    private AudioSource audioSource;
    public Animator faixa;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(GameState.CandidatoVencedor == Candidato.Lula)
        {
            background.sprite = lulaBG;
            bolsonaroPortrait.sprite = bolsonaroPerdeu;
            lulaPortrait.sprite = lulaVenceu;
            textMesh.text = lulaData.fraseDeVitoria;
            lulaData.somAoVencer.PlayOn(audioSource);
            faixa.SetBool("Lula", true);
        }
        else
        {
            background.sprite = bolsonaroBG;
            bolsonaroPortrait.sprite = bolsonaroVenceu;
            lulaPortrait.sprite = lulaPerdeu;
            textMesh.text = bolsonaroData.fraseDeVitoria;
            bolsonaroData.somAoVencer.PlayOn(audioSource);
            faixa.SetBool("Bolsonaro", true);
        }
    }


}
