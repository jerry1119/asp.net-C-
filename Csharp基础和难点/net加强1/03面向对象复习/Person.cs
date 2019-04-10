using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03面向对象复习
{
    class Person
    {
        //字段、属性、函数、构造函数
        //字段：存储数据
        //属性：保护字段 get set
        //函数：描述对象的行为
        //构造函数：初始化对象，给对象的每个属性赋值

        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }  //取属性的值

            set
            {
                if (value != "张三")
                {
                    value = "张三";
                }
                _name = value;
            }   //给属性赋值
        }

        public int Age
        {
            get
            {
                if (_age < 0||_age > 100)
                {
                    return _age = 18;
                }
                return _age;
            }

            set
            {
                _age = value;
            }
        }

        int _age;

        public char Gender { get; set; }
        //自动属性 pro + 2次tab，自动属性不能像get，set那样直接在get，set块里面限制，
        //可通过构造函数来限制

        public Person(char gender)
        {
            if (gender != '男' && gender != '女')
            {
                gender = '男';
            }
            this.Gender = gender;
        }
    }
}
