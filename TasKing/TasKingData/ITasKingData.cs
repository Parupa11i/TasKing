using System;
using System.Collections.Generic;
using TasKing.Models;
using TasKing.ViewModels;

namespace TasKing.TasKingData
{
    public interface ITasKingData
    {
        //Get
        List<TodoItem> GetTodoList();

        //Post
        VTodoItem AddTodoItem(VTodoItem vTodoItem);

        //Get
        VTodoItem GetTodoItem(Guid id);

        //Delete
        void DeleteTodoItem(Guid id);

        //Put
        VTodoItem UpdateTodoItem(VTodoItem vTodoItem);
    }
}
