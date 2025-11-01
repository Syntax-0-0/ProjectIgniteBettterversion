using UnityEngine;

public class fruitinteraction : MonoBehaviour
{
    public GameObject full;
    public GameObject cut;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CutMeIAmAFruit()
    {
        full.gameObject.SetActive(false);
        cut.gameObject.SetActive(true);
    }
}
