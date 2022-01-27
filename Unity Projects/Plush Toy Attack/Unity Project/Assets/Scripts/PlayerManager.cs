using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    public int health { get; private set; }
    public int baseMaxHealth { get; private set; }
    public int maxHealth { get; private set; }
    public int HP_UPGRADES { get;  set; }
    public int DMG_UPGRADES { get;  set; }
    public int SPEED_UPGRADES { get;  set; }
    public int ATTACK_SPEED_UPGRADES { get;  set; }

    public void Startup()
    {
        Debug.Log("Player manager starting...");
        baseMaxHealth = 100;
        maxHealth = baseMaxHealth;
        health = maxHealth;
        HP_UPGRADES = 0;
        DMG_UPGRADES = 0;
        SPEED_UPGRADES = 0;
        ATTACK_SPEED_UPGRADES = 0;
        status = ManagerStatus.Started;
    }
    public void ChangeHealth(int value)
    {
        health += value;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health < 0)
        {
            health = 0;
        }
        Debug.Log("Health: " + health + "/" + maxHealth);
    }
    public DaneGracza other;
    public void hurtPlayer(int value) {
        Debug.Log("Zmiana HP");
        health -= value;
        other.GetComponent<DaneGracza>().OnPlayerHurt(); 
    }
    public void ChangeMaxHealth() {
        maxHealth=baseMaxHealth+(25*HP_UPGRADES);
        Debug.Log(maxHealth);
    }

}
