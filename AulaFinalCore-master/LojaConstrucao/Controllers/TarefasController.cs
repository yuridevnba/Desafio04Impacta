using Microsoft.AspNetCore.Mvc;
using LojaConstrucao.Models;
using System.Reflection.Metadata.Ecma335;

namespace LojaConstrucao.Controllers;

public class TarefasController : Controller
{
    private static List<Tarefas> _tarefas = new List<Tarefas>()
    {
        new Tarefas { TarefasId= 1, NomeTarefa="Nome" ,descricao="descricao"},
       
   };


    public IActionResult Index()
    {
        var tarefasConcluidas = _tarefas.Where(tarefa => tarefa.Status == "Por Fazer!").ToList();
        return View(tarefasConcluidas);
    }

    public IActionResult Concluidas()
    {
        var tarefasConcluidas = _tarefas.Where(tarefa => tarefa.Status == "concluído").ToList();
        return View(tarefasConcluidas);
    }

    [HttpGet] //anotação de PEGAR
    public IActionResult Create() {  //chama o form de cadastro
       return View();
    }

    


    [HttpPost] //Anotação de ENVIAR
    public IActionResult Create(Tarefas tarefa)
    { //recebe os dados do form    

        if (ModelState.IsValid)
        {
            tarefa.TarefasId = _tarefas.Count > 0 ? _tarefas.Max(c => c.TarefasId) + 1 : 1;



            _tarefas.Add(tarefa);


        }
        return RedirectToAction("Create");
    }



    public IActionResult Delete(int id) {
        var tarefa = _tarefas.FirstOrDefault(c => c.TarefasId == id);
        if (tarefa == null)
        {
            return NotFound();
        }

        _tarefas.Remove(tarefa);
        return RedirectToAction("Index");
    }


    public IActionResult Mudança(int id)
    {
        var tarefa = _tarefas.FirstOrDefault(c => c.TarefasId == id);
        if (tarefa == null)
        {
            return NotFound();
        }

        // Modifica o status da tarefa para "concluído"
        tarefa.Status = "concluído";
        tarefa.dataConclusão = DateTime.Now;


        return RedirectToAction("Index");
    }













    [HttpGet]
    public IActionResult Edit(int id) {
        var tarefa = _tarefas.FirstOrDefault(c => c.TarefasId == id);
        if (tarefa == null)
        {
            return NotFound();
        }

        return View(tarefa);
    }


    

    [HttpPost]
    public IActionResult Edit(Tarefas tarefa)
    {
        if (ModelState.IsValid)
        {
            var existingTarefa = _tarefas.FirstOrDefault(c => c.TarefasId == tarefa.TarefasId);
            if (existingTarefa != null)
            {
                existingTarefa.NomeTarefa = tarefa.NomeTarefa;
                existingTarefa.descricao = tarefa.descricao;
            }
            return RedirectToAction("Index");
        }
        return View(tarefa);
    }

    public IActionResult Detalhes(int id)
    {

        var tarefas = _tarefas.FirstOrDefault(c => c.TarefasId== id);
        if (tarefas == null)
            return NotFound();

        return View(tarefas);
    }



}


