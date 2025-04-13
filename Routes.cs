using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;



public class Routes
{
    public static void CreatePostEndPoint()
    {
        var builder = WebApplication.CreateBuilder();
        var app = builder.Build();

       app.MapPost("/sendtask", (List<ToDo> toDos) =>
{
    Console.WriteLine("API Está ligada e funcionando! tarefas em processo...");   

    return Results.Ok("Tarefas Prontas para serem enviadas!");
});

    app.Run();
    }


    public static async Task<bool> SendToDosAsync(List<ToDo> tarefas)
    {
        var json = JsonSerializer.Serialize(tarefas);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        using var client = new HttpClient();
        var response = await client.PostAsync("http://localhost:5050/sendtask", content);

        if (response.IsSuccessStatusCode){
            Console.WriteLine("Tarefas enviadas para o banco de dados com sucesso!");
            return true;
        }
        else{

            Console.WriteLine($"Erro ao enviar tarefas: {response.StatusCode}");
            return false;

        }
            
    }






}




