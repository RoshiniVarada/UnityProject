using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public float visibleHeight;
    public float raisingDuration;
    public float raisingSpeed;

    private float raisingTimer;
    private bool hidden;
    void Start()
    {
        raisingTimer = raisingDuration;
        hidden = true;

    }

    // Update is called once per frame
    void Update()
    {
        raisingTimer -= Time.deltaTime;
        if (raisingTimer <= 0.0f)
        {
            raisingTimer = raisingDuration;
            hidden = !hidden;
        }
        Vector3 targetPosition = new Vector3(
            enemy.transform.localPosition.x,
            hidden ? 0.0f : visibleHeight,
            enemy.transform.localPosition.z
        );
        enemy.transform.localPosition = Vector3.Lerp(enemy.transform.localPosition, targetPosition, raisingSpeed * Time.deltaTime);

    }
}
