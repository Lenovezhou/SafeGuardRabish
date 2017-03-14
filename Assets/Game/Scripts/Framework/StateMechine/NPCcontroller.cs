using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class NPCcontroller:StateMechine
{
    public GameObject NPC,Player;

    public Transform[] points;
    private int currentpos = 0;
    public State m_follow = new State();
    public State m_chase = new State();

    void Start() 
    {
        m_follow.m_OnEnter = StartFollow;
        m_chase.m_OnEnter = StartChase;

        m_follow.m_OnUpdate = FollowUpdate;
        m_chase.m_OnUpdate = ChaseUpdate;
        STATE = m_follow;
    }

    void Update() 
    {
        OnUpdateState(Time.deltaTime);
    }

    private void StartChase() 
    {
        Vector3 vel = NPC.GetComponent<Rigidbody>().velocity;

        Vector3 moveDir = Player.transform.position - NPC.transform.position;

        NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, Quaternion.LookRotation(moveDir), Time.deltaTime * 5);

        NPC.transform.eulerAngles = new Vector3(0, NPC.transform.eulerAngles.y, 0);

        NPC.GetComponent<Rigidbody>().velocity = moveDir.normalized * 10;
    }

    private void StartFollow() 
    {
        Vector3 vel = NPC.GetComponent<Rigidbody>().velocity;

        Vector3 moveDir = points[currentpos].transform.position - NPC.transform.position;

        if (moveDir.magnitude < 1)
        {
            currentpos++;
            if (currentpos >= points.Length)
            {
                currentpos = 0;
            }
        }
        else {
            NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, Quaternion.LookRotation(moveDir), Time.deltaTime * 5);

            NPC.transform.eulerAngles = new Vector3(0, NPC.transform.eulerAngles.y, 0);
        }
        NPC.GetComponent<Rigidbody>().velocity = moveDir.normalized * 10;

    }


    private void ChaseUpdate(float ti) 
    {
        if (Vector3.Distance(Player.transform.position,NPC.transform.position) >= 10)
        {
            STATE = m_follow;
        }
        m_chase.m_OnEnter();
    }

    Ray ray;
    private void FollowUpdate(float ti) 
    {
        ray.origin = NPC.transform.position;
        ray.direction = NPC.transform.forward;
        RaycastHit[] hits = Physics.SphereCastAll(ray, 5f);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.CompareTag("Player"))
            {
                STATE = m_chase;
            }
        }
        m_follow.m_OnEnter();
    }

}
