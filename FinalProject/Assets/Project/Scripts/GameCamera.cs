using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public Vector3 offset;
    public float minimumY;
    public float smoothFactor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // transform.position = target.transform.position;

        Vector3 targetPosition = new Vector3(
                                        offset.x + target.transform.position.x,
                                        Mathf.Max(offset.y + target.transform.position.y, minimumY),
                                        offset.z + transform.position.z
                                    );
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.deltaTime);
    }
}
