using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectCandidato : MonoBehaviour
{
    public void SelectLula()
    {
        GameState.candidato = Candidato.Lula;
        SceneManager.LoadScene("Luta");
    }

    public void SelectBolsonaro()
    {
        GameState.candidato = Candidato.Lula;
        SceneManager.LoadScene("Luta");
    }

    public void ButtonHover()
    {

    }
}
