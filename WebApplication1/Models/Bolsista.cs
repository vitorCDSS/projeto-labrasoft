using System;

namespace WebApplication1.Models
{
    public class Bolsista
    {
        // EXERCÍCIO POO:
        // Com base no formulário que vocês criaram, definam as propriedades abaixo.
        // Lembrem-se de usar 'public', o tipo de dado (string, int, etc) e o { get; set; }

        public string Nome { get; set; }

        // TODO: Criar a propriedade para o CPF
        public string CPF { get; set; }
        // TODO: Criar a propriedade para a Matrícula
        public string matricula { get; set; }
        // TODO: Criar a propriedade para a Data de Nascimento
        public DateTime data_de_nascimento { get; set; }
        // TODO: Criar a propriedade para o Sexo
        public char sexo { get; set; }
        // TODO: Criar método com o resumo das informações contendo nome e matrícula
        public string resumir_usuario()
        {
            return $"bolsista: {Nome} matricula: {matricula}";

        }
        //TODO: Criar método que calcúla a idade do bolsista      
        public int calcular_idade ()
        {
            int idade = DateTime.Now.Year - data_de_nascimento.Year;
            return idade;
        }
    }
}
