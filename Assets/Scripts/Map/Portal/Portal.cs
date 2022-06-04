using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    enum TypePortal
    {
        exitGame,
        loadLocation
    }

    [SerializeField] private TypePortal _typePortal;


    [SerializeField] private int _loadSceneId = 1;
    [SerializeField] private bool _isReady;

    private Animator _animator;

    private bool _isEnable;
    private void Start() => _animator = GetComponent<Animator>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !_isEnable)
        {
            _animator.SetBool("Enable", true);
            _isEnable = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && _isEnable && _isReady)
        {
            switch (_typePortal)
            {
                case TypePortal.exitGame:
                    Application.Quit();
                    break;
                case TypePortal.loadLocation:
                    SceneManager.LoadScene(_loadSceneId);
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && _isEnable)
        {
            _animator.SetBool("Enable", false);
            _isEnable = false;
        }
    }



}

