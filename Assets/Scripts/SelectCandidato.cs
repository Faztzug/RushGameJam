using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectCandidato : MonoBehaviour
{
    public Sound somNoHoverDoPersonagem;
    public Sound somAoEscolherBolsonaro;
    public Sound somAoEscolherLula;
    public AudioSource audioSource;

    private void Start() 
    {
        audioSource = GameState.GetAudioSource;
    }

    public void SelectLula()
    {
        GameState.candidato = Candidato.Lula;
        somAoEscolherLula.PlayOn(audioSource);
        SceneManager.LoadScene("Luta");
    }

    public void SelectBolsonaro()
    {
        GameState.candidato = Candidato.Bolsonaro;
        somAoEscolherBolsonaro.PlayOn(audioSource);
        SceneManager.LoadScene("Luta");
    }
    
    public void SelectNulo()
    {
        GameState.candidato = Candidato.NULL;
        somNoHoverDoPersonagem.PlayOn(audioSource);
        SceneManager.LoadScene("Luta");
    }

    public void ButtonHover()
    {
        somNoHoverDoPersonagem.PlayOn(audioSource);
    }
}
