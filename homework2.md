       
## 空间与运动
1、简答并用程序验证

* 游戏对象运动的本质

 游戏对象运动的本质，其实是游戏对象跟随每一帧的变化，空间地变化。这里的空间变化包括了游戏对象的transform
 属性中的position跟rotation两个属性。一个是绝对或者相对位置的改变，一个是所处位置的角度的旋转变化。

* 请用三种方法以上方法，实现物体的抛物线运动。（如，修改Transform属性，使用向量Vector3的方法…）
 *  第一种方法是利用position的改变来实现抛物线运动，水平方向的移动是匀速进行，竖直方向是有一定的加速度变
 化的，按照物理的规律来看，两个方向的运动矢量相加即可实现抛物线运动，代码如下：

    ```
    using System.Collections;  
    using System.Collections.Generic;  
    using UnityEngine;  
  
    public class move1 : MonoBehaviour {  
  
        public float speed = 1;  
        // Use this for initialization  
        void Start () {  
           Debug.Log("start!");  
       }  
      
        // Update is called once per frame  
        void Update () {  
      
            this.transform.position += Vector3.down * Time.deltaTime * (speed/10);  
            this.transform.position += Vector3.right * Time.deltaTime * 5;  
            speed++;  
        }  
    }  
    ```
 *  第二种方法是直接声明创建一个Vector3变量，同时定义该变量的值，也是竖直方向上是一个均匀增加的数值，水平
 方向是一个保持不变的数值，然后将游戏对象原本的position属性与该向量相加即可实现抛物线运动，代码如下：

    ```
    using System.Collections;  
    using System.Collections.Generic;  
    using UnityEngine;  
  
    public class move2 : MonoBehaviour {  
  
        public float speed = 1;  
        // Use this for initialization  
        void Start () {  
            Debug.Log("start!");  
        }  
      
        // Update is called once per frame  
        void Update () {  
  
            Vector3 change = new Vector3( Time.deltaTime*5, -Time.deltaTime*(speed/10), 0);  
            this.transform.position += change;  
            speed++;  
        }  
    }
    ```  
 *  第三种方法其实与第二种方法类似，区别在于第二种方法直接是利用Vector3的矢量相加，而第三种方法则是利用
 transform中的translate函数来进行改变position，传入参数也需要是一个Vector3向量，才可以实现position的改变，
 代码如下：

    ```
    using System.Collections;  
    using System.Collections.Generic;  
    using UnityEngine;  
  
    public class move3 : MonoBehaviour {  
  
        public float speed = 1;  
        // Use this for initialization  
        void Start () {  
            Debug.Log("start!");  
        }  
      
        // Update is called once per frame  
        void Update () {  
  
            Vector3 change = new Vector3(Time.deltaTime * 5, -Time.deltaTime * (speed/10), 0);  
  
            transform.Translate(change);  
            speed++;  
        }  
    }
    ```
 * 写一个程序，实现一个完整的太阳系， 其他星球围绕太阳的转速必须不一样，且不在一个法平面上。
 *  首先是游戏对象的安排，如下图所示：
 ![image](https://raw.githubusercontent.com/wangyp33/homework-photo/master/1.PNG)
 *  其次按照一定的大小以及距离，将八大行星的位置大小依次安排，修改它们的transform属性即可，同时将图片素材直接拉到该对象上面即可添加对象
 ![image](https://raw.githubusercontent.com/wangyp33/homework-photo/master/2.PNG)
 *  将八大行星的运动写进同个脚本里面，挂在Sun对象上即可。首先利用GameObject.Find函数找到该游戏对象，再通过其transform函数中的RotationAround跟Rotation函数分别来实现公转跟自转。

 *  RotationAround需要三个参数，第一个参数是旋转的中心，这个八大行星都是以太阳中心为旋转中心；第二个参数是旋转轴，也就是一个Vector3变量，通过改变旋转轴的属性。

 *  Rotation函数则可以只需要一个参数，即旋转时的方向及速度，用Vector3.up代表该物体是沿着自己的Y轴进行旋转的，后面的参数则是代表旋转的角速度，因此即可实现自转。

 *  挂在sun上的行为代码如下：
    ```
    using System.Collections;  
    using System.Collections.Generic;  
    using UnityEngine;  
  
    public class Sun : MonoBehaviour {  
  
        // Use this for initialization  
        void Start () {  
              
        }  
      
        // Update is called once per frame  
        void Update () {  
            GameObject.Find("Earth").transform.RotateAround(Vector3.zero, new Vector3(0, 1, 0), 30 * Time.deltaTime);  
            GameObject.Find("Earth").transform.Rotate(Vector3.up * Time.deltaTime * 10000);  
            GameObject.Find("Mercury").transform.RotateAround(Vector3.zero, new Vector3(1, 1, 0), 25 * Time.deltaTime);  
            GameObject.Find("Mercury").transform.Rotate(Vector3.up * Time.deltaTime * 10000);  
            GameObject.Find("Venus").transform.RotateAround(Vector3.zero, new Vector3(0, 1, 1), 20 * Time.deltaTime);  
            GameObject.Find("Venus").transform.Rotate(Vector3.up * Time.deltaTime * 10000);  
            GameObject.Find("Mars").transform.RotateAround(Vector3.zero, new Vector3(2, 1, 0), 45 * Time.deltaTime);  
            GameObject.Find("Mars").transform.Rotate(Vector3.up * Time.deltaTime * 10000);  
            GameObject.Find("Jupiter").transform.RotateAround(Vector3.zero, new Vector3(1, 2, 0), 35 * Time.deltaTime);  
            GameObject.Find("Jupiter").transform.Rotate(Vector3.up * Time.deltaTime * 10000);  
            GameObject.Find("Saturn").transform.RotateAround(Vector3.zero, new Vector3(0, 1, 2), 40 * Time.deltaTime);  
            GameObject.Find("Saturn").transform.Rotate(Vector3.up * Time.deltaTime * 10000);  
            GameObject.Find("Uranus").transform.RotateAround(Vector3.zero, new Vector3(0, 2, 1), 45 * Time.deltaTime);  
            GameObject.Find("Uranus").transform.Rotate(Vector3.up * Time.deltaTime * 10000);  
            GameObject.Find("Neptune").transform.RotateAround(Vector3.zero, new Vector3(1, 1, 1), 50 * Time.deltaTime);  
            GameObject.Find("Neptune").transform.Rotate(Vector3.up * Time.deltaTime * 10000);  
        }  
    }  
    ```
 *  旋转运动过程中的效果图如下：
 ![image](https://raw.githubusercontent.com/wangyp33/homework-photo/master/3.PNG)
 * 月球围绕地球旋转的实现
 *  假如地球没有设置成自转的话，可以将月球设置成地球的子对象，再通过RotationAround中的旋转点改成地球的位置，即可实现月球围绕着地球转.
 *  但是一般来说地球是会自转的，这势必带来地球自转会影响到月球围绕着地球转的问题，那如何解决这个问题呢？
 * 首先我们另行建立一个空对象，将该空对象的位置设置成地球的位置，同时旋转的条件也跟地球一样，就可以建立一个不显示不自转的地球的影子，再将月球设置成该空对象的子对象，即可实现月球围绕着地球转的操作了，具体的代码实现如下：
 *  空对象代码：
 ```
    using System.Collections;  
    using System.Collections.Generic;  
    using UnityEngine;  
  
    public class InitBeh : MonoBehaviour {  
  
        // Use this for initialization  
        void Start () {  
              
        }  
      
        // Update is called once per frame  
        void Update () {  
  
            this.transform.RotateAround(Vector3.zero, new Vector3(0, 1, 0), 30 * Time.deltaTime);  
        }  
    }  
 ```
 *  挂在月球的脚本代码如下：
 ```
    using System.Collections;  
    using System.Collections.Generic;  
    using UnityEngine;  
  
    public class moon : MonoBehaviour {  
  
        // Use this for initialization  
        void Start () {  
          
        }  
      
        // Update is called once per frame  
        void Update () {  
              
            Vector3 position = this.transform.parent.position;  
            this.transform.RotateAround(position, Vector3.up, 360 * Time.deltaTime);   
        }  
    }  
 ```
2、编程实践
 * 阅读以下游戏脚本
 <br/>Priests and Devils
 <br/>Priests and Devils is a puzzle game in which you will help the Priests and Devils to cross the 
 river within the time limit. There are 3 priests and 3 devils at one side of the river. They all want 
 to get to the other side of this river, but there is only one boat and this boat can only carry two 
 persons each time. And there must be one person steering the boat from one side to the other side. 
 In the flash game, you can click on them to move them and click the go button to move the boat to the 
 other direction. If the priests are out numbered by the devils on either side of the river, they get
 killed and the game is over. You can try it in many > ways. Keep all priests alive! Good luck!

 程序需要满足的要求：
 * play the game ( http://www.flash-game.net/game/2535/priests-and-devils.html )
 
 * 列出游戏中提及的事物（Objects）
 
    游戏中的对象有：牧师、魔鬼、小船、开始岸、结束岸

 * 用表格列出玩家动作表（规则表），注意，动作越少越好
<table>
  <tr>
    <th width=40%, bgcolor=yellow>事件</th>
    <th width="50%", bgcolor=yellow>条件</th>
  </tr>
  <tr>
    <td> 开船  </td>
    <td> 船在开始岸，船在结束岸，船上至少有一个人）  </td>
  </tr>
  <tr>
    <td> 船的左方下船 </td>
    <td> 船靠岸且船左方有人 </td>
  <tr>
    <td> 船的右方下船 </td>
    <td>  船靠岸且船右方有人 </td>
  </tr>
  <tr>
    <td> 开始岸的牧师上船 </td>
    <td>  船在开始岸，船有空位，开始岸有牧师 </td>
  </tr>
  <tr>
    <td> 开始岸的魔鬼上船 </td>
    <td>  船在开始岸，船有空位，开始岸有魔鬼 </td>
  </tr>
  <tr>
    <td> 结束岸的牧师上船 </td>
    <td>  船在结束岸，船有空位，结束岸有牧师 </td>
  </tr>
  <tr>
    <td> 结束岸的魔鬼上船 </td>
    <td>  船在结束岸，船有空位，结束岸有魔鬼 </td>
  </tr>
</table>
 * 请将游戏中对象做成预制
 * 在 GenGameObjects 中创建 长方形、正方形、球 及其色彩代表游戏中的对象。
 * 使用 C# 集合类型 有效组织对象
 * 整个游戏仅 主摄像机 和 一个 Empty 对象， 其他对象必须代码动态生成！！！ 。 整个游戏不许出现 Find 游戏
  对象， SendMessage 这类突破程序结构的 通讯耦合 语句。 违背本条准则，不给分
 * 请使用课件架构图编程，不接受非 MVC 结构程序
 * 注意细节，例如：船未靠岸，牧师与魔鬼上下船运动中，均不能接受用户事件！
 
   ### 构思
 * 题目中要求必须采用标准的mvc结构，同时在初始的场景当中，只能有摄像机跟空对象两个对象，其他的必须时预制
 * 首先是完成相关的预制，一共是四个，分别是代表魔鬼的球体，代表牧师的正方体，代表小船的小型褐色长方体，代表河岸的绿色大型长方体。这四个预制统一放在Resources中的Prefabs文件夹中
 * 之后根据mvc结构，分别创建三个脚本Model，VIew，Controller。View脚本挂在空对象下，其余两个脚本都挂在摄像头下
 
 游戏演示视频：（https://github.com/wangyp33/homework-photo/blob/master/%E7%89%A7%E5%B8%88%E4%B8%8E%E9%AD%94%E9%AC%BC.mp4）
 
