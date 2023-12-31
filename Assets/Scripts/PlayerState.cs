﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PGGE.Patterns;

public enum PlayerStateType
{
    MOVEMENT = 0,
    ATTACK,
    TAUNT,
}

public class PlayerState : FSMState
{
    protected Player mPlayer = null;

    public PlayerState(Player player) 
        : base()
    {
        mPlayer = player;
        mFsm = mPlayer.mFsm;
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}

public class PlayerState_MOVEMENT : PlayerState
{
    public PlayerState_MOVEMENT(Player player) : base(player)
    {
        mId = (int)(PlayerStateType.MOVEMENT);
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        

        mPlayer.Move();

        for (int i = 0; i < mPlayer.mAttackButtons.Length; ++i)
        {
            if (mPlayer.mAttackButtons[i])
            {
                PlayerState_ATTACK attack =
                  (PlayerState_ATTACK)mFsm.GetState(
                            (int)PlayerStateType.ATTACK);

                attack.AttackID = i;
                mPlayer.mFsm.SetCurrentState(
                    (int)PlayerStateType.ATTACK);

                //mPlayer.mAnimator.SetTrigger("leftPunch");
            }
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}

public class PlayerState_TAUNT : PlayerState
{
    private string mTauntAnimationName = "TauntTrigger";
    private bool mIsTaunting = false;

    public PlayerState_TAUNT(Player player) : base(player)
    {
        mId = (int)(PlayerStateType.TAUNT);
    }

    public override void Enter()
    {
        base.Enter();

        mPlayer.mAnimator.SetTrigger(mTauntAnimationName);
        mIsTaunting = true;
    }

    public override void Exit()
    {
        Debug.Log("Exit Taunt");
        mIsTaunting = false;
    }

    public override void Update()
    {
        base.Update();

        if (mIsTaunting && !mPlayer.mAnimator.GetCurrentAnimatorStateInfo(0).IsName(mTauntAnimationName))
        {          
            mPlayer.mFsm.SetCurrentState((int)PlayerStateType.MOVEMENT);
        }
    }
}



public class PlayerState_ATTACK : PlayerState
{
    private int mAttackID = 0;
    private string mAttackName;

    private bool IsTriggered = false;

    public int AttackID
    {
        get
        {
            return mAttackID;
        }
        set
        {
            mAttackID = value;
            mAttackName = "Attack" + (mAttackID + 1).ToString();
        }
    }

    public PlayerState_ATTACK(Player player) : base(player)
    {
        mId = (int)(PlayerStateType.ATTACK);
    }

    public override void Enter()
    {
        base.Enter();

        
        if (!IsTriggered)
        {
            mAttackName = "Attack" + (mAttackID + 1).ToString() + "Trigger";
            mPlayer.mAnimator.SetTrigger(mAttackName);
            IsTriggered = true;
        }

        
    }
    public override void Exit()
    {      
        IsTriggered = false;
    }
    public override void Update()
    {
        base.Update();

        

        if (mPlayer.mAttackButtons[mAttackID])
        {
            if (!IsTriggered)
            {

                mPlayer.mAnimator.SetTrigger(mAttackName);
                IsTriggered = true;
            }
            
        }
        else
        {          
            IsTriggered = false;
            mPlayer.mFsm.SetCurrentState((int)PlayerStateType.MOVEMENT);
        }
        
    }
}


