﻿using System.Data;
using System.Data.SqlClient;

namespace ProdutosBD
{
    class CrudProduto : ICrud<Produto>
    {
        public bool add()
        {
            Produto prod = new Produto();

            Console.WriteLine("Insira o nome do produto que deseja adicionar:");
            prod.Nome = Console.ReadLine();

            Console.WriteLine("Insira o valor unitário do produto que deseja adicionar:");
            prod.ValorUnitario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Insira o estoque do produto que deseja adicionar:");
            prod.Estoque = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira a categoria do produto que deseja adicionar:");
            prod.CategoriaId = int.Parse(Console.ReadLine());

            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

                con.Open();

                SqlCommand sc = new SqlCommand();

                sc.CommandType = CommandType.Text;

                sc.CommandText = "insert into tb_produtos([nome], [valorUnitario], [estoque], [categoriaId])values(@nome, @valorUnitario, @estoque, @categoriaId)";

                sc.Parameters.Add("nome", SqlDbType.NChar).Value = prod.Nome;
                sc.Parameters.Add("valorUnitario", SqlDbType.Decimal).Value = prod.ValorUnitario;
                sc.Parameters.Add("estoque", SqlDbType.Int).Value = prod.Estoque;
                sc.Parameters.Add("categoriaId", SqlDbType.Int).Value = prod.CategoriaId;

                sc.Connection = con;

                return sc.ExecuteNonQuery() > 0;
            }
        }

        public List<Produto> consultar(List<Produto> produtos)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

                con.Open();

                SqlCommand sc = new SqlCommand();

                sc.CommandType = CommandType.Text;

                sc.CommandText = "select tb_produtos.id, tb_produtos.nome, valorUnitario, estoque, tb_produtos.categoriaId, tb_categorias.Nome from tb_produtos, tb_categorias where tb_produtos.categoriaId = tb_categorias.Id";

                sc.Connection = con;

                SqlDataReader sr;
                sr = sc.ExecuteReader();

                while (sr.Read())
                {
                    Produto produto = new();

                    produto.Id = Convert.ToInt32(sr["id"]);
                    produto.Nome = Convert.ToString(sr["nome"]);
                    produto.ValorUnitario = Convert.ToDecimal(sr["valorUnitario"]);
                    produto.Estoque = Convert.ToInt32(sr["estoque"]);
                    produto.categoria = new Categoria() { Id=Convert.ToInt32(sr["categoriaId"]), Nome= Convert.ToString(sr["Nome"]) };

                    produtos.Add(produto);
                }

                return produtos;
            }
        }

        public bool mostrar(List<Produto> produtos)
        {
            foreach(Produto i in produtos)
            {
                Console.WriteLine(i.toString());
            }

            return true;
        }

        public bool consultarCategoria(List<Produto> produtos)
        {
            Console.WriteLine("Insira o id da categoria que deseja consultar:");
            int cate = int.Parse(Console.ReadLine());

            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

                con.Open();

                SqlCommand sc = new SqlCommand();

                sc.CommandType = CommandType.Text;

                sc.CommandText = $"select tb_produtos.id, tb_produtos.nome, valorUnitario, estoque, tb_produtos.categoriaId,tb_categorias.Nome from tb_produtos, tb_categorias where tb_produtos.categoriaId = tb_categorias.Id and tb_produtos.categoriaId = {cate}";

                sc.Connection = con;

                SqlDataReader sr;
                sr = sc.ExecuteReader();

                while (sr.Read())
                {
                    Produto produto = new();

                    produto.Id = Convert.ToInt32(sr["id"]);
                    produto.Nome = Convert.ToString(sr["nome"]);
                    produto.ValorUnitario = Convert.ToDecimal(sr["valorUnitario"]);
                    produto.Estoque = Convert.ToInt32(sr["estoque"]);
                    produto.categoria = new Categoria() { Id = Convert.ToInt32(sr["categoriaId"]), Nome = Convert.ToString(sr["Nome"]) };

                    Console.WriteLine(produto.toString());
                }

                return true;
            }
        }

        public bool deletar()
        {
            Console.WriteLine("Insira o id do produto que deseja deletar:");
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

                con.Open();

                SqlCommand sc = new SqlCommand();

                sc.CommandType = CommandType.Text;

                sc.CommandText = $"delete from tb_produtos where tb_produtos.id = {id}";

                sc.Connection = con;

                SqlDataReader sr;
                sr = sc.ExecuteReader();

                return true;
            }
        }

        public bool alterar()
        {
            Console.WriteLine("Insira o id do produto que deseja alterar:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o novo nome do produto:");
            string nome = Console.ReadLine();

            Console.WriteLine("Insira o novo valor unitário do produto:");
            decimal valorU = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Insira o novo estoque do produto:");
            int estoque = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o novo id de sua categoria:");
            int idCat = int.Parse(Console.ReadLine());

            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

                con.Open();

                SqlCommand si = new SqlCommand();

                si.CommandType = CommandType.Text;

                si.CommandText = $"UPDATE tb_produtos SET tb_produtos.nome = @nome, tb_produtos.valorUnitario = @valorU, tb_produtos.estoque = @estoque, tb_produtos.categoriaId = @idCat WHERE tb_produtos.id = {id}";

                si.Parameters.Add("nome", SqlDbType.NChar).Value = nome;
                si.Parameters.Add("valorU", SqlDbType.Decimal).Value = valorU;
                si.Parameters.Add("estoque", SqlDbType.Int).Value = estoque;
                si.Parameters.Add("idCat", SqlDbType.Int).Value = idCat;

                si.Connection = con;

                SqlDataReader sr;
                sr = si.ExecuteReader();

                return true;
            }
        }
    }
}