using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public enum Alvo
{
    Inimigo,
    SiMesmo,
}

public class Movimentos : MonoBehaviour
{
    public string nome;
    public int poder;
    public Alvo alvoDoEfeito;
    [HideInInspector] public int usosAtuais;
    public int usosMaximos;
    [HideInInspector] public Transform proprioTransform;
    [HideInInspector] public Transform inimigoTransform;
    public GameObject animSiMesmo;
    public GameObject animNoInimigo;
    protected CandidatoInGame target;
    public float waitSeconds = 2f;

    public void SetUses()
    {
        usosAtuais = usosMaximos;
    }

    public virtual void MoveEffect(CandidatoInGame candidato) 
    { 
        proprioTransform = candidato.transform;
        inimigoTransform = candidato.inimigo.transform;
        if(alvoDoEfeito == Alvo.SiMesmo) target = candidato;
        else target = candidato.inimigo;
        if(animSiMesmo) 
        {
            var anim = GameObject.Instantiate(animSiMesmo, proprioTransform.position, Quaternion.identity);
            Destroy(anim, 10f);
        }
        if(animNoInimigo) 
        {
            var anim = GameObject.Instantiate(animNoInimigo, inimigoTransform.position, Quaternion.identity);
            Destroy(anim, 10f);
        }
        usosAtuais--;
    }
}
