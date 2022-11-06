using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MoveToUse : MonoBehaviour
{
    public Movimentos movimento;
    private TextMeshProUGUI tmp;
    public CandidatoInGame candidato;
    private Button button;

    public void Setup(Movimentos movimento, CandidatoInGame candidato)
    {
        this.movimento = movimento;
        this.candidato = candidato;
        button = GetComponent<Button>();
        button.onClick.AddListener(SelectMove);
        tmp = GetComponent<TextMeshProUGUI>();
        tmp.text = movimento.nome.ToUpper();
    }

    public void SelectMove()
    {
        if(candidato.nome == "Lula")
        GameState.lulaMove = movimento;
        else if(candidato.nome == "Bolsonaro")
        GameState.bolsonaroMove = movimento;
        else Debug.LogError("NÂO TEM CANDITADO COM ESSE NOME");
    }

    void Update()
    {
        if(movimento != null)
        {
            if(movimento.usosAtuais <= 0) button.interactable = false;
        }
    }
}
