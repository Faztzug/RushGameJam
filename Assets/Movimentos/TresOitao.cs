using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class TresOitao : Movimentos
{
    public override void MoveEffect(CandidatoInGame candidato)
    {
        if(usosAtuais <= 0) return;
        base.MoveEffect(candidato);
        int dmg = candidato.forcaEspecial * poder/100;
        Debug.Log("dmg " + dmg);
        target.DamageHealth(-dmg, isEspecial: true);
    }
}
