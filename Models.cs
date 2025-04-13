using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text;
using System.Linq;

public class ToDo
{
    
    public string Tarefa { get; set; }
    public bool Status = false;
    public int Id { get; set; }

    static string path = "ToDos/ToDos.json";

    // metodo p salvar ToDo no json
    public static void Save_ToDo(List<ToDo> ToDos)
    {
        string json = JsonSerializer.Serialize(ToDos);
        File.WriteAllText(path, json);
    }

    // metodo p carregar o arquivo com as tasks ou cria-lo
    public static List<ToDo> Load_ToDos()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<ToDo>>(json);
        }
        return new List<ToDo>(); 
    }

    //metodo para listar as tarefas no console casoo queira editar ou deletar
    public static void List_ToDos(List<ToDo> toDos){
         foreach (var todo in toDos)
    {
        Console.WriteLine($"- Você programou para fazer hoje: {todo.Id} --- {todo.Tarefa}:");
    }
    }

    // metodo para dar update em alguma tarefa

    public static void Update_ToDo(List<ToDo> ToDos, int  ids, string new_task){
        var tarefa = ToDos.FirstOrDefault(t => t.Id == ids);

        if(tarefa != null){
            tarefa.Tarefa = new_task;
            Save_ToDo(ToDos);
            Console.WriteLine("Tarefa alterada com sucesso!");
        }
        else{
            Console.WriteLine("Erro ao tentar alterar a tarefa.");
        }


        
    }

    //metodo para deletar
    public static void Delete_ToDo(List<ToDo> ToDos, int Ids){
        var tarefa = ToDos.FirstOrDefault(t => t.Id == Ids);

        if(tarefa != null){
            ToDos.Remove(tarefa);
            Save_ToDo(ToDos);
            Console.WriteLine($"tarefa com o id {Ids} removida!");
        }
        else{
            Console.WriteLine("nao foi encontrada!");
        }

        

    }
}