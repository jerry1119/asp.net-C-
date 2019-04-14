using MVCLearn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLearn.Controllers
{
    public class TestController : Controller
    {
        // GET: Tets
        public ActionResult Index(IndexModel indexModel)
        {
            //Controller给view传值
            //1.model
            indexModel.Result = indexModel.Num1 + indexModel.Num2;

            //2. ViewData
            ViewData["myName"] = "jiegege";
            ViewData["myPwd"] = 123;
            //3. ViewBag  它是 dynamic类型的，dynamic类似js的变量
            //ViewBag是对ViewData的封装，他们共享同一个数据
            ViewBag.name2 = "sss";
            ViewBag.age = 233;
            //通常最好是用model，model可以用强类型(在cdhtml页面最上面指定这个model类)，好处是cshtml中有智能提示，如果没有指定的话，他就是dynamic类型的
            return View(indexModel);
        }

        public ActionResult Index2()
        {
            List<Person> list = new List<Person>() {
                new Person{ Name="张三",Age=18,ID=1},
                new Person{ Name="王五",Age=14,ID=2},
                new Person{ Name="李四",Age=15,ID=3}
            };
            return View(list);
        }
    }
}