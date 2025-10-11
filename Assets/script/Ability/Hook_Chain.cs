using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook_Chain : MonoBehaviour
{
    public bool Is_Group;
    DistanceJoint2D joint;
    LineRenderer line;
    Hook_Shot Hook;
    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
        joint.enableCollision = false;
        joint.enabled = false;
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
        Hook = Hook_body.transform.GetComponent<Hook_Shot>();
    }
    public void Cut_Chain()
    {
       
        joint.enabled = false;
        line.enabled = false;
        line.positionCount = 0;
        Is_Group = false;
        Hook.Delete_chain();
    }
    public Vector2 GetAnchor_WorldPos()
    {
        if (!Is_Group)
        {
            return (Vector2)transform.position;
        }
        if (joint.connectedBody != null)
        {
            return joint.connectedBody.position;
        }
        return joint.connectedAnchor;
    } 
}
