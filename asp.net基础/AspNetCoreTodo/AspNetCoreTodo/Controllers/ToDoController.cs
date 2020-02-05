using System;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreTodo.Controllers
{
    [Authorize]
    public class ToDoController:Controller
    {
        private readonly ITodoItemService _todoItemService;
        private readonly UserManager<IdentityUser> _userManager;
        //依赖注入，将IToDoItemservice注入到了这个contrllor中
        public ToDoController(ITodoItemService todoItemService,UserManager<IdentityUser> userManager)
        {
            _todoItemService = todoItemService;
            _userManager = userManager; 
        }
        public async Task<IActionResult> Index()
        {
            var currentUser =await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();
            var items = await _todoItemService.GetIncompleteItemAsync(currentUser);
            var model = new ToDoViewModel()
            {
                Items = items
            };

            return View(model);
        }
        //在页面上加了 asp-之后就会自动生成一个隐藏域，传输到服务器后，加这个特性就会检查，来防止跨域攻击
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(ToDoItem newItem)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var successful = await _todoItemService.AddItemAsync(newItem);
            if (!successful)
            {
                return BadRequest("Could not add item");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id==Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var successful = await _todoItemService.MarkDoneAsync(id);
            if (!successful)
            {
                return BadRequest("Could not mark item as done");
            }

            return RedirectToAction("Index");
        }
    }
}