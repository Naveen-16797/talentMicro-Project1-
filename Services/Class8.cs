using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;

namespace WebApplication1.Services
{
    public class Class8
    {
        internal Object getAll()
        {
            SqlDataReader rdr = null;

            SqlConnection conn = null;

            SqlCommand command = null;

            var connectionString = string.Empty;
         

            connectionString = "Server=TONY;Database=master;Integrated Security=SSPI";

            conn = new SqlConnection(connectionString);


            command = new SqlCommand("sp_getAll", conn);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@tablename", "Employee"));

            conn.Open();
            String que = null;
            rdr = command.ExecuteReader();
            JavaScriptSerializer js = new JavaScriptSerializer();
            while (rdr.Read())

            {
                String s = (String)rdr[0];
                que = que + s;
            }
            var result = js.Deserialize<dynamic>(que);
            Class10 cl = new Class10("Getting Data...", "OK.", result, "GET", "http://192.168.0.186:8087/api/Employee");
            string res = JsonConvert.SerializeObject(cl);
            var finres = js.Deserialize<dynamic>(res);
            return finres;
            

        }

        internal object validateLogin(string username, string password,int id)
        {
            SqlDataReader rdr = null;

            SqlConnection conn = null;

            SqlCommand command = null;

            var connectionString = string.Empty;

            connectionString = "Server=TONY;Database=master;Integrated Security=SSPI";

            conn = new SqlConnection(connectionString);
            command = new SqlCommand("sp_validations", conn);
            command.CommandType = CommandType.StoredProcedure;
            Regex regex = new Regex("([A-Za-z0-9])+@.*");
            Match match = regex.Match(username);
            if (match.Success)
            {
                command.Parameters.Add(new SqlParameter("@username_type", "Email_id"));
                command.Parameters.Add(new SqlParameter("@username", username));
                command.Parameters.Add(new SqlParameter("@pass", password));
            }
            else {
                command.Parameters.Add(new SqlParameter("@username_type", "pcontact_number"));
                command.Parameters.Add(new SqlParameter("@username", username));
                command.Parameters.Add(new SqlParameter("@pass", password));
            }
            conn.Open();
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                rdr = command.ExecuteReader();
            }
            catch (Exception e)
            {
                String mem = null;
                if (e.ToString().Contains("Password"))
                {
                    mem = "Incorrect Password !";
                }
                else {
                    mem = "Not a Valid Username !";
                }
                Class9 cl = new Class9("validation ....", 0, mem, "Get", "http://192.168.0.186:8087/api/Employee");
                string result = JsonConvert.SerializeObject(cl);
                var finres = js.Deserialize<dynamic>(result);
                return finres;
            }
                while (rdr.Read())
                {
                    String s = (string)rdr[0];
                    var resul = js.Deserialize<dynamic>(s);
                    Class10 c = new Class10("Successfully Validate..", "OK", resul[0], "GET", "http://192.168.0.186:8087/api/Employee");
                    string res = JsonConvert.SerializeObject(c);
                    var finres = js.Deserialize<dynamic>(res);
                    return finres;

                }
            
            /*catch
            {
                Class9 cl = new Class9("validation ....", 0, "invalid username or pass", "Get", "http://192.168.0.186:8087/api/Employee");
                string result = JsonConvert.SerializeObject(cl);
                var finres = js.Deserialize<dynamic>(result);
                return finres;
            }
            conn.Close();
            Class9 c1 = new Class9("validation ....", 0, "invalid username or pass", "Get", "http://192.168.0.186:8087/api/Employee");
            string resul1 = JsonConvert.SerializeObject(c1);
            var finres1 = js.Deserialize<dynamic>(resul1);
            return finres1;
    */
            return "sorry";

    }

    internal object putPassword(string pass, string link)
        {
            SqlDataReader rdr = null;

            SqlConnection conn = null;

            SqlCommand command = null;

            var connectionString = string.Empty;

            connectionString = "Server=TONY;Database=master;Integrated Security=SSPI";

            conn = new SqlConnection(connectionString);
            command = new SqlCommand("sp_updatepass", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@pass", pass));
            command.Parameters.Add(new SqlParameter("@password_link", link));
            conn.Open();
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                rdr = command.ExecuteReader();
                
                if (rdr != null)
                {
                    Class9 cl = new Class9("Updating ....", 0, "Successfully Updated", "PUT", "http://192.168.0.186:8087/api/Employee");
                    string result = JsonConvert.SerializeObject(cl);
                    var finres = js.Deserialize<dynamic>(result);
                    return finres;

                }
                else
                {
                    Class9 cl = new Class9("Updating ....", 0, "Failed to Update in Database", "PUT", "http://192.168.0.186:8087/api/Employee");
                    string result = JsonConvert.SerializeObject(cl);
                    var finres = js.Deserialize<dynamic>(result);
                    return finres;
                }
           }
            catch
            {
                Class9 cl = new Class9("Updation ....", 0, "Updation Failed", "POST", "http://192.168.0.186:8087/api/Employee");
                string result = JsonConvert.SerializeObject(cl);
                var finres = js.Deserialize<dynamic>(result);
                return finres;
            }
            

        }

