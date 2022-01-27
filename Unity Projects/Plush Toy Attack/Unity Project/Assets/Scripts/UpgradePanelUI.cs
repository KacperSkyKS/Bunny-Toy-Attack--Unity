using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanelUI : MonoBehaviour
{
    [SerializeField] private Text HPLabel;
    [SerializeField] private Text DMGLabel;
    [SerializeField] private Text SPEEDLabel;
    [SerializeField] private Text HP_REGLabel;
    [SerializeField] private Text WARNINGLabel;
    void Update()
    {
        if (Managers.Player.HP_UPGRADES < 10)
        {
            HPLabel.text = (Managers.Player.HP_UPGRADES + 1).ToString() + "$";
        }else {
            HPLabel.text = "MAX";
        }
        if (Managers.Player.DMG_UPGRADES < 10)
        {
            DMGLabel.text = (Managers.Player.DMG_UPGRADES + 1).ToString() + "$";
        }else
        {
            DMGLabel.text = "MAX";
        }
        if (Managers.Player.SPEED_UPGRADES < 10)
        {
            SPEEDLabel.text = (Managers.Player.SPEED_UPGRADES + 1).ToString() + "$";
        }else
        {
            SPEEDLabel.text = "MAX";
        }
        
        if (Managers.Player.ATTACK_SPEED_UPGRADES < 10)
        {
            HP_REGLabel.text = (Managers.Player.ATTACK_SPEED_UPGRADES + 1).ToString() + "$";
        }else
        {
            HP_REGLabel.text = "MAX";
        }
    }
    public void HP_Upgrade()
    {
        if (Managers.Inventory.GetItemCount("Coin") >= Managers.Player.HP_UPGRADES + 1 && Managers.Player.HP_UPGRADES <= 10)
        {

            Managers.Inventory.RemoveItem("Coin", Managers.Player.HP_UPGRADES + 1);
            Managers.Player.HP_UPGRADES++;
            Managers.Player.ChangeMaxHealth();
            Managers.Player.ChangeHealth(25);
        }
    }
    public void DMG_Upgrade()
    {
        if (Managers.Inventory.GetItemCount("Coin") >= Managers.Player.DMG_UPGRADES + 1 && Managers.Player.DMG_UPGRADES <= 10)
        {
            Managers.Inventory.RemoveItem("Coin", Managers.Player.DMG_UPGRADES + 1);
            Managers.Player.DMG_UPGRADES++;
        }
    }
    public void SPEED_Upgrade()
    {
        if (Managers.Inventory.GetItemCount("Coin") >= Managers.Player.SPEED_UPGRADES + 1 && Managers.Player.SPEED_UPGRADES <= 10)
        {
            Managers.Inventory.RemoveItem("Coin", Managers.Player.SPEED_UPGRADES + 1);
            Managers.Player.SPEED_UPGRADES++;
        }
    }
    public void ATTACK_SPEED_Upgrade()
    {
        if (Managers.Inventory.GetItemCount("Coin") >= Managers.Player.ATTACK_SPEED_UPGRADES + 1 && Managers.Player.ATTACK_SPEED_UPGRADES <= 10)
        {
            Managers.Inventory.RemoveItem("Coin", Managers.Player.ATTACK_SPEED_UPGRADES + 1);
            Managers.Player.ATTACK_SPEED_UPGRADES++;
        }
    }
    public void Open()
    {

        Time.timeScale = 0;
        gameObject.SetActive(true);
    }
    public void Close()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
