using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayableDirector))]
public class GameOverScript : MonoBehaviour
{
    [Header("Game Over Settings")] 
    [SerializeField, Tooltip("Start Game Over sequence by pressing space.")]
    private bool debugStartGameOver = false;
    

    private PlayableDirector _gameOverAnimation;

    private void Start()
    {
        _gameOverAnimation = GetComponent<PlayableDirector>();
    }

    private void Update()
    {
        if (debugStartGameOver && Input.GetKeyDown(KeyCode.Space) || UIManager.instance.gameOver)
        {
            StartGameOver();    
        }
    }

    public void StartGameOver()
    {
        StartCoroutine(nameof(GameOver));
    }

    IEnumerator GameOver()
    {
        _gameOverAnimation.Play();
        
        while (_gameOverAnimation.state == PlayState.Playing)
            yield return null;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
