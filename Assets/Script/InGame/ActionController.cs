using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    /// <summary>
    /// 地板元素
    /// </summary>
    public GameObject floor;
    /// <summary>
    /// 转身速度
    /// </summary>
    public float turnspeed = 100;
    /// <summary>
    ///跳跃状态
    /// <summary>
    public bool isJump = false;
    public int JumpCount = 1;
    /// <summary>
    ///是否刚刚开始(指起点)
    /// <summary>
    public bool IsStart = true;
    /// <summary>
    /// 奔跑中？
    /// </summary>
    public bool runing = false;
    /// <summary>
    /// 游戏结束
    /// </summary>
    public bool GameOver;

    /// <summary>
    /// 游戏结束时的提示信息
    /// </summary>
    public GameObject GameOverMsg;

    public GameObject Begin;

    public GameObject ActionBGM;
    bool played;
    //刚体
    private Rigidbody Rig;
    //跳跃的距离和高度
    private int Rigy;
    //相关动作的动画
    private new Animation animation;
    //Buff
    private Player_Buff buff;

    // Start is called before the first frame update
    void Start()
    {
        played = false;
        GameOver = false;
        GameBaseSetting.SendScore = false;
        buff = GetComponent<Player_Buff>();
        Rig = GetComponent<Rigidbody>();
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameBaseSetting.Life == 0)
        {
            GameOver = true;
        }
        if (!GameOver)
        {
            if (Input.GetKey(KeyCode.D))//按下D开始奔跑
            {
                runing = true;
                IsStart = false;//起点False
                Begin.SetActive(false);
            }

            if (runing)//如果是开启了奔跑状态且不是跳跃
            {
                float Speed = buff.Speed;
                if (isJump)
                {
                    Speed = 2;
                }
                this.transform.Translate(Vector3.forward * Time.deltaTime * Speed);
            }
            if (runing && !isJump)
            {
                animation.Play(string.Format("Run {0}", this.gameObject.name));
            }
            if (!runing)
            {
                if (!isJump && !IsStart)//不是奔跑也不是跳跃且不在起点
                {
                    animation.Play(string.Format("Idle {0}", this.gameObject.name));
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))//按下空格跳跃
            {
                isJump = true;
            }
            if (isJump && JumpCount == 0)//如果还在跳跃中，则不重复执行 
            {
                PlayBGM(0);
                Rig.AddForce(new Vector3(0, buff.Jumpheigh, 0) * 1500);
                JumpCount = 1;
                animation.Play(string.Format("Jump Up {0}", this.gameObject.name));
            }
        }
        else
        {
            if (!played)
            {
                PlayBGM(2);
                played = true;
                GameObject.Find("Setting").SetActive(false);
            }

            GameOverMsg.SetActive(true);
            
            GameObject.Find("ScoreTxt").GetComponent<Text>().text = GameBaseSetting.Score.ToString();
            animation.Play(string.Format("Failure {0}", this.gameObject.name));
            GameObject.Find("BGM").GetComponent<AudioSource>().Stop();
            if (!GameBaseSetting.SendScore)
            {
                StartCoroutine(SendScore());
            }

        }
    }


    public IEnumerator SendScore()
    {
        if (!string.IsNullOrEmpty(GameBaseSetting.Id))
        {
            string url = string.Format("{0}/api/Score/AddScore?Id={1}&Score={2}&map={3}",GameBaseSetting.URL, GameBaseSetting.Id, GameBaseSetting.Score.ToString(),GameBaseSetting.Map);
            HttpServer hs = new HttpServer();
            GameBaseSetting.SendScore = true;
            yield return hs.SendGet(url);
        }

    }


    /// <summary>
    /// 接触到地面时
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == floor.tag)//判断碰撞是不是地面 
        {
            animation.Play(string.Format("Land {0}", this.gameObject.name));//落地的动作
            PlayBGM(1);
            isJump = false;
            JumpCount = 0;

        }
    }

    void PlayBGM(int i)
    {
        ActionBGM.GetComponent<AudioSource>().clip = ActionBGM.GetComponent<BGMList>().Audio[i];
        ActionBGM.GetComponent<AudioSource>().Play();
    }
}
