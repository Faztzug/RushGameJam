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
    [TextArea(1, 3)]
    public string effectDescription;
    public int poder;
    public bool isEspecial;
    public Alvo alvoDoEfeito;
    [HideInInspector] public int usosAtuais;
    public int usosMaximos;
    [HideInInspector] public Transform proprioTransform;
    [HideInInspector] public Transform inimigoTransform;
    public GameObject animSiMesmo;
    public GameObject animNoInimigo;
    protected CandidatoInGame target;
    protected int damage;
    public Sound tocarEsseSomAoUsar;

    public void SetUses()
    {
        usosAtuais = usosMaximos;
    }

    public virtual void QuickEffect(CandidatoInGame candidato, bool hasQuickEffect = false)
    {
        if(!hasQuickEffect) return;
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
        //só efeito de censura
    }

    public virtual void MoveEffect(CandidatoInGame candidato) 
    { 
        proprioTransform = candidato.transform;
        inimigoTransform = candidato.inimigo.transform;
        if(alvoDoEfeito == Alvo.SiMesmo) target = candidato;
        else target = candidato.inimigo;

        if(isEspecial) damage = candidato.forcaEspecial * poder/100;
        else damage = candidato.forca * poder/100;

        PlaySound(candidato);

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

    private void PlaySound(CandidatoInGame candidato)
    {
        if(tocarEsseSomAoUsar != null && tocarEsseSomAoUsar.clip != null) 
        {
            tocarEsseSomAoUsar.PlayOn(candidato.audioSource);
        }
    }
}
