using UnityEngine;

public class backgroundScrolling : MonoBehaviour
{
    private Renderer myRenderer;
    private Material myMaterial;

    private float offset;
    [SerializeField] private float increase;
    [SerializeField] private float speed;
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        myMaterial = myRenderer.material;
    }

     private void FixedUpdate() {
      offset += increase;
      myMaterial.SetTextureOffset("_MainTex",new Vector2((offset*speed)/1000,0));  
    }
    
}
