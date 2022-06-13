using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Summary : MonoBehaviour
{
    [SerializeField] private Text SummaryLabel;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        if (Kontroler.completedWaves > 1 || Kontroler.completedWaves == 0)
            SummaryLabel.text = "YOU SURVIVED " + Kontroler.completedWaves.ToString()+" WAVES";
        else
            SummaryLabel.text = "YOU SURVIVED " + Kontroler.completedWaves.ToString() + " WAVE";
    }
}
