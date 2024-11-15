using System;

namespace DelegateDemo
{
    // 定義委派，負責安排裝修工作，輸入描述工作的字串且無回傳值
    public delegate void RenovationDelegate(string taskDescription);

    // 定義工人的工作
    public class RenovationTasks
    {
        /// <summary>
        /// 油漆工
        /// </summary>
        /// <param name="taskDescription"></param>
        public static void PaintWalls(string taskDescription)
        {
            Console.WriteLine("油漆工執行: " + taskDescription);
        }

        /// <summary>
        /// 木工
        /// </summary>
        /// <param name="taskDescription"></param>
        public static void BuildFurniture(string taskDescription)
        {
            Console.WriteLine("木工執行: " + taskDescription);
        }

        /// <summary>
        /// 水電工
        /// </summary>
        /// <param name="taskDescription"></param>
        public static void InstallElectricalWiring(string taskDescription)
        {
            Console.WriteLine("水電工執行: " + taskDescription);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // 建立委派，並指派不同的工作
            RenovationDelegate delegateTask;

            // 將油漆工作委派給油漆工
            delegateTask = new RenovationDelegate(RenovationTasks.PaintWalls);
            delegateTask("牆面粉刷，顏色：白色");

            // 將家具製作工作委派給木工
            delegateTask = new RenovationDelegate(RenovationTasks.BuildFurniture);
            delegateTask("訂製客廳沙發和茶几");

            // 將電線安裝工作委派給水電工
            delegateTask = new RenovationDelegate(RenovationTasks.InstallElectricalWiring);
            delegateTask("安裝廚房和浴室的電線");
        }
    }
}
