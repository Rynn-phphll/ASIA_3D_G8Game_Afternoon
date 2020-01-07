using UnityEngine;  // 引用 Unity API

// 類別 類別名稱
public class Chicken : MonoBehaviour
{
    #region 欄位區域
    // 宣告變數 (定義欄位 Field)
    // 修飾詞 欄位類型 欄位名稱 (指定 值) 結束
    // 私人 - 隱藏 private (預設)
    // 公開 - 顯示 public 
    [Header("移動速度")] [Range(1, 2000)]
    public int speed = 10;             // 整數 1, 9999, -100
    [Header("旋轉速度"), Tooltip("G8雞的旋轉速度"), Range(1.5f, 200f)]
    public float turn = 20.5f;         // 浮點數
    [Header("是否完成任務")]
    public bool mission;               // 布林值 true false
    [Header("玩家名稱")]
    public string _name = "G8雞";      // 字串 ""
    public Transform tran;
    public Rigidbody rig;
    public Animator ani;
    public AudioSource aud;

    public AudioClip soundBark;

    #endregion

    [Header("檢物品位置")]
    public Rigidbody rigCatch;

    private void Update()
    {
        Turn();
        Run();
        Bark();
        Catch();
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.name == "Santa" && ani.GetCurrentAnimatorStateInfo(0).IsName("撿東西"))
        {

            Physics.IgnoreCollision(other, GetComponent<Collider>());
            other.GetComponent<HingeJoint>().connectedBody = rigCatch;
        }


    }

    #region 方法區域
    /// <summary>
    /// 跑步
    /// </summary>
    private void Run()
    {
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("撿東西"))return;
        
        float v = Input.GetAxis("Vertical");

        //rig,AddForce(0, 0, speed * v);                //世界座標
        //tran.forward 區域座標 z 軸
        //tran.right   區域座標 x 軸
        //tran.up      區域座標 y 軸

        rig.AddForce(tran.forward * speed * v * Time.deltaTime);       //區域座標
        ani.SetBool("走路開關", v != 0);
        
    }

    /// <summary>
    /// 旋轉
    /// </summary>
    private void Turn()
    {
        float h = Input.GetAxis("Horizontal");
        tran.Rotate(0, turn * h * Time.deltaTime, 0);
    }

    /// <summary>
    /// 亂叫
    /// </summary>
    private void Bark()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //按下空白鍵拍翅膀
            ani.SetTrigger("拍翅膀觸發器");

            aud.PlayOneShot(soundBark, 0.6f);
        }
    }

    /// <summary>
    /// 撿東西
    /// </summary>
    private void Catch()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //滑鼠左鍵撿東西
            ani.SetTrigger("撿東西觸發器");
        }
     }
        /// <summary>
        /// 檢視任務
        /// </summary>
   private void Task()
        {

        }
        #endregion
     
}