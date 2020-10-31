using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Infotec.Models
{
    public class PessoaModel
    {
        // Campos ou atributos da classe (campos do banco de dados)
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        // Criar CONSTANTE para conexão com banco
        readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Infotec;Integrated Security=True";
        
        public void Salvar()
        {
            // Cria conexão com BD:
            using(SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                // Abre a conexão com BD:
                sqlCon.Open();
                // Instrução SQL para execução no BD:
                SqlCommand sqlCmd = new SqlCommand(
                        "INSERT into Pessoa VALUES(@Nome, @Email, @Senha)",sqlCon
                    );
                // Atribuir dados aos campos (ou parâmetros da instrução SQL)
                sqlCmd.Parameters.AddWithValue("@Nome", Nome);
                sqlCmd.Parameters.AddWithValue("@Email", Email);
                sqlCmd.Parameters.AddWithValue("@Senha", Senha);
                sqlCmd.ExecuteNonQuery();
            }
        }
    }
}
