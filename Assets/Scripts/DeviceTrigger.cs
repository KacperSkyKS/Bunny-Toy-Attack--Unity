using UnityEngine;
using System.Collections;
public class DeviceTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] targets;
    [SerializeField] private Kontroler kontroler;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (GameObject target in targets)
            {
                if(kontroler.waveStarted == false && kontroler.waveStopped == true)
                target.SendMessage("Activate");
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (GameObject target in targets)
            {
                target.SendMessage("Deactivate");
            }
        }
    }
}
