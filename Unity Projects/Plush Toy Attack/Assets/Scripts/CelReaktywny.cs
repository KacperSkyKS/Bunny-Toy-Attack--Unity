using UnityEngine;
using System.Collections;
using System.Numerics;

public class CelReaktywny : MonoBehaviour
{
    [SerializeField] private GameObject CoinPrefab;
    private GameObject _coin;
    public float thrust = 1.0f;
    public Rigidbody rb;
    public void ReactToHit(float playerDamage)
    {
        AI_KROLIK behavior = GetComponent<AI_KROLIK>();
        if (behavior.health >= 0)
        {
            behavior.health -= playerDamage;

        }
        if (behavior.health <=0)
        {
            behavior.SetAlive(false);
            StartCoroutine(Die());
        }
    }
    void CoinDrop() {
        _coin = Instantiate(CoinPrefab) as GameObject;
        _coin.transform.position = new UnityEngine.Vector3(this.transform.position.x, this.transform.position.y + 0.5f, this.transform.position.z);
    }
    private IEnumerator Die()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(this.gameObject);
    }
}
