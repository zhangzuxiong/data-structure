using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    class Program
    {
        //有5个人去打Boss，Boss死亡了，5个人其中3个去捡装备
        static void Main(string[] args)
        {
            Boss boss = new Boss("光头强");

            Hero[] team = new Hero[5];
            team[0] = new Hero("羊驼", boss);
            team[1] = new Hero("平头哥");
            team[2] = new Hero("面筋哥", boss);
            team[3] = new Hero("响尾蛇");
            team[4] = new Hero("周", boss);

            boss.Die();
            //boss.die();

            //team[0].PickEquipment();
            //team[2].PickEquipment();
            //team[4].PickEquipment();
        }
    }

    class Role
    {
        protected string name;
    }

    class Hero : Role
    {
        public Hero(string name)
        {
            this.name = name;
        }

        public Hero(string name, Boss boss)
        {
            this.name = name;
            boss.die += PickEquipment;
        }

        public void PickEquipment()
        {
            Console.WriteLine(name + "捡起了装备");
        }
    }

    class Boss : Role
    {
        //1委托在外部赋值时可以使用+=、-=、=，但是事件在外部赋值时只能使用+=、-=
        //事件和委托都是引用类型，事件是一种特殊的委托
        //接口中可以包含事件但是不能包含委托
        public event Action die;//事件可以在外部赋值但是不能在外部调用

        public Boss(string name)
        {
            this.name = name;
        }

        public void Die()
        {
            Console.WriteLine(name + "死亡了");
            die();
        }
    }
}

