using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public int usosAtuais;
    public int usosMaximos;
    public Transform proprioTransform;
    public Transform inimigoTransform;
    public GameObject animSiMesmo;
    public GameObject animNoInimigo;

    public virtual void MoveEffect() 
    { 
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
    }
}
