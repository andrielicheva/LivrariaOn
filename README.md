# 📚 API de Livraria - README

**Bem-vindo à API de Livraria!** Este projeto representa minha primeira incursão na criação de uma API usando **C#** e meu mergulho inicial em bancos de dados **MySQL**. O objetivo principal seria desenvolver uma API de livraria online que permita aos usuários criar, visualizar, editar e excluir livros.

## 🌟 Visão Geral do Projeto

### 🎯 Objetivos
O objetivo principal deste projeto é criar uma API para uma livraria online. O sistema deve permitir que os usuários:

- **Criem livros**
- **Visualizem todos os livros**
- **Editem informações dos livros**
- **Excluam livros**

### 🛠️ Stack Tecnológico
- **Linguagem:** C#
- **Banco de Dados:** MySQL
- **Framework:** .NET Core

## 📋 Requisitos

### 📚 Dados e Campos Sugeridos
Um livro contémseguintes campos:

- **id** (identificador único para cada livro)
- **título**
- **autor**
- **gênero** (por exemplo, ficção, romance, mistério)
- **preço**
- **quantidade em estoque**

### 🔗 Endpoints Necessários
A API fornece os seguintes endpoints:

- **Criar um livro:** `POST /livros`
- **Visualizar todos os livros:** `GET /livros`
- **Editar um livro:** `PUT /livros/{id}`
- **Excluir um livro:** `DELETE /livros/{id}`

