using UnityEngine;
using System.Collections;
using System;


public class State  
{
    public Action m_OnEnter;
    public Action m_OnLeave;

    public Action<float> m_OnUpdate;
	
}

public class StateMechine : MonoBehaviour 
{

    private float m_state_timer;

    public float STATETIMER
    {
        get;
        private set;
    }

    private State m_state;

    public State STATE 
    {
        get { return m_state; }
        set 
        {
            if (m_state != null && m_state.m_OnLeave != null)
            {
                m_state.m_OnLeave();
            }
            m_state = value;
            if (m_state != null && m_state.m_OnEnter != null)
            {
                m_state.m_OnEnter();
            }
        }
    }

    protected void OnUpdateState(float deltatime) 
    {
        m_state_timer += deltatime;
        if (m_state != null && m_state.m_OnUpdate != null)
        {
            m_state.m_OnUpdate(deltatime);
        }
    }

    

}