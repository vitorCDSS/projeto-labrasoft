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


        public static List<Coordenador> ObterCoordenadores()
        {
            List<Coordenador> lista = new List<Coordenador>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Nome, CPF, Titulacao, AreaAtuacao, Email FROM dbo.Coordenador";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Coordenador b = new Coordenador();
                            b.Nome = reader["Nome"].ToString();                            
                            b.CPF = reader["CPF"].ToString();
                            b.Titulacao = reader["Titulacao"].ToString();
                            b.AreaAtuacao = reader["AreaAtuacao"].ToString();
                            b.Email = reader["Email"].ToString();
                            lista.Add(b);
                        }
                    }
                }
            }

            return lista;
        }

        public static void AdicionarCoordenador(Coordenador coordenador)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO dbo.Coordenador (Nome, CPF, Titulacao, AreaAtuacao, Email) 
                                VALUES (@Nome, @CPF, @Titulacao, @AreaAtuacao, @Email)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", coordenador.Nome);                    
                    cmd.Parameters.AddWithValue("@CPF", coordenador.CPF);
                    cmd.Parameters.AddWithValue("@Titulacao", coordenador.Titulacao);
                    cmd.Parameters.AddWithValue("@AreaAtuacao", coordenador.AreaAtuacao);
                    cmd.Parameters.AddWithValue("@Email", coordenador.Email);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<Projeto> ObterProjetos()
        {
            List<Projeto> lista = new List<Projeto>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Titulo, VerbaAprovada, ValorBolsaIndividual, AreaConhecimento FROM dbo.Projeto";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Projeto b = new Projeto();
                            b.Titulo = reader["Titulo"].ToString();
                            b.VerbaAprovada = Convert.ToDecimal(reader["VerbaAprovada"]);
                            b.ValorBolsaIndividual = Convert.ToDecimal(reader["ValorBolsaIndividual"]);
                            b.AreaConhecimento = reader["AreaConhecimento"].ToString();
                            lista.Add(b);
                        }
                    }
                }
            }

            return lista;
        }

        public static void AdicionarProjeto(Projeto projeto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO dbo.Projeto (Titulo, VerbaAprovada, ValorBolsaIndividual, AreaConhecimento) 
                                VALUES (@Titulo, @VerbaAprovada, @ValorBolsaIndividual, @AreaConhecimento)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", projeto.Titulo);
                    cmd.Parameters.AddWithValue("@VerbaAprovada", projeto.VerbaAprovada);
                    cmd.Parameters.AddWithValue("@ValorBolsaIndividual", projeto.ValorBolsaIndividual);
                    cmd.Parameters.AddWithValue("@AreaConhecimento", projeto.AreaConhecimento);
                    

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}