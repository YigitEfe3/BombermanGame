using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    private float _speed = 5f;
    [SerializeField]
    private GameObject _bombPrefab;
    [SerializeField]
    private int _player1Lives;
    private Spawn_Manager _spawnManager;
    private UIManager _uiManager;
    private Animator animator;
    private float _fireRate = 4f;
    private float _canFire = 0.0f;
    private bool _isGamePlayable = false;
    private Player2 _player2;

    void Start()
    {
        _player1Lives = 3;
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        transform.position = new Vector3(12.7f, -5.5f, 26.5f);
        animator = GetComponent<Animator>();
        _player2 = GameObject.Find("Player2").GetComponent<Player2>();
    }

    void Update()
    {
        if (_isGamePlayable == true)
        {
            Player1Movement();

            if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
            {
                PlaceBomb();
            }
        }
    }

    void Player1Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.up * _speed * Time.deltaTime);
            animator.SetBool("isGoingUp", true);
            animator.SetBool("isGoingDown", false);
            animator.SetBool("isGoingRight", false);
            animator.SetBool("isGoingLeft", false);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-transform.up * _speed * Time.deltaTime);
            animator.SetBool("isGoingUp", false);
            animator.SetBool("isGoingDown", true);
            animator.SetBool("isGoingRight", false);
            animator.SetBool("isGoingLeft", false);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(transform.right * _speed * Time.deltaTime);
            animator.SetBool("isGoingUp", false);
            animator.SetBool("isGoingDown", false);
            animator.SetBool("isGoingRight", true);
            animator.SetBool("isGoingLeft", false);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
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
        _player1Lives--;

        _uiManager.updateLives(_player1Lives, 1);

        if (_player1Lives < 1)
        {
            _player2.player2Wins();
            _uiManager.blueWins();
            Destroy(this.gameObject);
            _spawnManager.onPlayerDeath();
        }
    }

    public void GainOneLife()
    {
        _player1Lives++;
        if (_player1Lives > 3)
            _player1Lives--;
        _uiManager.updateLives(_player1Lives, 1);
    }

    public void startGame()
    {
        _isGamePlayable = true;
    }

    public void player1Wins()
    {
        animator.SetBool("isWinner", true);
        animator.SetBool("isGoingUp", false);
        animator.SetBool("isGoingDown", false);
        animator.SetBool("isGoingRight", false);
        animator.SetBool("isGoingLeft", false);
    }
}
