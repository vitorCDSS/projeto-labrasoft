using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Repositorio
    {
       
        public static List<Bolsista> listaBolsista = new List<Bolsista>()
        {
            new Bolsista
            {
               Nome = "Ana Beatriz Souza",
                CPF = "123.456.789-01",
                Matricula = "2024001",
                DataNascimento = new DateTime(2002, 3, 15),
                Sexo = "Feminino"
            },
            new Bolsista
            {
                Nome = "Bruno Henrique Lima",
                CPF = "234.567.890-12",
               Matricula = "2024002",
               DataNascimento = new DateTime(2001, 7, 22),
                Sexo = "Masculino"
            },
            new Bolsista
           {
                 Nome = "Carla Mendes Oliveira",
                 CPF = "345.678.901-23",
                 Matricula = "2024003",
                 DataNascimento = new DateTime(2003, 1, 10),
                Sexo = "Feminino"
             },
            new Bolsista
            {
                Nome = "Diego Santos Ferreira",
                CPF = "456.789.012-34",
                Matricula = "2024004",
                DataNascimento = new DateTime(2000, 11, 5),
                Sexo = "Masculino"
            },
            new Bolsista
            {
                Nome = "Eduarda Costa Almeida",
                CPF = "567.890.123-45",
                Matricula = "2024005",
                DataNascimento = new DateTime(2002, 9, 28),
                Sexo = "Feminino"
            }
        };
        public static List<Coordenador> listaCoordenador = new List<Coordenador>()
            {
            new Coordenador
            {
               Nome = "Ana Beatriz Souza",
                CPF = "123.456.789-01",
                Titulação = "2024001",
                AreaDeAtuação = "adsadasd",
                Email = "email.com.br",
            },
            new Coordenador
            {
                Nome = "Bruno Henrique Lima",
                CPF = "234.567.890-12",
               Titulação = "2024002",
               AreaDeAtuação = "adsadasd",
                Email = "email.com.br",
            },
            new Coordenador
           {
                 Nome = "Carla Mendes Oliveira",
                 CPF = "345.678.901-23",
                 Titulação = "2024003",
                 AreaDeAtuação = "adsadasd",
                Email = "email.com.br",
             },
            new Coordenador
            {
                Nome = "Diego Santos Ferreira",
                CPF = "456.789.012-34",
                Titulação = "2024004",
                AreaDeAtuação = "adsadasd",
                Email = "email.com.br",
            },
            new Coordenador
            {
                Nome = "Eduarda Costa Almeida",
                CPF = "567.890.123-45",
                Titulação = "2024005",
                AreaDeAtuação = "adsadasd",
                Email = "email.com.br",
            }
        };
        public static List<Projeto> listaProjetos = new List<Projeto>();
    }
}