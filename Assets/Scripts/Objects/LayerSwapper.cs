using UnityEngine;

public class LayerSwapper : MonoBehaviour
{
    private string _newLayer;
    private string _previousLeyer;

    private void Start()
    {
        _newLayer = GetComponent<Renderer>().sortingLayerName;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SpriteRenderer renderer;
        other.TryGetComponent<SpriteRenderer>(out renderer);
        if (renderer != null)
        {
            _previousLeyer = renderer.sortingLayerName;
            renderer.sortingLayerName = _newLayer;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        SpriteRenderer renderer;
        other.TryGetComponent<SpriteRenderer>(out renderer);
        if (renderer != null)
        {
            renderer.sortingLayerName = _previousLeyer;
        }
        
    }
}
