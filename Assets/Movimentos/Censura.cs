using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Censura : Movimentos
{
    public override void QuickEffect(CandidatoInGame candidato, bool hasQuickEffect = true)
    {
        if(usosAtuais <= 0) return;
        base.QuickEffect(candidato, true);
        target.imunidade = true;
    }
}
