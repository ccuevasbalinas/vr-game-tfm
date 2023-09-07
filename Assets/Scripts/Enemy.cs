using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Properties")]
    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private float _range = 8.0f;
    [SerializeField] private Transform _playerTransform;
    private bool _followPlayerEnabled = false;
    private bool isAlive = true;
    private bool isWalking = false;
    private Transform _transform;
    private Animator _animator;
    private AudioSource _audioSource;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _animator.Play("Idle");
    }

    private void Update()
    {
        if(isAlive)
        {
            CheckDistanceWithPlayer();
            FollowPlayer();
        }
    }

    private void CheckDistanceWithPlayer()
    {
        var distance = Vector3.Distance(transform.position, _playerTransform.position);
        if(distance < _range)
        {
            ActivateFollow();
            RunAnimation();
        }
        else
        {
            DeactivateFollow();
            IdleAnimation();
        }
            
    }

    private void FollowPlayer()
    {
        if (_followPlayerEnabled) 
        {
            _transform.LookAt(_playerTransform);
            _transform.position = Vector3.MoveTowards(_transform.position, _playerTransform.position, _speed * Time.deltaTime);
        }
    }

    private void ActivateFollow()
    {
        _followPlayerEnabled = true;      
    }

    private void RunAnimation()
    {
        if (!isWalking)
        {
            isWalking = true;
            _animator.Play("Run");
        }
    }

    private void DeactivateFollow()
    {
        _followPlayerEnabled = false;  
    }

    private void IdleAnimation()
    {
        if (isWalking)
        {
            isWalking = false;
            _animator.Play("Idle");
        }
    }

    public void Die()
    {
        isAlive = false;
        DeactivateFollow();
        _animator.Play("Scream");
        PlayEnemySound();
        StartCoroutine(DieCoroutine());
    }

    private void PlayEnemySound()
    {
        _audioSource.Play();
    }

    private IEnumerator DieCoroutine()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
