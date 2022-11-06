using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TresOitao : Movimentos
{
    public override void MoveEffect(CandidatoInGame candidato)
    {
        if(usosAtuais <= 0) return;
        base.MoveEffect(candidato);
        int dmg = -(candidato.forcaEspecial * poder/100);
        target.DamageHealth(dmg, isEspecial: true);
    }
}
