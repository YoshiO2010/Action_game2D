using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook_Chain : MonoBehaviour
{
    public bool Is_Group;
    DistanceJoint2D joint;
    LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Is_Group == false)
        {
            return;
        }
        Vector3 end;
        Vector2 P = joint.connectedBody.position;
        end = (Vector3)P;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, end);
    }
    public void Connect_Chain(Rigidbody2D Hook_body)
    {
        joint.connectedBody = Hook_body;
        joint.connectedAnchor = Vector2.zero;
        joint.distance = Vector2.Distance(transform.position, Hook_body.position);
        joint.enabled = true;
        line.enabled = true;
        line.positionCount = 2;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, Hook_body.position);
        Is_Group = true;
    }
}
