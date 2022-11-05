using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeijaoPuro : Movimentos
{
    public override void MoveEffect(CandidatoInGame candidato)
    {
        if(usosAtuais <= 0) return;
        base.MoveEffect(candidato);
        target.forca += poder;
    }
}
