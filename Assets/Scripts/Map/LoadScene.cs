using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private int _loadSceneId = 0;
    [SerializeField] private float _cooldown = 1.2f;

    private bool _isReady;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isReady = true;
            StartCoroutine(WaitLoad());
        }
    }
    private IEnumerator WaitLoad()
    {
        yield return new WaitForSeconds(_cooldown);
        if (_isReady)
        {
            SceneManager.LoadScene(_loadSceneId);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isReady = false;
        }
    }
}
