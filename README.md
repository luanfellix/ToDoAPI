# ToDo CLI + API

Esse projeto é uma aplicação de gerenciamento de tarefas feita em C#, feito apenas com intuito de práticar. E com funcionalidades de adicionar, editar, listar e deletar tarefas. Os dados são salvos em um arquivo JSON simulando um banco de dados local, e integrados a uma API q escuta na porta 5050.

## Funcionalidades

- 🔄 CRUD completo de tarefas (Create, Read, Update, Delete)
- 💾 persistência em arquivo JSON
- 🌐 integração com API local (POST em `/sendtask`)
- 🧠 identificação de tarefas por ID
- 🔧 organizado em camadas: `Program.cs`, `ToDo.cs`, `Routes.cs`

## Como executar

1. clone o repositório
2- compile e execute o código
