using UnityEngine;

public class LayerSwapper : MonoBehaviour
{
    private string _newLayer;
    private string _previousLeyer;

    private void Start()
    {
        _newLayer = GetComponent<SpriteRenderer>().sortingLayerName;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _previousLeyer = other.GetComponent<SpriteRenderer>().sortingLayerName;
        other.GetComponent<SpriteRenderer>().sortingLayerName = _newLayer;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<SpriteRenderer>().sortingLayerName = _previousLeyer;
    }
}
