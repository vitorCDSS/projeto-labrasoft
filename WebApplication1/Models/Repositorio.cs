using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
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
                string query = "SELECT Nome, Matricula, CPF, Sexo, DataNascimento, ProjetoID FROM dbo.Bolsista";

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
                            b.ProjetoID = reader["ProjetoID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ProjetoID"]);

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
                string query = "SELECT ID, Nome, CPF, Titulacao, AreaAtuacao, Email FROM dbo.Coordenador";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Coordenador b = new Coordenador();
                            b.ID = Convert.ToInt32(reader["ID"]); // <-- adicionado
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

        public static void AtualizarCoordenador(string cpfOriginal, Coordenador coordenador)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"UPDATE dbo.Coordenador 
                          SET Nome = @Nome, 
                              CPF = @CPF, 
                              Titulacao = @Titulacao, 
                              AreaAtuacao = @AreaAtuacao, 
                              Email = @Email
                          WHERE CPF = @CpfOriginal";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", coordenador.Nome);
                    cmd.Parameters.AddWithValue("@CPF", coordenador.CPF);
                    cmd.Parameters.AddWithValue("@Titulacao", coordenador.Titulacao);
                    cmd.Parameters.AddWithValue("@AreaAtuacao", coordenador.AreaAtuacao);
                    cmd.Parameters.AddWithValue("@Email", coordenador.Email);
                    cmd.Parameters.AddWithValue("@CpfOriginal", cpfOriginal);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Projeto> ObterProjetos()
        {
            List<Projeto> lista = new List<Projeto>();
            List<Bolsista> todosBolsistas = ObterBolsistas(); // já traz ProjetoID de cada um

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT p.ID, p.Titulo, p.VerbaAprovada, p.ValorBolsaIndividual, 
                         p.AreaConhecimento, p.CoordenadorID,
                         c.Nome AS CoordenadorNome, c.Email AS CoordenadorEmail
                  FROM dbo.Projeto p
                  JOIN dbo.Coordenador c ON c.ID = p.CoordenadorID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Projeto b = new Projeto();
                            b.ID = Convert.ToInt32(reader["ID"]);
                            b.Titulo = reader["Titulo"].ToString();
                            b.VerbaAprovada = Convert.ToDecimal(reader["VerbaAprovada"]);
                            b.ValorBolsaIndividual = Convert.ToDecimal(reader["ValorBolsaIndividual"]);
                            b.AreaConhecimento = reader["AreaConhecimento"].ToString();
                            b.CoordenadorID = Convert.ToInt32(reader["CoordenadorID"]);

                            b.coordenador = new Coordenador();
                            b.coordenador.Nome = reader["CoordenadorNome"].ToString();
                            b.coordenador.Email = reader["CoordenadorEmail"].ToString();

                            b.Bolsista = todosBolsistas.Where(x => x.ProjetoID == b.ID).ToList();

                            lista.Add(b);
                        }
                    }
                }
            }

            return lista;
        }

        public static int AdicionarProjeto(Projeto projeto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO dbo.Projeto (Titulo, VerbaAprovada, ValorBolsaIndividual, AreaConhecimento, CoordenadorID) 
                OUTPUT INSERTED.ID
                VALUES (@Titulo, @VerbaAprovada, @ValorBolsaIndividual, @AreaConhecimento, @CoordenadorID)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", projeto.Titulo);
                    cmd.Parameters.AddWithValue("@VerbaAprovada", projeto.VerbaAprovada);
                    cmd.Parameters.AddWithValue("@ValorBolsaIndividual", projeto.ValorBolsaIndividual);
                    cmd.Parameters.AddWithValue("@AreaConhecimento", projeto.AreaConhecimento);
                    cmd.Parameters.AddWithValue("@CoordenadorID", projeto.CoordenadorID);

                    con.Open();
                    return (int)cmd.ExecuteScalar(); // retorna o ID gerado pelo banco
                }
            }
        }

        public static void VincularBolsistaAoProjeto(string cpfBolsista, int projetoId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE dbo.Bolsista SET ProjetoID = @ProjetoID WHERE CPF = @CPF";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ProjetoID", projetoId);
                    cmd.Parameters.AddWithValue("@CPF", cpfBolsista);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Despesas> ObterDespesas()
        {
            List<Despesas> lista = new List<Despesas>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT ID, Descricao, Valor, Categoria, ProjetoId FROM dbo.Despesas";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Despesas d = new Despesas();
                            d.ID = Convert.ToInt32(reader["ID"]);
                            d.Descricao = reader["Descricao"].ToString();
                            d.Valor = Convert.ToDecimal(reader["Valor"]);
                            d.Categoria = reader["Categoria"].ToString();
                            d.ProjetoID = Convert.ToInt32(reader["ProjetoId"]);

                            lista.Add(d);
                        }
                    }
                }
            }

            return lista;
        }

        public static void AdicionarDespesa(Despesas despesa)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO dbo.Despesas (Descricao, Valor, Categoria, ProjetoId) 
                        VALUES (@Descricao, @Valor, @Categoria, @ProjetoId)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Descricao", despesa.Descricao);
                    cmd.Parameters.AddWithValue("@Valor", despesa.Valor);
                    cmd.Parameters.AddWithValue("@Categoria", despesa.Categoria);
                    cmd.Parameters.AddWithValue("@ProjetoId", despesa.ProjetoID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}