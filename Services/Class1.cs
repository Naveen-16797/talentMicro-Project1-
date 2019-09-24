using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using System.Web.Script.Serialization;
using NUglify.JavaScript;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using java.awt;

namespace WebApplication1.Services
{
    public class Class1
    {

        public string GetAllJsons()

        {

            SqlDataReader rdr = null;

            SqlConnection conn = null;

            SqlCommand command = null;

            var connectionString = string.Empty;
            String jsondata = null;

            connectionString = "Server=TONY;Database=master;Integrated Security=SSPI";

            conn = new SqlConnection(connectionString);


            command = new SqlCommand("sp_retrive", conn);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@tablename", "class"));

            conn.Open();

            rdr = command.ExecuteReader();
            var serialize = new JavaScriptSerializer();
                    

           while (rdr.Read())

            {
                Console.Write(rdr[0]);
 
                    String s = (String)rdr[0];
                try
                {
                    Class2 user = new Class2();
                    user = serialize.Deserialize<Class2>(s);
                    String JSONResult = JsonConvert.SerializeObject(user);
                    jsondata = JSONResult;
                }
                catch { 
                   //dynamic dynJson = JsonConvert.DeserializeObject<Class2>(s);
                    /*foreach (var item in dynJson)
                    {
                        Console.WriteLine("{0} {1} {2} {3}\n", item.name, item.enquiryType,
                            item.mail_id, item.phno);
                    }*/
                    jsondata = s;
                 
                }
                } 
            conn.Close();
            List<Class2> l = new List<Class2>();
            return jsondata;
        

            

        }

        internal object Getisdwithcountry(int id)
        {
            SqlDataReader rdr = null;
            var jsonSerialiser = new JavaScriptSerializer();
            SqlConnection conn = null;

            SqlCommand command = null;

            var connectionString = string.Empty;

            connectionString = "Server=TONY;Database=TalentMicro;Integrated Security=SSPI";

            conn = new SqlConnection(connectionString);
            command = new SqlCommand("sp_getisd", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@table", "TM_COUNTRY"));
            conn.Open();
            rdr = command.ExecuteReader();
            JavaScriptSerializer js = new JavaScriptSerializer();
            String que = null;
            while (rdr.Read())
            {
                String s = (String)rdr[0];
                que = que + s;
            }
            var result = js.Deserialize<dynamic>(que);
            rdr.Close();
            command = new SqlCommand("sp_getcountry", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@table", "TM_COUNTRY"));
            rdr = command.ExecuteReader();
            que = null;
            while (rdr.Read())
            {
                String s = (String)rdr[0];
                que = que + s;
            }
            var result2 = js.Deserialize<dynamic>(que);
            conn.Close();
            Class5 finalresult = new Class5();
            Class7 ic = new Class7();
            ic.Isd = result;
            ic.country = result2;
            finalresult.Status = "True";
            finalresult.Message = "isd code with country details";
            finalresult.Data = ic;
            finalresult.Code = "200";
            string output = JsonConvert.SerializeObject(finalresult);
            var finres = js.Deserialize<dynamic>(output);
            return finres;
        }


        internal object getstates(string data, string id)
        {
            SqlDataReader rdr = null;

            SqlConnection conn = null;
            var jsonSerialiser = new JavaScriptSerializer();
            SqlCommand command = null;

            var connectionString = string.Empty;
            String jsondata = null;

            connectionString = "Server=TONY;Database=TalentMicro;Integrated Security=SSPI";

            conn = new SqlConnection(connectionString);
            JavaScriptSerializer js = new JavaScriptSerializer();

            if (data.Equals("states"))
            {
                command = new SqlCommand("sp_states", conn);
                command.Parameters.Add(new SqlParameter("@country_code", id));
                command.Parameters.Add(new SqlParameter("@country", "TM_COUNTRY"));
                command.Parameters.Add(new SqlParameter("@state", "TM_STATE"));
            }
            else if (data.Equals("city"))
            {
                command = new SqlCommand("sp_city", conn);
                command.Parameters.Add(new SqlParameter("@state_code", id));
                command.Parameters.Add(new SqlParameter("@state", "TM_STATE"));
                command.Parameters.Add(new SqlParameter("@city", "TM_LOCATION"));
            }
            else {
                command = new SqlCommand("select * from TM_COUNTRY", conn);
            }
            command.CommandType = CommandType.StoredProcedure;
            conn.Open();
            rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                String s = (string)rdr[0];
                jsondata =jsondata+s;
            }
            
            conn.Close();
            var result = js.Deserialize<dynamic>(jsondata);
            return result;

        }

        internal object GetALLquery(String data)
        {
            SqlDataReader rdr = null;
            var jsonSerialiser = new JavaScriptSerializer();
            SqlConnection conn = null;

            SqlCommand command = null;

            var connectionString = string.Empty;

            connectionString = "Server=TONY;Database=TalentMicro;Integrated Security=SSPI";

            conn = new SqlConnection(connectionString);

            
            String que = null;
            if (data .Equals("getisd"))
            {
                command = new SqlCommand("sp_getisd", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@table", "TM_COUNTRY"));
            }
            else if (data.Equals("getcountry")) {
                command = new SqlCommand("sp_getcountry", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@table", "TM_COUNTRY"));
            }

            
            conn.Open();
            rdr = command.ExecuteReader();
            while (rdr.Read()) {
                String s = (String)rdr[0];
                que = que + s;
            }
           // que = que.TrimStart('"').TrimEnd('"');


            JavaScriptSerializer js = new JavaScriptSerializer();
            if (data.Equals("getcountry"))
            {
                var result = js.Deserialize<dynamic>(que);
                return result;
            }
            else if (data.Equals("getisd"))
            {
                var result = js.Deserialize<dynamic>(que);
                return result;
            }
            else {

                return que;
                    }
                

        }

        internal string postJsonData(Class3 value)
        {
            string output = JsonConvert.SerializeObject(value);
            String output1 = output.TrimStart('"').TrimEnd('"');
            
            SqlConnection conn = null;
            SqlCommand command = null;
            var connectionString = string.Empty;
            connectionString = "Server=TONY;Database=master;Integrated Security=SSPI";
            conn = new SqlConnection(connectionString);
            command = new SqlCommand("sp_insert", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@jsonn", output1));
            conn.Open();
            SqlDataReader rd = command.ExecuteReader();
            conn.Close();
            if (rd != null)
            {
                return "inserted";
            }
            else
            {
                return "faill";
            }
            
            

        }

        /*public string postJsonData(String s) {

            SqlConnection conn = null;
            SqlCommand command = null;
            var connectionString = string.Empty;
            connectionString = "Server=TONY;Database=master;Integrated Security=SSPI";
            conn = new SqlConnection(connectionString);

            String gs = s.ToString();
            command = new SqlCommand("sp_storeData3", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@jsonData", gs));
            conn.Open();
            SqlDataReader rd = command.ExecuteReader();
            if (rd != null) {
                return "inserted";
            }
            else
            {
                return "faill";
            }
            conn.Close();

        }*/
    }
}