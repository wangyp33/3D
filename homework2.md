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
