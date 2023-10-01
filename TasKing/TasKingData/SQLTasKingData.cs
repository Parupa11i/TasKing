using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TasKing.Models;
using TasKing.ViewModels;

namespace TasKing.TasKingData
{
    public class SQLTasKingData : ITasKingData
    {
        private readonly ApplicationDbContext _db;

        public SQLTasKingData(ApplicationDbContext db)
        {
            _db = db;
        }

        public VTodoItem AddTodoItem(VTodoItem vTodoItem)
        {
            var todoItem = new TodoItem();
            todoItem.Id = Guid.NewGuid();
            todoItem.Descr = vTodoItem.Descr;
            todoItem.Status = vTodoItem.Status.ToString();
            _db.TodoItems.Add(todoItem);
            _db.SaveChanges();
            return vTodoItem;
        }

        public TodoItem AddTodoItem(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        public void DeleteTodoItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public VTodoItem GetTodoItem(Guid id)
        {
            var todoItem = _db.TodoItems.SingleOrDefault(u => u.Id == id);
            return new VTodoItem { Id = todoItem.Id, Descr=todoItem.Descr, Status = (Status)Enum.Parse(typeof(Status),todoItem.Status) };
        }

        public List<TodoItem> GetTodoList()
        {
            return _db.TodoItems.ToList();
        }

        public VTodoItem UpdateTodoItem(VTodoItem vTodoItem)
        {
            try
            {
                var todoItem = new TodoItem();
                todoItem.Id = vTodoItem.Id;
                todoItem.Descr = vTodoItem.Descr;
                todoItem.Status = vTodoItem.Status.ToString();

                _db.TodoItems.Update(todoItem);
                _db.SaveChanges();
                return new VTodoItem { Id = todoItem.Id, Descr = todoItem.Descr, Status = (Status)Enum.Parse(typeof(Status), todoItem.Status) };
            }
            catch
            {
                throw new Exception("Cannot find the todo item");
            }
        }
    }
}