        internal object getoneEmp(int id)
        {
            SqlDataReader rdr = null;

            SqlConnection conn = null;

            SqlCommand command = null;

            var connectionString = string.Empty;

            connectionString = "Server=TONY;Database=master;Integrated Security=SSPI";

            conn = new SqlConnection(connectionString);
            command = new SqlCommand("sp_oneEMp", conn);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@id", id.ToString()));
            command.Parameters.Add(new SqlParameter("@table", "Employee"));

            conn.Open();
            String que = null;
            rdr = command.ExecuteReader();
            JavaScriptSerializer js = new JavaScriptSerializer();
            while (rdr.Read())

            {
                String s = (String)rdr[0];
                que = que + s;
            }
            try
            {
                var result = js.Deserialize<dynamic>(que);
                Class10 cl = new Class10("Getting Data...", "OK.", result[0], "GET", "http://192.168.0.186:8087/api/Employee");
                string res = JsonConvert.SerializeObject(cl);
                var finres = js.Deserialize<dynamic>(res);
                return finres;
            }
            catch {
                Class9 cl = new Class9("invalid Employee ID", id, "Failed to Get", "GET", "http://192.168.0.186:8087/api/Employee");

                string res = JsonConvert.SerializeObject(cl);
                var finres = js.Deserialize<dynamic>(res);
                return finres;
            }

        }

        internal object Getisdwithcountry(String value)
        {
            
            if (!value.Equals("iwc")) {
                return "Soryy this api is not Exist";
            }
            SqlDataReader rdr = null;
            var jsonSerialiser = new JavaScriptSerializer();
            SqlConnection conn = null;

            SqlCommand command = null;

            var connectionString = string.Empty;

            connectionString = "Server=TONY;Database=master;Integrated Security=SSPI";

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

            connectionString = "Server=TONY;Database=master;Integrated Security=SSPI";

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
            else
            {
                command = new SqlCommand("select * from TM_COUNTRY", conn);
            }
            command.CommandType = CommandType.StoredProcedure;
            conn.Open();
            rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                String s = (string)rdr[0];
                jsondata = jsondata + s;
            }

            conn.Close();
            var result = js.Deserialize<dynamic>(jsondata);
            return result;

        }
        internal object postJsonData(int id,Class4 value)
        {
            var r = Guid.NewGuid();
            var systime = DateTime.Now;
            String res = r.ToString() +"@"+ systime.Date.ToShortDateString();
            res = res.Replace("-", "_");
            String email = value.email;
            string output = JsonConvert.SerializeObject(value);
            String output1 = output.TrimStart('"').TrimEnd('"');

            SqlConnection conn = null;
            SqlCommand command = null;
            var connectionString = string.Empty;
            connectionString = "Server=TONY;Database=master;Integrated Security=SSPI";
            conn = new SqlConnection(connectionString);
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                if (id == 0)
                {
                    command = new SqlCommand("sp_storeALl", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@json", output1));
                    command.Parameters.Add(new SqlParameter("@pass", res));
                    Class12 c = new Class12();
                    c.send(res, email);
                }
                else
                {
                    command = new SqlCommand("sp_updetion", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@json", output1));
                    command.Parameters.Add(new SqlParameter("@id", id));
                }


                conn.Open();
                SqlDataReader rd = command.ExecuteReader();
                conn.Close();
               
                if (rd != null)
                {
                    Class9 cl = new Class9("Inserting ....",id,"Successfully Inserted","POST","http://192.168.0.186:8087/api/Employee");
                    string result = JsonConvert.SerializeObject(cl);
                    var finres = js.Deserialize<dynamic>(result);
                    return finres;

                }
                else
                {
                    Class9 cl = new Class9("Inserting ....", id, "Failed to Insert in Database", "POST", "http://192.168.0.186:8087/api/Employee");
                    string result = JsonConvert.SerializeObject(cl);
                    var finres = js.Deserialize<dynamic>(result);
                    return finres;
                }
            }
            catch
            {
                Class9 cl = new Class9("Updation ....", id, "Updation Failed", "POST", "http://192.168.0.186:8087/api/Employee");
                string result = JsonConvert.SerializeObject(cl);
                var finres = js.Deserialize<dynamic>(result);
                return finres;
            }
        }
    }
}