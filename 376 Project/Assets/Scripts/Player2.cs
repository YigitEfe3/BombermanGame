using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    private float _speed = 5f;
    [SerializeField]
    private GameObject _bombPrefab;
    [SerializeField]
    private int _player2Lives;
    private Spawn_Manager _spawnManager;
    private UIManager _uiManager;
    private Animator animator;
    private float _fireRate = 4f;
    private float _canFire = 0.0f;
    private bool _isGamePlayable = false;
    private Player1 _player1;

    void Start()
    {
        _player2Lives = 3;
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        transform.position = new Vector3(-9.5f, 6.25f, 26.5f);
        animator = GetComponent<Animator>();
        _player1 = GameObject.Find("Player1").GetComponent<Player1>();
    }

    void Update()
    {
        if (_isGamePlayable == true)
        {
            Player2Movement();

            if (Input.GetKeyDown(KeyCode.Q) && Time.time > _canFire)
            {
                PlaceBomb();
            }
        }
    }

    void Player2Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.up * _speed * Time.deltaTime);
            animator.SetBool("isGoingUp", true);
            animator.SetBool("isGoingDown", false);
            animator.SetBool("isGoingRight", false);
            animator.SetBool("isGoingLeft", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-transform.up * _speed * Time.deltaTime);
            animator.SetBool("isGoingUp", false);
            animator.SetBool("isGoingDown", true);
            animator.SetBool("isGoingRight", false);
            animator.SetBool("isGoingLeft", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * _speed * Time.deltaTime);
            animator.SetBool("isGoingUp", false);
            animator.SetBool("isGoingDown", false);
            animator.SetBool("isGoingRight", true);
            animator.SetBool("isGoingLeft", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-transform.right * _speed * Time.deltaTime);
            animator.SetBool("isGoingUp", false);
            animator.SetBool("isGoingDown", false);
            animator.SetBool("isGoingRight", false);
            animator.SetBool("isGoingLeft", true);
        }
        else
        {
            animator.SetBool("isGoingUp", false);
            animator.SetBool("isGoingDown", false);
            animator.SetBool("isGoingRight", false);
            animator.SetBool("isGoingLeft", false);
        }
    }

    void PlaceBomb()
    {
        Vector3 bombPosition = new Vector3(transform.position.x, transform.position.y, 26.5f);

        _canFire = Time.time + _fireRate;

        Instantiate(_bombPrefab, bombPosition, Quaternion.identity);
    }

    public void Damage()
    {
        _player2Lives--;

        _uiManager.updateLives(_player2Lives, 2);

        if (_player2Lives < 1)
        {
            _player1.player1Wins();
            _uiManager.redWins();
            Destroy(this.gameObject);
            _spawnManager.onPlayerDeath();
        }
    }

    public void GainOneLife()
    {
        _player2Lives++;
        if (_player2Lives > 3)
            _player2Lives--;
        _uiManager.updateLives(_player2Lives, 2);
    }

    public void startGame()
    {
        _isGamePlayable = true;
    }

    public void player2Wins()
    {
        animator.SetBool("isWinner", true);
        animator.SetBool("isGoingUp", false);
        animator.SetBool("isGoingDown", false);
        animator.SetBool("isGoingRight", false);
        animator.SetBool("isGoingLeft", false);
    }
}
