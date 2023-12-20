using Photon.Pun;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StateMachineController<T> : MonoBehaviour where T : MonoBehaviour
{
    private PlayerParameters m_PlayerParameters;
    private PlayerState m_PlayerState;

    private Dictionary<State, PlayerState> m_StateCache;
    protected virtual void Awake()
    {
        m_PlayerParameters = new PlayerParameters
        {
            PlayerController = GetComponent<PlayerController>(),
            CharacterController = GetComponent<CharacterController>(),
            Animator = GetComponent<Animator>(),
            PhotonView = GetComponent<PhotonView>(),
            InputManager = GetComponent<InputManager>(),
            PlayerInput = GetComponent<PlayerInput>()
        };

        InitializeStateCache();
    }

    protected virtual void Start() => TransistionState(State.Idle);
    protected virtual void Update() => m_PlayerState?.UpdateState();
    private void InitializeStateCache()
    {
        if (m_StateCache == null)
            m_StateCache = new Dictionary<State, PlayerState>();

        m_StateCache.Add(State.Idle, new IdleState(m_PlayerParameters));

        foreach (State state in Enum.GetValues(typeof(State)))
        {
            if (!m_StateCache.ContainsKey(state))
                m_StateCache.Add(state, CreateState(state));
        }
    }
    private PlayerState CreateState(State state)
    {
        switch (state)
        {
            case State.Idle:
                return new IdleState(m_PlayerParameters);
            case State.Run:
                return new RunState(m_PlayerParameters);
            case State.Sprint:
                return new SprintState(m_PlayerParameters);
            case State.Jump:
                return new JumpState(m_PlayerParameters);
            case State.Crouch:
                return new CrouchState(m_PlayerParameters);
            case State.Slide:
                return new SlideState(m_PlayerParameters);
            case State.ShapeChange:
                return new ShapeChangeState(m_PlayerParameters);
            case State.Attack:
                return new AttackState(m_PlayerParameters);
            default:
                throw new ArgumentOutOfRangeException(nameof(State), state, null);

        }
    }
    public virtual void TransistionState(State state)
    {
        if (m_StateCache.TryGetValue(state, out PlayerState existingCurrentState))
        {
            m_PlayerState?.ExitState();

            m_PlayerState = existingCurrentState;

            m_PlayerState?.EnterState();
        }
    }
}
