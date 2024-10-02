using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrHabilidade 
{
    public string skillName;
    public string descricao;
    public bool passiva;




    public enum tipoSkill //TODO: fazer relativo ao player
    {
        EaumentarDano,
        Erichochete,
        Ehoradoduelo,
        EveloAtaque,
        Mmiraafiada,
        Msegurapeao,
        Mprecisao,
        MveloRecarga
    }

    


    private List<tipoSkill> skillDesbloqueadas;

    public scrHabilidade()//skill ativas
    {
        skillDesbloqueadas= new List<tipoSkill>();
    }

    public void DesbloquearSkill(tipoSkill skill)
    {
        skillDesbloqueadas.Add(skill);
    }

    public bool CheckSkill(tipoSkill skill)
    {
        return skillDesbloqueadas.Contains(skill);
    }
}
