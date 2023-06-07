using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Mob : MonoBehaviour
{
    public float destroyDelay = 1f;
    public int mobHP = 20;
    public int mobdamage = 10;
    public int Score = 10;
    public UnityEvent OnCreated;
    public UnityEvent OnDestroyed;

    public enum State
    {
        TRACE,
        ATTACK,
        DIE
    }

    private bool isDestroyed = false;
    private bool IsCore = false;

    public bool isDie = false;
    public State state = State.TRACE;
    private Animator anim;

    private readonly int hashAttack = Animator.StringToHash("IsAttack");

    private void Start()
    {
        OnCreated?.Invoke();
        MobManager.Instance.OnSpawned(this);
        anim = GetComponent<Animator>();
        StartCoroutine(CheckMonsterState());
        StartCoroutine(MonsterAction());
    }

    IEnumerator CheckMonsterState()
    {

        while (!isDie)
        {

            yield return new WaitForSeconds(0.3f);
           

            if (IsCore == true)
            {
                state = State.ATTACK;
            }
            else
            {
                state = State.TRACE;
            }


        }
    }

    IEnumerator MonsterAction()
    {
        while (!isDie)
        {
            switch (state)
            {
                case State.ATTACK:
                    anim.SetBool("IsAttack", true);
                    break;
                case State.DIE:
                    anim.SetBool("IsAttack", true);
                    anim.SetBool("IsDie", true);
                    Destroy();
                    break;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }


    public void Destroy()
    {
        if (isDestroyed)
            return;
        isDestroyed = true;

        Destroy(gameObject, destroyDelay);

        OnDestroyed?.Invoke();
        MobManager.Instance.OnDestroyed(this);
    }

    public void Attacked()
    {
        IsCore = true;
        Destroy();
    }

    public int Attack()
    {
        return mobdamage;
    }

    public void DecreaseMobHP(int damage)
    {
        mobHP -= damage;
        if(mobHP <= 0)
        {
            anim.SetBool("IsDie", true);
            Destroy();
        }
    }
}