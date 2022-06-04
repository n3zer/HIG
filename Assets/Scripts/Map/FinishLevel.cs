using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private Text _winText;
    [SerializeField] private int _loadSceneId = 0;

    private void Update()
    {
        if (transform.childCount == 0)
        {
            _winText.enabled = true;
            StartCoroutine(LoadLobby());
        }
    }

    private IEnumerator LoadLobby()
    {
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(_loadSceneId);
    }
}
