using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[System.Serializable]
public class PlayerParameters
{
    [field: SerializeField]
    public byte RunSpeed { get; private set; }

    [field: SerializeField]
    public byte SprintSpeed { get; private set; }

    [field: SerializeField]
    public float SpeedChangeRate { get; private set; }

    [field: SerializeField]
    public byte CrounchWalkSpeed { get; private set; }

    [field: SerializeField]
    public float SlideStaminaRate { get; private set; }

    [field: SerializeField]
    public float IncreaseStaminaRate { get; private set; }

    [field: SerializeField]
    public float DecreaseStaminaRate { get; private set; }


    [HideInInspector] public CharacterController CharacterController;
    [HideInInspector] public Animator Animator;
    [HideInInspector] public PhotonView PhotonView;
    [HideInInspector] public PlayerController PlayerController;
    [HideInInspector] public InputManager InputManager;
    [HideInInspector] public PlayerInput PlayerInput;
    [HideInInspector] public float TargetSpeed;
}
