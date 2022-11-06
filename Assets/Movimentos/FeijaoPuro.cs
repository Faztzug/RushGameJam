using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class FeijaoPuro : Movimentos
{
    public override void MoveEffect(CandidatoInGame candidato)
    {
        if(usosAtuais <= 0) return;
        base.MoveEffect(candidato);
        candidato.inimigo.DamageHealth(-candidato.forca);
        target.forca += poder;
        candidato.animator.SetBool("Bombado", true);
    }
}
