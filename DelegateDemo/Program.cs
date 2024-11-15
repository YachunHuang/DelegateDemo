using System;

namespace DelegateDemo
{
    // 定義委派，負責安排裝修工作
    public delegate void RenovationDelegate(string taskDescription);

    // 定義委派，Callback
    public delegate void TaskCompletedCallback(string result);

    /// <summary>
    ///  工人類別
    /// </summary>
    public static class RenovationTasks
    {
        public static void PaintWalls(string taskDescription)
        {
            Console.WriteLine("油漆工執行: " + taskDescription);
        }

        public static void BuildFurniture(string taskDescription)
        {
            Console.WriteLine("木工執行: " + taskDescription);
        }

        public static void InstallElectricalWiring(string taskDescription)
        {
            Console.WriteLine("水電工執行: " + taskDescription);
        }
    }

    /// <summary>
    ///  業主類別
    /// </summary>
    public class Owner
    {
        public void RequestRenovation(Contractor contractor)
        {
            Console.WriteLine("業主: 我要裝修牆壁。");
            contractor.ArrangeTask("粉刷牆壁，顏色：白色", TaskCompletedNotification);
        }

        public void TaskCompletedNotification(string result)
        {
            Console.WriteLine("業主: 收到通知 -> " + result);
        }
    }

    /// <summary>
    /// 承包商類別
    /// </summary>
    public class Contractor
    {
        public void ArrangeTask(string taskDescription, TaskCompletedCallback callback)
        {
            Console.WriteLine("承包商: 接收到業主需求，安排工人執行。");
            Worker worker = new Worker();
            worker.DoWork(taskDescription, callback);
        }
    }

    /// <summary>
    /// 工人類別
    /// </summary>
    public class Worker
    {
        public void DoWork(string taskDescription, TaskCompletedCallback callback)
        {
            Console.WriteLine("工人: 執行工作 -> " + taskDescription);
            string result = $"完成 {taskDescription}";
            callback(result);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== 基本委派 ===");
            BasicDelegateExample();

            Console.WriteLine("\n=== Callback 機制 ===");
            CallbackDelegateExample();

            Console.ReadLine();
        }

        /// <summary>
        /// 基本委派：將不同的裝修任務委派給對應工人
        /// </summary>
        public static void BasicDelegateExample()
        {
            RenovationDelegate delegateTask;

            delegateTask = RenovationTasks.PaintWalls;
            delegateTask("牆面粉刷，顏色：白色");

            delegateTask = RenovationTasks.BuildFurniture;
            delegateTask("訂製客廳沙發和茶几");

            delegateTask = RenovationTasks.InstallElectricalWiring;
            delegateTask("安裝廚房和浴室的電線");
        }

        /// <summary>
        /// Callback 機制：業主透過承包商委派裝修任務，並接收完成通知
        /// </summary>
        public static void CallbackDelegateExample()
        {
            Owner owner = new Owner();
            Contractor contractor = new Contractor();
            owner.RequestRenovation(contractor);
        }
    }
}
