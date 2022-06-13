using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class Kontroler : MonoBehaviour
{
    [SerializeField] private Text scoreLabel;
    [SerializeField] private Text start_stop_waveLabel;
    [SerializeField] private Text CounterToWave;
    [SerializeField] private RoomChecker roomChecker;
    //public enum Spawn {WAITING,COUNTING,SPAWNING};
    [System.Serializable] public class Wave {
        public GameObject WrogPrefab;
        public int count;
        public float rate;
    }
    public Wave waves;
    public bool waveStarted = false;
    private bool waveSpawning = false;
    public bool waveStopped = true;
    public bool wantStopWaves = false;
    //public Spawn state = Spawn.COUNTING;
    public float timeBetweenWaves = 2f;
    public float waveCountdown;
    public float searchCountdown=1f;
    //private GameObject _enemy;
    public Transform[] spawnPoints;
    //private int maxAmountEnemy = 1;
    //public static int currentAmountEnemy=0;
    public static int completedWaves = 0;
    void Start() {
        scoreLabel.text = "Waves Survived: " + completedWaves.ToString();
        waveCountdown = timeBetweenWaves;
        Messenger.AddListener(GameEvent.WAVE_CLEARED, OnCompleteWave);
        start_stop_waveLabel.text = "Start Waves[L]";
    }
    void Update()
    {
        if (Managers.Player.health <= 0) {
            Messenger.RemoveListener(GameEvent.WAVE_CLEARED, OnCompleteWave);
            SceneManager.LoadScene("GameOver");
        }
        if (Input.GetKeyDown(KeyCode.L) && roomChecker.inUpgradeRoom == false) {
            if (wantStopWaves)
            {
                waveStopped = false;
                start_stop_waveLabel.text = "Stop Waves[L]";
                wantStopWaves = false;
            }
            else {
                start_stop_waveLabel.text = "Start Waves[L]";
                wantStopWaves = true;
                if (waveStarted == false) {
                    waveStopped = true;
                }
            }
        }
        if (waveStopped == false)
        {
            if (waveStarted)
            {
                if (!EnemiesAlive())
                {
                    WaveCompleted();
                }
                else
                {
                    return;
                }
            }
            if (waveCountdown <= 0)
            {
                CounterToWave.text = "";
                if (!waveStarted)
                {
                    StartCoroutine(SpawnWave(waves));
                }
            }
            else
            {
                waveCountdown -= Time.deltaTime;
                CounterToWave.text = "" + (int)waveCountdown;
            }
        }
    }
    bool EnemiesAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }
    void WaveCompleted() {
        Debug.Log("Wave Completed");
        Messenger.Broadcast(GameEvent.WAVE_CLEARED);
        if (completedWaves % 2 == 0) {
            waves.count += 2;
        }
        waveStarted = false;
        if (wantStopWaves == true) {
            waveStopped = true;
        }
        waveCountdown = timeBetweenWaves;
    }

    IEnumerator SpawnWave(Wave _wave) {
        waveSpawning = true;
        waveStarted = true;
        if (waveSpawning)
        {
            for (int i = 0; i < _wave.count; i++)
            {
                SpawnEnemy(_wave.WrogPrefab.transform);
                yield return new WaitForSeconds(1f / _wave.rate);
            }
            waveSpawning = false;
        }
        yield break;
    }
    void SpawnEnemy(Transform enemy) {
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];
        Instantiate(enemy, sp.position,sp.rotation);

    }
    //       Messenger.RemoveListener(GameEvent.WAVE_CLEARED, OnCompleteWave);
    private void OnCompleteWave()
    {
        completedWaves++;
        scoreLabel.text = "Waves Survived: " + completedWaves.ToString();
    }
    public int GetCompletedWaves() {
        return completedWaves;
    }
}
