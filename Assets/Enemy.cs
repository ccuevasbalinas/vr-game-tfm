using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Properties")]
    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private bool _followPlayerEnabled = true;
    private Transform _transform;
    private Animator _animator;
    private AudioSource _audioSource;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (_followPlayerEnabled) 
        {
            _transform.LookAt(_playerTransform);
            _transform.position = Vector3.MoveTowards(_transform.position, _playerTransform.position, _speed * Time.deltaTime);
        }
    }

    public void ActivateFollow()
    {
        _followPlayerEnabled = true;
    }

    private void DeactivateFollow()
    {
        _followPlayerEnabled = false;
        _animator.Play("Scream");
    }

    public void Die()
    {
        DeactivateFollow();
        PlayEnemySound();
        StartCoroutine(DieCoroutine());
    }

    public void PlayEnemySound()
    {
        _audioSource.Play();
    }

    private IEnumerator DieCoroutine()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
