using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float Speed = 3.0f;
    private Transform myTransform = null;

    private float x = 0;
    private float z = 0;
    private float min = - 0.2f;
    private float max = 0.2f;

    // Start is called before the first frame update
    public void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Scaling(x);
        z = Scaling(z);
        Vector3 moveAmount = new Vector3(x, 0f, z);
        moveAmount = Speed * moveAmount * Time.deltaTime;
        myTransform.Translate(moveAmount);
    }

    private float Scaling(float xx)
    {
        xx = xx + Random.Range(min, max);
        if (Vector3.Distance(myTransform.position, Core.Instance.transform.position) > 50f)
        {
            xx = -xx;
        }
        else if(Mathf.Abs(xx) > 15)
        {
            xx = 0;
        }
        return xx;
    }

    public void stop()
    {
        HpManager.Instance.HeelHp();
        Vector3 moveAmount = new Vector3(0f, 0f, 0f);
        myTransform.Translate(moveAmount);
        this.Equals(false);
    }
}
