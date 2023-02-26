using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSprites : MonoBehaviour
{
    [SerializeField] private GameObject mapSprite;
    private int level = 4;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x > 0 && transform.position.z > 0)
            level = 0;
        else if (transform.position.x > 0 && transform.position.z < 0)
            level = 1;
        else if (transform.position.x < 0 && transform.position.z < 0)
            level = 2;
        else if (transform.position.x < 0 && transform.position.z > 0)
            level = 3;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        mapSprite.SetActive(GameManager.Instance.level == this.level);
    }
}
