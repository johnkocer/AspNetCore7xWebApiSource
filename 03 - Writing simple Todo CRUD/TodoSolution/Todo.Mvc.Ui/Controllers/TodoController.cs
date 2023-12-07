using Microsoft.AspNetCore.Mvc;
using SmartIT.MockDB;

namespace Todo.Mvc.Ui.Controllers
{
    public class TodoController : Controller
    {
        TodoRepository _todoRepository = new TodoRepository();

        // GET: TodoController
        public ActionResult Index()
        {
            var todos = (List<SmartIT.MockDB.Todo>)_todoRepository.GetAll();
            return View(todos);
        }

        // GET: TodoController/Details/5
        public ActionResult Details(int id)
        {
            var findTodo = _todoRepository.FindById(id);
            return View(findTodo);
        }

        // GET: TodoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TodoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {

                _todoRepository.Add(new SmartIT.MockDB.Todo() { Name = collection["Name"] });
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: TodoController/Edit/5
        public ActionResult Edit(int id)
        {
            var findTodo = _todoRepository.FindById(id);
            return View(findTodo);
        }

        // POST: TodoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var findTodo = _todoRepository.FindById(id);
                findTodo.Name = collection["Name"];

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TodoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_todoRepository.FindById(id));
        }

        // POST: TodoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var findTodo = _todoRepository.FindById(id);
                _todoRepository.Delete(findTodo);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
