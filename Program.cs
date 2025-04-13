using System;
using System.Collections.Generic;

class Program{
    static string path = "ToDos/ToDos.json";
    static async Task Main(string[] args){

        Task.Run(() => Routes.CreatePostEndPoint());

        int option = 1;
        while(option != 0){
            //input p saber a opção do user
            Console.WriteLine("Qual Ação você deseja executar? 1 - carregar tarefas, 2 - adicionar tarefas, 3- editar tarefa, 4- deletar tarefa" );
            option = int.Parse(Console.ReadLine());

            if(option == 0 ){
                break;
            }
            //op 1 -> listar tarefas
            if(option == 1){
                 Console.WriteLine("carregando Tarefas...");
                 List<ToDo> ToDos = ToDo.Load_ToDos();
                 ToDo.List_ToDos(ToDos);
            }
            //-----------------------------------------------------------------------

                // op 2 - > add tarefa
                if(option == 2){
                    Console.WriteLine("Qual tarefa você deseja adicionar?");
                    string novaToDo = Console.ReadLine();
                    //verifica se é nula ou espaço em branco
                    if(string.IsNullOrWhiteSpace(novaToDo)){
                        Console.WriteLine("Digite uma tarefa válida!");
                        continue;
                    }
                    //instancia um objeto lista da class ToDos
                    List<ToDo> ToDos = ToDo.Load_ToDos();

                    //add os valores e acrescenta o ID
                    ToDo new_ToDo = new ToDo{
                        Tarefa = novaToDo,
                        Id = ToDos.Count + 1
                    };

                    //cria o obj c os valores;
                    ToDos.Add(new_ToDo);

                    //verifica se a API recebeu a task, se sim adiciona ela no arquivo JSON imitando um "banco de dados"
                    bool Sucess_Send = await Routes.SendToDosAsync(new List <ToDo> {new_ToDo});

                    if (Sucess_Send){
                        ToDo.Save_ToDo(ToDos); 
                        Console.WriteLine("Tarefa salva no banco de dados!");
                    } 
                    else{
                        Console.WriteLine("Erro ao receber tarefa, não foi salva no banco de dados!");
                    }
                    
                }
                //editar task
                if(option == 3){
                    List<ToDo> ToDos = ToDo.Load_ToDos();
                    ToDo.List_ToDos(ToDos);
                    Console.WriteLine("Qual tarefa você deseja editar?");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Ok! Você quer alterar a tarefa de ID = {id}, o que você deseja adicionar no lugar?");
                    string Newtask = Console.ReadLine();
                    ToDo.Update_ToDo(ToDos, id, Newtask);


                }



                //deleta uma tarefa buscando por id
                if(option == 4){

                    List<ToDo> ToDos = ToDo.Load_ToDos();
                    
                    ToDo.List_ToDos(ToDos);
                    Console.WriteLine("O que deseja excluir? Informa o Índice.");
                    int id =int.Parse(Console.ReadLine());

                    ToDo.Delete_ToDo(ToDos, id);
                }
            };
            
            

        
    }

}