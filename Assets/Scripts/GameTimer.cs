using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("Level timer in seconds")]
    [SerializeField] float levelTime = 10f;
    bool triggeredLevelFinished = false;

    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished == true) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
            
        }
    }
}
