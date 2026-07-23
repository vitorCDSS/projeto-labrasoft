using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Repositorio
    {
        // Pega a string de conexão configurada no Web.config
        private static string connectionString = ConfigurationManager.ConnectionStrings["LabrasoftConnection"].ConnectionString;

        // Método para BUSCAR todos os bolsistas do banco de dados
        public static List<Bolsista> ObterBolsistas()
        {
            List<Bolsista> lista = new List<Bolsista>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Nome, Matricula, CPF, Sexo, DataNascimento FROM dbo.Bolsista";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Bolsista b = new Bolsista();                           
                            b.Nome = reader["Nome"].ToString();
                            b.Matricula = reader["Matricula"].ToString();
                            b.CPF = reader["CPF"].ToString();
                            b.Sexo = reader["Sexo"].ToString();
                            b.DataNascimento = Convert.ToDateTime(reader["DataNascimento"]);                            

                            lista.Add(b);
                        }
                    }
                }
            }

            return lista;
        }

        // Método para SALVAR um bolsista diretamente no banco de dados
        public static void AdicionarBolsista(Bolsista bolsista)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO dbo.Bolsista (Nome, Matricula, CPF, Sexo, DataNascimento) 
                                VALUES (@Nome, @Matricula, @CPF, @Sexo, @DataNascimento)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", bolsista.Nome);
                    cmd.Parameters.AddWithValue("@Matricula", bolsista.Matricula);
                    cmd.Parameters.AddWithValue("@CPF", bolsista.CPF);
                    cmd.Parameters.AddWithValue("@Sexo", bolsista.Sexo);
                    cmd.Parameters.AddWithValue("@DataNascimento", bolsista.DataNascimento);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


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
        };
        public static List<Projeto> listaProjetos = new List<Projeto>();
        
    }
}