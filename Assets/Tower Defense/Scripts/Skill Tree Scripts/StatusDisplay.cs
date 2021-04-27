using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HP.text = "0000";
        ATK.text = "0000";
        DEF.text = "0000";
        RES.text = "0000";
        ATKSPD.text = "0000";
        DPCost.text = "0000";
        ReDP.text = "0000";
    }

    public void OnDisplay()
    {
        status = GetComponent<TowerDefense.Game.CharacterData>();
        HP.text = status.healthPoint.ToString();
        ATK.text = status.attackDamage.ToString();
        DEF.text = status.defense.ToString();
        RES.text = status.resistance.ToString();
        //ATKSPD.text = status.attackSpeed.ToString();
        //DPCost.text = status.cost.ToString();
        //ReDP.text = status.redeployTime.ToString();
    }

    public void EnableDisplay()
    {
        if (SkillManager.instance.characters[0].activateSkill)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
    }    

    private TowerDefense.Game.CharacterData status;
    public Text HP, ATK, DEF, RES, ATKSPD, DPCost, ReDP;
}
