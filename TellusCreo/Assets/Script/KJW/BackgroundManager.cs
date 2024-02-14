using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField]
    List<Sprite> backGroundSpriteList;
    SpriteRenderer backGroundSpriteRenderer;
    int currentSpriteIndex = 0;
    [SerializeField]
    Sprite defaultSprite;

    [SerializeField] private bool star = false;
    [SerializeField] GameObject errorMessage;
    [SerializeField] GameObject clearMessage;

    [SerializeField] Sprite compareSpr;


    void Awake()
    {
        InitSpriteRenderer();
    }

    private void OnEnable()
    {
        if (errorMessage == null) return;

        bool active = false;
        if (star && backGroundSpriteRenderer.sprite == compareSpr)
        {
            if (!GameManager.Instance.Get_starLauncher())
                active = true;
        }

        ActiveError();
        ActvieClear();
    }

    void InitSpriteRenderer()
    {
        if (backGroundSpriteRenderer == null)
        {
            backGroundSpriteRenderer = GetComponent<SpriteRenderer>();
            if(backGroundSpriteRenderer == null)
            {
                backGroundSpriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();
            }
            defaultSprite = backGroundSpriteRenderer.sprite;
        }
    }

    public void ChangeBackgroundSprite()
    {
        InitSpriteRenderer();

        if (backGroundSpriteList.Count == 0)
        {
#if UNITY_EDITOR
            Debug.Log("backGroundSpriteList Empty");
#endif
            return;
        }

        currentSpriteIndex = (currentSpriteIndex + 1) % backGroundSpriteList.Count;
        backGroundSpriteRenderer.sprite = backGroundSpriteList[currentSpriteIndex];


        ActiveError();
        ActvieClear();
    }

    public void ChangeBackgroundSprite(Sprite sprite)
    {
        if (sprite == null)
        {
#if UNITY_EDITOR
            Debug.Log("Sprite is NULL");
#endif
        }

        InitSpriteRenderer();
        backGroundSpriteRenderer.sprite = sprite;
    }

    private void ActiveError()
    {
        if (errorMessage == null) return;

        bool active = false;
        if (star && backGroundSpriteRenderer.sprite == compareSpr)
        {
            if (!GameManager.Instance.Get_starLauncher())
                active = true;
        }

        errorMessage.SetActive(active);
    }

    public void ActvieClear()
    {
        if (clearMessage == null) return;
        if (!GameManager.Instance.ClearAttic) return;

        bool active = false;
        if (star && backGroundSpriteRenderer.sprite == compareSpr)
            active = true;

        errorMessage.SetActive(false);
        clearMessage.SetActive(active);
    }
}

