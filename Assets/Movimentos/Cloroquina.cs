using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Cloroquina : Movimentos
{
    public override void MoveEffect(CandidatoInGame candidato)
    {
        if(usosAtuais <= 0) return;
        base.MoveEffect(candidato);
    }
}
