using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PGGE.Patterns;
using PGGE;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public FSM mFsm = new FSM();
    public Animator mAnimator;
    public PlayerMovement mPlayerMovement;

    //[HideInInspector]
    public bool[] mAttackButtons = new bool[3];

    public LayerMask mPlayerMask;
    public AudioSource mAudioSource;
    public AudioClip YMCA;

    // Start is called before the first frame update
    void Start()
    {
        mFsm.Add(new PlayerState_MOVEMENT(this));
        mFsm.Add(new PlayerState_ATTACK(this));
        mFsm.Add(new PlayerState_TAUNT(this));
        mFsm.SetCurrentState((int)PlayerStateType.MOVEMENT);

        mAudioSource = GetComponent<AudioSource>();

        PlayerConstants.PlayerMask = mPlayerMask;
    }

    void Update()
    {
        mFsm.Update();



        if (Input.GetButtonDown("leftPunch"))
        {
            mAttackButtons[0] = true;
            mAttackButtons[1] = false;
            mAttackButtons[2] = false;
        }

        else if (Input.GetButtonDown("rightPunch"))
        {
            mAttackButtons[0] = false;
            mAttackButtons[1] = true;
            mAttackButtons[2] = false;
        }

        else if (Input.GetButtonDown("standingKick"))
        {
            mAttackButtons[0] = false;
            mAttackButtons[1] = false;
            mAttackButtons[2] = true;
        }
        else
        {
            mAttackButtons[0] = false;
            mAttackButtons[1] = false;
            mAttackButtons[2] = false;
        }

        if (mAnimator.GetBool("IsDancing"))
        {         
            if (Input.GetButtonDown("ymcaDance"))
            {
                Debug.Log("Stop!!");
                mAnimator.SetBool("IsDancing", false);
                mAudioSource.Stop();
            }
        }
        else
        {
            // Check if the player is not already dancing
            if (Input.GetButtonDown("ymcaDance"))
            {
                mAnimator.SetBool("IsDancing", true);
                mAudioSource.PlayOneShot(YMCA);
            }
        }

        if (Input.GetButtonDown("Taunt"))
        {
            mFsm.SetCurrentState((int)PlayerStateType.TAUNT);
        }

        
    }


    public void Move()
    {
        if (!mAnimator.GetBool("IsDancing"))
        {
            mPlayerMovement.HandleInputs();
            mPlayerMovement.Move();
        }
    }


}
