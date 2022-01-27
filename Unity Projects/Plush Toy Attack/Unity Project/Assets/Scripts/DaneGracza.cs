using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class DaneGracza : MonoBehaviour
{
    [SerializeField] private Text HitPointsLabel;
    void Start()
    {
        HitPointsLabel.text =Managers.Player.health.ToString();
    }
    public void OnPlayerHurt()
    {
        HitPointsLabel.text = Managers.Player.health.ToString();
    }
    private void Update()
    { 
        HitPointsLabel.text = Managers.Player.health.ToString();
    }
}
