using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class L_GameManager : MonoBehaviour
{
    public static L_GameManager instance;

    public bool isDown;
    public bool isUp;
    public RaycastHit2D downHit;
    public RaycastHit2D upHit;

    [SerializeField] private bool laptopLocked;
    [SerializeField] private bool ojakgyoClear;
    [SerializeField] private SpriteRenderer bookBackgroundRenderer;
    [SerializeField] private Sprite bookClearBackground;
    [SerializeField] private GameObject backgroundBooks;

    [SerializeField] private SpriteRenderer weatherRenderer;
    [SerializeField] private Sprite[] weatherSprs;

    private bool isGetFinalItem;
    private bool bookClear;
    private bool symmetryClear;
    [SerializeField] private GameObject wrongObjs;
    [SerializeField] private GameObject rightObjs;

    private bool symRightLock;
    private bool rainy;

    private bool plantDrawerLocked;

    [SerializeField] private P_PuzzleInfo laptopObj;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        isDown = false;
        isUp = false;

        laptopLocked = true;
        ojakgyoClear = false;

        isGetFinalItem = false;
        bookClear = false;
        symmetryClear = false;

        symRightLock = true;
        rainy = false;

        plantDrawerLocked = true;

        SoundManager.Instance.Play("library_bgm", Sound.Bgm);
    }

    void Update()
    {
        ShootRay();
    }

    private void ShootRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Vector2 downPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Ray2D downRay = new Ray2D(downPos, Vector2.zero);
                downHit = Physics2D.Raycast(downRay.origin, downRay.direction, 1 << 30);

                if (downHit.collider != null)
                    isDown = true;
            }
        }
        else
            isDown = false;

        if (Input.GetMouseButtonUp(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Vector2 upPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Ray2D upRay = new Ray2D(upPos, Vector2.zero);
                upHit = Physics2D.Raycast(upRay.origin, upRay.direction);

                if (upHit.collider != null)
                    isUp = true;
            }
        }
        else
            isUp = false;
    }

    public void Set_isGetFinalItem()
    {
        isGetFinalItem = true;
        Debug.Log("Get 'Water'");
    }

    public bool Get_isGetFinalItem() { return isGetFinalItem; }

    public void Set_bookClear()
    {
        bookClear = true;

        bookBackgroundRenderer.sprite = bookClearBackground;
        backgroundBooks.SetActive(false);

        Debug.Log("Book Puzzle Clear");
    }

    public bool Get_bookClear() { return bookClear; }

    public void Set_symmetryClear()
    {
        symmetryClear = true;

        wrongObjs.SetActive(false);
        rightObjs.SetActive(true);

        Debug.Log("Symmetry Puzzle Clear");
    }

    public bool Get_symmetryClear() { return symmetryClear; }


    public bool IsLaptopLocked() { return laptopLocked; }
    public void Set_laptopLocked(bool value = false) 
    {
        laptopLocked = value;
        Debug.Log("Laptop Locked " + laptopLocked.ToString());

        laptopObj.IsClear_true();
    }

    public bool isOjakgyoClear() { return ojakgyoClear; }
    public void Set_ojakgyoClear(bool value = true) 
    {
        ojakgyoClear = value;
        Debug.Log("Ojakgyo Clear " + laptopLocked.ToString());
    }


    public bool isSymRightLock() { return symRightLock; }
    public void Set_symRightLock(bool value = false)
    {
        symRightLock = value;
        Debug.Log("Symmetry Right Lock " + symRightLock.ToString());
    }


    public bool isRainy() { return rainy; }
    public void Set_rainy(bool value = true)
    {
        rainy = value;

        if (rainy)
            weatherRenderer.sprite = weatherSprs[1];
        else
            weatherRenderer.sprite = weatherSprs[0];

        Debug.Log("Rainy " + rainy.ToString());
    }


    public bool isPlantDrawerLocked() { return plantDrawerLocked; }
    public void Set_plantDrawerLocked(bool value = false)
    {
        plantDrawerLocked = value;
        Debug.Log("Plant Drawer Locked " + rainy.ToString());
    }
}
