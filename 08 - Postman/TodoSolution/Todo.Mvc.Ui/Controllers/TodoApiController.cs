﻿//Copyright 2020 (c) SmartIT. All rights reserved.
//By John Kocer
// This file is for Swagger test, this application does not use this file
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartIT.MockDB;

namespace TodoAngular.Ui.Controllers
{
  [Produces("application/json")]
  [Route("api/Todo")]
  public class TodoApiController : ControllerBase
  {
    TodoRepository _todoRepository = new TodoRepository();

    [Route("~/api/GetAllTodos")]
    [HttpGet]
    public IEnumerable<SmartIT.MockDB.Todo> GetAllTodos()
    {
      return _todoRepository.GetAll();
    }

    [Route("~/api/AddTodo")]
    [HttpPost]
    public SmartIT.MockDB.Todo AddTodo([FromBody]SmartIT.MockDB.Todo item)
    {
      return _todoRepository.Add(item);
    }

    [Route("~/api/UpdateTodo")]
    [HttpPut]
    public SmartIT.MockDB.Todo UpdateTodo([FromBody]SmartIT.MockDB.Todo item)
    {
      return _todoRepository.Update(item);
    }

    [Route("~/api/DeleteTodo/{id}")]
    [HttpDelete]
    public void Delete(int id)
    {
      var findTodo = _todoRepository.FindById(id);
      if (findTodo != null)
        _todoRepository.Delete(findTodo);
    }
  }
}
