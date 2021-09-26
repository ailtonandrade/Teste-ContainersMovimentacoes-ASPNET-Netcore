using ChoETL;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetop.Repositories
{
    public class MovimentacoesRepository
    {
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=projetodb;User ID=sa;Password=root;TrustServerCertificate=True");
        //getall
        public string getall()
        {
            conn.Open();
            SqlCommand sc = new SqlCommand("SELECT * FROM MOVIMENTACOES INNER JOIN CONTAINERS ON CONTAINERS.IDCONTAINER = MOVIMENTACOES.FKIDCONTAINER", conn);
            StringBuilder sb = new StringBuilder();
            using (var chojsonwriter = new ChoJSONWriter(sb))
            {
                chojsonwriter.Write(sc.ExecuteReader());
            }
            conn.Close();
            return sb.ToString();
        }
        //details
        public string details(int id)
        {
            conn.Open();
            SqlCommand sc = new SqlCommand("SELECT * FROM MOVIMENTACOES INNER JOIN CONTAINERS ON CONTAINERS.IDCONTAINER = MOVIMENTACOES.FKIDCONTAINER WHERE MOVIMENTACOES.IDMOVIMENTACAO = " + id, conn);
            StringBuilder sb = new StringBuilder();
            using (var chojsonwriter = new ChoJSONWriter(sb))
            {
                chojsonwriter.Write(sc.ExecuteReader());
            }
            conn.Close();
            return sb.ToString();
        }

        //details
        public string tipomovimentacao(string mov)
        {
            conn.Open();
            SqlCommand sc = new SqlCommand("SELECT * FROM MOVIMENTACOES INNER JOIN CONTAINERS ON CONTAINERS.IDCONTAINER = MOVIMENTACOES.FKIDCONTAINER WHERE MOVIMENTACOES.tipomovimentacao = '"+mov+"'  ", conn);
            StringBuilder sb = new StringBuilder();
            using (var chojsonwriter = new ChoJSONWriter(sb))
            {
                chojsonwriter.Write(sc.ExecuteReader());
            }
            conn.Close();
            return sb.ToString();
        }

        //save
        public void save(string clientecontainer, string numerocontainer, string tipocontainer, string statuscontainer, string categoriacontainer, string tipomovimentacao, string iniciomovimentacao, string fimmovimentacao)
        {
            conn.Open();
            SqlCommand sc = new SqlCommand("INSERT INTO CONTAINERS VALUES ('" + clientecontainer + "','" + numerocontainer + "','" + tipocontainer + "','" + statuscontainer + "','" + categoriacontainer + "');" +
                                            "INSERT INTO MOVIMENTACOES VALUES ('" + tipomovimentacao + "','" + iniciomovimentacao + "','" + fimmovimentacao + "',@@IDENTITY)", conn);
            sc.ExecuteNonQuery();
            conn.Close();
        }
        //update
        public void update(int idcontainer, int idmov, string clientecontainer, string numerocontainer, string tipocontainer, string statuscontainer, string categoriacontainer, string tipomovimentacao, string iniciomovimentacao, string fimmovimentacao)
        {
            conn.Open();
            SqlCommand sc = new SqlCommand("UPDATE CONTAINERS SET CLIENTECONTAINER = " + clientecontainer + ", NUMEROCONTAINER = " + numerocontainer + ", TIPOCONTAINER = " + tipocontainer + ", STATUSCONTAINER = " + statuscontainer + ", CATEGORIACONTAINER = " + categoriacontainer + " WHERE CONTAINERS.IDCONTAINER = " + idcontainer + " ", conn);
            sc.ExecuteNonQuery();
            conn.Close();
            conn.Open();
            SqlCommand scs = new SqlCommand("UPDATE MOVIMENTACOES SET TIPOMOVIMENTACAO = " + tipomovimentacao + ", INICIOMOVIMENTACAO= " + iniciomovimentacao + ", FIMMOVIMENTACAO = " + fimmovimentacao + " WHERE MOVIMENTACOES.IDMOVIMENTACAO = " + idmov + " ", conn);
            sc.ExecuteNonQuery();
            conn.Close();
        }

        //delete

        public void deletar(int id)
        {
            conn.Open();
            SqlCommand sc = new SqlCommand("DELETE FROM MOVIMENTACOES WHERE IDMOVIMENTACAO = " + id, conn);
            sc.ExecuteNonQuery();
            conn.Close();
        }
    }
}
