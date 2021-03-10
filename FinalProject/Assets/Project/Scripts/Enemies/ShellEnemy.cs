using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellEnemy : Enemy
{
    public GameObject shellPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnHit(GameObject hitter)
    {
        GameObject shellInstance = Instantiate(shellPrefab, transform.parent);
        shellInstance.transform.position = transform.position;

        base.OnHit(hitter);
    }
}
