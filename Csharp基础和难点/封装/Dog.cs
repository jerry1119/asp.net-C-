using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 封装练习
{
    
    
        //狗(结构)
        struct Dog
        {
            string _name;

            public string Name
            {
                get
                {
                    return _name;
                }

                set
                {
                    _name = value;
                }
            }

            public void Sing()
            {
                Console.WriteLine("汪汪");

            }

            //public Dog() { }

            public Dog(string name)
            {
                _name = name;
            }
        }
    }
/*
 * 结构 struct
 * 1.结构是值类型（类是引用类型）
 * 2、结构中可以定义字段、属性和方法
 * 3、不能为结构中的字段赋初始值
 * 4、结构的构造方法中必须为所有字段符值
 * 5、不能为结构显示定义无参数的构造方法
 * 6、结构类型的对象可以不实例化
 */
