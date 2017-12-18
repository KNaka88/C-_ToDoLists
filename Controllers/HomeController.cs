using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
  public class HomeController : Controller
  {
      [Route("/")]
      public ActionResult Index()
      {
          return View();
      }

      [HttpGet("/tasks")]
      public ActionResult Tasks()
      {
          List<Task> allTasks = Task.GetAll();
          return View(allTasks);
      }

      [HttpGet("/tasks/new")]
      public ActionResult TaskForm()
      {
          return View();
      }

      [HttpGet("/tasks/{id}")]
      public ActionResult TaskDetail(int id)
      {
          Task task = Task.Find(id);
          return View(task);
      }

      [HttpPost("/tasks")]
      public ActionResult AddTask()
      {
          Task newTask = new Task(Request.Form["new-task"]);
          List<Task> allTasks = Task.GetAll();
          return View("Tasks", allTasks);
      }

      [Route("/task/list")]
      public ActionResult TaskList()
      {
          List<Task> allTasks = Task.GetAll();
          return View(allTasks);
      }

      // [HttpPost("/task/create")]
      // public ActionResult CreateTask()
      // {
      //     Task newTask = new Task(Request.Form["new-task"]);
      //     newTask.Save();
      //     return View(newTask);
      // }

      [HttpPost("/task/list/clear")]
      public ActionResult TaskListClear()
      {
          Task.ClearAll();
          return View();
      }

  }
}
