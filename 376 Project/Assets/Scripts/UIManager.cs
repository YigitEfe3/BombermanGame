using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Image P1has1life;
    [SerializeField]
    private Image P1has2lives;
    [SerializeField]
    private Image P1has3lives;
    [SerializeField]
    private Image P2has1life;
    [SerializeField]
    private Image P2has2lives;
    [SerializeField]
    private Image P2has3lives;

    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _helpRed;
    [SerializeField]
    private Text _helpBlue;
    [SerializeField]
    private Text _helpWhite;
    [SerializeField]
    private Text _helpPowerup;
    [SerializeField]
    private Text _helpBombs;
    [SerializeField]
    private Text _gameName;
    [SerializeField]
    private Text _blueWins;
    [SerializeField]
    private Text _redWins;
    [SerializeField]
    private Text _theWinner;
    [SerializeField]
    private Text _P1lives;
    [SerializeField]
    private Text _P2lives;

    [SerializeField]
    private Button _playGame;
    [SerializeField]
    private Button _help;
    private int _helpflag = 0;
    [SerializeField]
    private Button _exitGame;
    [SerializeField]
    private Button _mainMenu;

    [SerializeField]
    private Player1 _player1;
    [SerializeField]
    private Player2 _player2;

    void Start()
    {
        _helpRed.gameObject.SetActive(false);
        _helpBlue.gameObject.SetActive(false);
        _helpWhite.gameObject.SetActive(false);
        _helpPowerup.gameObject.SetActive(false);
        _helpBombs.gameObject.SetActive(false);

        P1has1life.enabled = true;
        P1has2lives.enabled = true;
        P1has3lives.enabled = true;
        P2has1life.enabled = true;
        P2has2lives.enabled = true;
        P2has3lives.enabled = true;

        _player1 = GameObject.Find("Player1").GetComponent<Player1>();
        _player2 = GameObject.Find("Player2").GetComponent<Player2>();
    }

    public void updateLives(int currentLives, int player)
    {
        if(player == 1)
        {
            if (currentLives == 3)
            {
                P1has1life.enabled = true;
                P1has2lives.enabled = true;
                P1has3lives.enabled = true;
            }
            else if (currentLives == 2)
            {
                P1has1life.enabled = true;
                P1has2lives.enabled = true;
                P1has3lives.enabled = false;
            }
            else if (currentLives == 1)
            {
                P1has1life.enabled = true;
                P1has2lives.enabled = false;
                P1has3lives.enabled = false;
            }
        }

        if (player == 2)
        {
            if (currentLives == 3)
            {
                P2has1life.enabled = true;
                P2has2lives.enabled = true;
                P2has3lives.enabled = true;
            }
            else if (currentLives == 2)
            {
                P2has1life.enabled = true;
                P2has2lives.enabled = true;
                P2has3lives.enabled = false;
            }
            else if (currentLives == 1)
            {
                P2has1life.enabled = true;
                P2has2lives.enabled = false;
                P2has3lives.enabled = false;
            }
        }
    }

    public void HelpButton()
    {
        if(_helpflag == 0)
        {
            _helpRed.gameObject.SetActive(true);
            _helpBlue.gameObject.SetActive(true);
            _helpWhite.gameObject.SetActive(true);
            _helpPowerup.gameObject.SetActive(true);
            _helpBombs.gameObject.SetActive(true);
            _playGame.gameObject.SetActive(true);
            _help.gameObject.SetActive(true);
            _exitGame.gameObject.SetActive(true);
            _gameOverText.gameObject.SetActive(false);
            _redWins.gameObject.SetActive(false);
            _blueWins.gameObject.SetActive(false);
            _mainMenu.gameObject.SetActive(false);
            _helpflag = 1;
        }
        else if(_helpflag == 1)
        {
            _helpRed.gameObject.SetActive(false);
            _helpBlue.gameObject.SetActive(false);
            _helpWhite.gameObject.SetActive(false);
            _helpPowerup.gameObject.SetActive(false);
            _helpBombs.gameObject.SetActive(false);
            _playGame.gameObject.SetActive(true);
            _help.gameObject.SetActive(true);
            _exitGame.gameObject.SetActive(true);
            _gameOverText.gameObject.SetActive(false);
            _redWins.gameObject.SetActive(false);
            _blueWins.gameObject.SetActive(false);
            _mainMenu.gameObject.SetActive(false);
            _helpflag = 0;
        }
    }

    public void ExitButton()
    {
        #if UNITY_EDITOR
             
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void PlayButton()
    {
        _helpRed.gameObject.SetActive(false);
        _helpBlue.gameObject.SetActive(false);
        _helpWhite.gameObject.SetActive(false);
        _helpPowerup.gameObject.SetActive(false);
        _helpBombs.gameObject.SetActive(false);
        _gameName.gameObject.SetActive(false);
        _playGame.gameObject.SetActive(false);
        _help.gameObject.SetActive(false);
        _exitGame.gameObject.SetActive(false);
        _gameOverText.gameObject.SetActive(false);
        _redWins.gameObject.SetActive(false);
        _blueWins.gameObject.SetActive(false);
        _mainMenu.gameObject.SetActive(false);

        _P1lives.gameObject.SetActive(true);
        _P2lives.gameObject.SetActive(true);

        _player1.startGame();
        _player2.startGame();
    }

    public void MainMenu()
    {
        _helpRed.gameObject.SetActive(false);
        _helpBlue.gameObject.SetActive(false);
        _helpWhite.gameObject.SetActive(false);
        _helpPowerup.gameObject.SetActive(false);
        _helpBombs.gameObject.SetActive(false);
        _gameOverText.gameObject.SetActive(false);
        _gameName.gameObject.SetActive(true);
        _playGame.gameObject.SetActive(true);
        _help.gameObject.SetActive(true);
        _exitGame.gameObject.SetActive(true);
        _redWins.gameObject.SetActive(false);
        _blueWins.gameObject.SetActive(false);
        _mainMenu.gameObject.SetActive(false);
        SceneManager.LoadScene("Gameplay");
    }

    public void redWins()
    {
        _gameOverText.gameObject.SetActive(true);
        _theWinner.gameObject.SetActive(true);
        _redWins.gameObject.SetActive(true);
        _blueWins.gameObject.SetActive(false);
        _gameName.gameObject.SetActive(true);
        _helpRed.gameObject.SetActive(false);
        _helpBlue.gameObject.SetActive(false);
        _helpWhite.gameObject.SetActive(false);
        _helpPowerup.gameObject.SetActive(false);
        _helpBombs.gameObject.SetActive(false);
        _help.gameObject.SetActive(false);
        _playGame.gameObject.SetActive(false);
        _exitGame.gameObject.SetActive(false);
        _mainMenu.gameObject.SetActive(true); 
         Button b = _mainMenu.GetComponent<Button>();
        ColorBlock cb = b.colors;
        cb.normalColor = Color.red;
        b.colors = cb;

    }

    public void blueWins()
    {
        _gameOverText.gameObject.SetActive(true);
        _redWins.gameObject.SetActive(false);
        _theWinner.gameObject.SetActive(true);
        _blueWins.gameObject.SetActive(true);
        _gameName.gameObject.SetActive(true);
        _helpRed.gameObject.SetActive(false);
        _helpBlue.gameObject.SetActive(false);
        _helpWhite.gameObject.SetActive(false);
        _helpPowerup.gameObject.SetActive(false);
        _helpBombs.gameObject.SetActive(false);
        _help.gameObject.SetActive(false);
        _playGame.gameObject.SetActive(false);
        _exitGame.gameObject.SetActive(false);
        _mainMenu.gameObject.SetActive(true);
        Button b = _mainMenu.GetComponent<Button>();
        ColorBlock cb = b.colors;
        cb.normalColor = Color.blue;
        b.colors = cb;
    }
}
