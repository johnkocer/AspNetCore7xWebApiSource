// See https://aka.ms/new-console-template for more information
using SmartIT.DebugHelper.Core;
using SmartIT.MockDB;

TodoRepository _todoRepository = new TodoRepository();
var todoList = _todoRepository.GetAll();
todoList.ConsoleDump("_todoRepository.GetAll()");
var findById = _todoRepository.FindById(2);
findById.ConsoleDump("_todoRepository.FindById(2)");
var newTodo = _todoRepository.Add(new Todo { Name = "Call a friend" });
_todoRepository.GetAll().ConsoleDump("Check if Call a friend todo added?");
newTodo.Name = newTodo.Name + " Updated";
_todoRepository.Update(newTodo);
_todoRepository.GetAll().ConsoleDump("Check if Call a friend todo updated with Updated?");
_todoRepository.Delete(_todoRepository.FindById(1));
_todoRepository.GetAll().ConsoleDump("Check if Id=1 todo is Deleted?");

Console.ReadLine();
