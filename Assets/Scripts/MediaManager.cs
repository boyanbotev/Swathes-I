using UnityEngine;

public class MediaManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer render;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Texture2D[] textures;
    [SerializeField] AudioClip[] songs;
    private int imgIndex = 0;
    private int songIndex = 0;
    [SerializeField] float maxX = 100;
    [SerializeField] private float maxY = 100;
    [SerializeField] float speed;
    float colorChange = 0.001f;

    private void Start()
    {
        SetSprite();
        SetSong();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            IncrementImage();
        } 
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            DeincrementImage();
        } 
        else if (Input.GetKeyUp(KeyCode.DownArrow)) {
            IncrementSong();
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            DeincrementSong();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveImage(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            MoveImage(Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            MoveImage(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MoveImage(Vector2.left);
        }
        else if (Input.GetKey(KeyCode.Y))
        {
            IncreaseBackgroundColor();
        } 
        else if (Input.GetKey(KeyCode.H))
        {
            LowerBackgroundColor();
        }
    }

    void LowerBackgroundColor()
    {
        Color cameraColor = Camera.main.backgroundColor;
        var r = cameraColor.r;
        var g = cameraColor.g;
        var b = cameraColor.b;

        if (r == 0 || g == 0 || b == 0) return;
        r -= colorChange;
        g -= colorChange;
        b -= colorChange;
        cameraColor = new Color(r, g, b, cameraColor.a);
        Camera.main.backgroundColor = cameraColor;
    }

    void IncreaseBackgroundColor()
    {
        Color cameraColor = Camera.main.backgroundColor;
        var r = cameraColor.r;
        var g = cameraColor.g;
        var b = cameraColor.b;

        if (r == 1 || g == 1 || b == 1) return;
        r += colorChange;
        g += colorChange;
        b += colorChange;
        cameraColor = new Color(r, g, b, cameraColor.a);
        Camera.main.backgroundColor = cameraColor;
    }

    void MoveImage(Vector2 dir)
    {
        dir *= speed;
        var x = Mathf.Clamp(render.transform.position.x + dir.x, -maxX, maxX);
        var y = Mathf.Clamp(render.transform.position.y + dir.y, -maxY, maxY);
        
        Vector3 pos = new Vector3(x, y, 0);
        render.transform.position = pos;
    }

    void IncrementSong()
    {
        if (songIndex >= songs.Length - 1)
        {
            songIndex = 0;
        }
        else
        {
            songIndex++;
        }
        SetSong();
    }

    void DeincrementSong()
    {
        if (songIndex == 0)
        {
            songIndex = songs.Length - 1;
        }
        else
        {
            songIndex--;
        }
        SetSong();
    }

    void IncrementImage()
    {
        if (imgIndex >= textures.Length - 1)
        {
            imgIndex = 0;
        } else
        {
            imgIndex++;
        }
        SetSprite();
    }

    void DeincrementImage()
    {
        if (imgIndex == 0)
        {
            imgIndex = textures.Length - 1;
        } else
        {
            imgIndex--;
        }
        SetSprite();
    }

    private void SetSong()
    {
        audioSource.clip = songs[songIndex];
        audioSource.Play();
    }

    private void SetSprite()
    {
        var texture = textures[imgIndex];
        render.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }
}
