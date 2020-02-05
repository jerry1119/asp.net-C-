using System;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreTodo.Services
{
    public interface ITodoItemService
    {
         Task<ToDoItem[]> GetIncompleteItemAsync(IdentityUser user);

         Task<bool> AddItemAsync(ToDoItem newItem);

         Task<bool> MarkDoneAsync(Guid id);
    }
}