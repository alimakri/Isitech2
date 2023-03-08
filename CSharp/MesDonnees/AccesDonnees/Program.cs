using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesDonnees
{
    internal class Program
    {
        //private static SqlCommand cmd;
        static void Main(string[] args)
        {
            //SetupConnexion();
            //ModeDeconnecte();
            //ModeConnecte();
            ModeConnecteProc();
            //ModeConnecte();
        }

        private static void SetupConnexion()
        {
            var cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2017;Integrated Security=True";
            cnx.Open();

            var cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.Text;
            //cmd.CommandText = "Select ProductID, Name from Production.Product";
            cmd.CommandText = @"select ProductID, p.Name pName, s.Name sName, ListPrice 
                                from Production.Product p 
                                inner join Production.ProductSubcategory s on 
                                    p.ProductSubcategoryID = s.ProductSubcategoryID";
        }
        private static void ModeConnecteProc()
        {
            var cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2017;Integrated Security=True";
            cnx.Open();

            var cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = @"Majoration";
            cmd.Parameters.Add(new SqlParameter("pourcentage", 1.1));
            var n = cmd.ExecuteNonQuery();
        }
        private static void ModeConnecte()
        {
            var cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2017;Integrated Security=True";
            cnx.Open();

            var cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"update Production.Product set ListPrice=ListPrice / 0.9 where LEFT(ProductNumber,2)='BK'";
            var n = cmd.ExecuteNonQuery();

        }
        private static void ModeDeconnecte()
        {
            var cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2017;Integrated Security=True";
            cnx.Open();

            var cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"select ProductID, p.Name pName, p.ListPrice, ProductNumber 
                                from Production.Product p";
            //Configuration mode deco
            var adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            var ds = new DataSet();
            var cb = new SqlCommandBuilder(adapter);

            //Remplissage DataSet avec commande
            adapter.Fill(ds);

            //Traitement des données
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row.Field<string>("ProductNumber").StartsWith("BK"))
                {
                    Console.WriteLine("{0}  -  {1} : {2}", row["ProductID"], row["pName"], row["ListPrice"]);
                    row["ListPrice"] = row.Field<decimal>("ListPrice") * 0.9M;
                }
            }

            adapter.Update(ds);
            Console.ReadLine();
        }
        /*
        private static void ModeConnecte()
        {
            /*SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0}  -  {1}", reader["ProductID"], reader["Name"]);
            }
            reader.Close();

            cmd.CommandText = "UPDATE Production.Product set Name ='Road-450 Red, 61' where ProductId=755";
            var lignes = cmd.ExecuteNonQuery();
            Console.WriteLine("{0} ligne(s) affectées",lignes);
        }
    */
    }
}
