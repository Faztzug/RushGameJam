using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    public int currentTurn;

    void Start()
    {
        NextTurn();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1")) NextTurn();
    }

    public void DamageStep()
    {
        //compara as iniciativas, quem tiver mais vai primeiro
        //Executa os ataques selecionados pela ordem de iniciativa

        NextTurn();
    }

    public void NextTurn()
    {
        currentTurn++;
        Debug.Log("Next Turn: " + currentTurn);
    }
}
