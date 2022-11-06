using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class FoiceEMartelo : Movimentos
{
    public override void MoveEffect(CandidatoInGame candidato)
    {
        if(usosAtuais <= 0) return;
        base.MoveEffect(candidato);
        Debug.Log("Foice dmg " + -damage);
        target.DamageHealth(-damage, isEspecial);
    }
}
