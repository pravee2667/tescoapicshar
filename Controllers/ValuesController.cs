using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace QueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {


        }
        //[HttpGet]
        //[Route("~/api/chatbot")]
        //public Queue ChatBotData(int interval)
        //{
        //    Queue qresult = new Queue();
        //    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        //    int actual_inter = 330 - interval;
        //    //string mainconnec = ConfigurationManager.ConnectionStrings["feedback"].ConnectionString;
        //    string mainconnec = "Server = tcp:idcdbserver.database.windows.net,1433; Initial Catalog = IDCDB; Persist Security Info = False; User ID = idclogin; Password =Idc@login; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
        //    SqlConnection connection = new SqlConnection(mainconnec);
        //    string sqlquery = "select Queue_Name,max(people_count) from dbo.QueueOne  where time_stamp >  DATEADD(MINUTE ,@time,  GetDate()) group by Queue_Name ";
        //    SqlCommand command = new SqlCommand(sqlquery, connection);
        //    connection.Open();
        //    command.Parameters.AddWithValue("@time", actual_inter);
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter da = new SqlDataAdapter(command);
        //    da.Fill(ds);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        List<int> countarray = new List<int>();
        //        List<int> countarray1 = new List<int>();
        //        List<Data> ldata = new List<Data>();
        //        string qtext = string.Empty;
        //        string qtext1 = string.Empty;

        //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //        {
        //            Data data = new Data();
        //            DataTable dt = new DataTable();
        //            //if (i % 2 != 0)
        //            //{

        //            //}
        //            if (i < 2)
        //            {
        //                qtext = qtext + ds.Tables[0].Rows[i]["Queue_Name"].ToString();
        //                countarray.Add(Convert.ToInt32(ds.Tables[0].Rows[i][1]));
        //                //countarray.Add(Convert.ToInt32(ds.Tables[0].Rows[i][1]));
        //                data.count_peop = countarray;
        //                data.Queue_Name = qtext;
        //                if (i == 1)
        //                    ldata.Add(data);
        //            }
        //            else if (i <= 2 || i < 4)
        //            {
        //                qtext1 = qtext1 + ds.Tables[0].Rows[i]["Queue_Name"].ToString();
        //                countarray1.Add(Convert.ToInt32(ds.Tables[0].Rows[i][1]));
        //                data.count_peop = countarray1;
        //                data.Queue_Name = qtext1;
        //                if (i == 3)
        //                    ldata.Add(data);
        //            }
        //            else
        //            {

        //            }
        //        }
        //        qresult.queue = ldata;
        //    }
        //    connection.Close();
        //    return qresult;

        //}
        //SET sum_=select  sum(people_coun) from (select Queue_Name,max(people_count) as people_coun from dbo.QueueOne  where time_stamp >  DATEADD(MINUTE ,2,  GetDate()) group by Queue_Name )  as table_dup
      //  select Queue_Name, people_coun from(select Queue_Name, max(people_count) as people_coun from dbo.QueueOne where time_stamp >  DATEADD(MINUTE,2, GetDate()) group by Queue_Name )  as table_dup
             [HttpGet]
        [Route("~/api/chatbot")]
        public Queue ChatBotData(int interval)
        {
            Queue qresult = new Queue();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            int actual_inter = 330 - interval;
            //string mainconnec = ConfigurationManager.ConnectionStrings["feedback"].ConnectionString;
            string mainconnec = "Server = tcp:idcdbserver.database.windows.net,1433; Initial Catalog = IDCDB; Persist Security Info = False; User ID = idclogin; Password =Idc@login; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            SqlConnection connection = new SqlConnection(mainconnec);
            string sqlquery = "select Queue_Name,max(people_count) as people_coun from dbo.QueueOne  where time_stamp >  DATEADD(MINUTE ,@time,  GetDate()) group by Queue_Name ";
            SqlCommand command = new SqlCommand(sqlquery, connection);
            connection.Open();
            command.Parameters.AddWithValue("@time", actual_inter);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                List<int> countarray = new List<int>();
                List<int> countarray1 = new List<int>();
                List<Data> ldata = new List<Data>();
                string qtext = string.Empty;
                string qtext1 = string.Empty;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Data data = new Data();
                    DataTable dt = new DataTable();
                    string que_name=ds.Tables[0].Rows[i]["Queue_Name"].ToString();
                    int peop_coun=Convert.ToInt32(ds.Tables[0].Rows[i]["People_Coun"]);
                    data.Queue_Name = que_name;
                    data.count_peop = peop_coun;
                    ldata.Add(data);
                    //if (que_name=="Q1")
                    //{
                    //    data.Queue_Name = que_name;
                    //    data.count_peop = peop_coun;
                    //}
                    //else if (que_name == "Q2")
                    //{
                    //    data.Queue_Name = que_name;
                    //    data.count_peop = peop_coun;
                    //}
                    //else if (que_name == "Q3")
                    //{
                    //    data.Queue_Name = que_name;
                    //    data.count_peop = peop_coun;
                    //}
                    //else if (que_name == "Q4")
                    //{
                    //    data.Queue_Name = que_name;
                    //    data.count_peop = peop_coun;
                    //}

                    
                    //if (i % 2 != 0)
                    //{

                    //}
                    //if (i < 2)
                    //{
                    //    qtext = qtext + ds.Tables[0].Rows[i]["Queue_Name"].ToString();
                    //    countarray.Add(Convert.ToInt32(ds.Tables[0].Rows[i][1]));
                    //    //countarray.Add(Convert.ToInt32(ds.Tables[0].Rows[i][1]));
                    //    data.count_peop = countarray;
                    //    data.Queue_Name = qtext;
                    //    if (i == 1)
                    //        ldata.Add(data);
                    //}
                    //else if (i <= 2 || i < 4)
                    //{
                    //    qtext1 = qtext1 + ds.Tables[0].Rows[i]["Queue_Name"].ToString();
                    //    countarray1.Add(Convert.ToInt32(ds.Tables[0].Rows[i][1]));
                    //    data.count_peop = countarray1;
                    //    data.Queue_Name = qtext1;
                    //    if (i == 3)
                    //        ldata.Add(data);
                    //}
                    //else
                    //{

                    //}
                }
 qresult.queue = ldata;
            }
            connection.Close();
            return qresult;

        }





       

        [HttpPost]
        [Route("~/api/apiuser/")]
        public Result APIUser([FromBody] Input inkey)
        {
            Result res = new Result();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[4];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            //string mainconnec = ConfigurationManager.ConnectionStrings["feedback"].ConnectionString;
           
                string mainconnec = "Server = tcp:idcdbserver.database.windows.net,1433; Initial Catalog = IDCDB; Persist Security Info = False; User ID = idclogin; Password =Idc@login; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
                SqlConnection connection = new SqlConnection(mainconnec);
                string sqlquery = "insert into [dbo].[QueueUser](UserName,FCM) values (@user,@FCM)";
                SqlCommand command = new SqlCommand(sqlquery, connection);
                connection.Open();
                command.Parameters.AddWithValue("@user", finalString);
                command.Parameters.AddWithValue("@FCM", inkey.Key);
                int j = command.ExecuteNonQuery();

                //int count = 0;
                //DataSet ds = new DataSet();
                //SqlDataAdapter da = new SqlDataAdapter(command);
                //da.Fill(ds);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    count = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                //}
                connection.Close();
            if (j == 1)
                res.result = "Success";
            else
                res.result = "Failed";

            return res; 
           // return "Success";



        }
        [HttpGet]
        [Route("~/api/apianalytics")]
        public Queue APIAnalytics(int interval)
        {
           
            Queue qresult = new Queue();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            int actual_inter = 330 - interval;
            //string mainconnec = ConfigurationManager.ConnectionStrings["feedback"].ConnectionString;
            string mainconnec = "Server = tcp:idcdbserver.database.windows.net,1433; Initial Catalog = IDCDB; Persist Security Info = False; User ID = idclogin; Password =Idc@login; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            SqlConnection connection = new SqlConnection(mainconnec);
            string sqlquery = "select Queue_Name,max(people_count) as people_coun from dbo.QueueOne  where time_stamp >  DATEADD(MINUTE ,@time,  GetDate()) group by Queue_Name ";
            SqlCommand command = new SqlCommand(sqlquery, connection);
            connection.Open();
            command.Parameters.AddWithValue("@time", actual_inter);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                List<int> countarray = new List<int>();
                List<int> countarray1 = new List<int>();
                List<Data> ldata = new List<Data>(); 
                string qtext = string.Empty;
                string qtext1 = string.Empty;
                int count = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    count = count + Convert.ToInt32(ds.Tables[0].Rows[i]["People_Coun"]);
                }

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Data data = new Data();
                    
                    string que_name = ds.Tables[0].Rows[i]["Queue_Name"].ToString();
                    int peop_coun = Convert.ToInt32(ds.Tables[0].Rows[i]["People_Coun"]);
                   // float percentage = (int)Math.Round((peop_coun / count) * 100);

                    int percentComplet = (int)Math.Round((double)(100 * peop_coun) / count);
                    //Math.Truncate(percentComplet);
                   // int percentComplete =(int) decimal.Truncate(percentComplet);
                    //double perce_peop_coun=peop_coun * 10;
                    //string percentComplet = double.Parse(percentComplete.ToString().Split(',')[0]);
                    data.Queue_Name = que_name;
                    data.count_peop = peop_coun;
                    //(int)Math.Truncate(percentComplet)
                    data.percent_peop = percentComplet;
                    //data.percent_peop = perce_peop_coun;
                    ldata.Add(data);
                    


                }

                //DataTable dt = new DataTable(); 
                //dt.Columns.Add("Queue");
                //dt.Columns.Add("People_count");
                //dt.Columns.Add("Percent_People_count"); 


                //int sum_s=countarray.Sum();


                qresult.queue = ldata;
            }
            else
            {


            }
            connection.Close();
            return qresult;



        }

        [HttpGet]
        [Route("~/api/analyticsqueu")]
        public ThresholdQueue APIAnalyticsQueu(int threshold)
        {
            int result = 0;
            ThresholdQueue tque = new ThresholdQueue();
            List<intervalres> ds = new List<intervalres>();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            
            //string mainconnec = ConfigurationManager.ConnectionStrings["feedback"].ConnectionString;
            //string mainconnec = "Server = tcp:idcdbserver.database.windows.net,1433; Initial Catalog = IDCDB; Persist Security Info = False; User ID = idclogin; Password =Idc@login; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            string mainconnec = "Server = 10.130.6.174; uid=tescousr ; pwd=Sp@culat1on ;database=tescodb";
            //SqlConnection connection = new SqlConnection(mainconnec);
            //  MySqlConnection cnn = new MySqlCommand(mainconnec);
          //  MysqlConnection con = new MysqlConnection();
            //var con = new MysqlCommand(mainconnec);
            var conn = new MySql.Data.MySqlClient.MySqlConnection(mainconnec);
           

            
           // var reader = cmd.ExecuteReader();












            int[] intervals = {4,5,6,7};
            int[] newintervals = { 326, 325, 324, 323 };
            List<int> intervalss = new List<int>();
            List<int> newintervalss = new List<int>();
            intervalss.AddRange(intervals);
            newintervalss.AddRange(newintervals);
            conn.Open();
            for (int i=0;i<intervalss.Count;i++)
            {
                intervalres rs = new intervalres();
                string sqlquery = "select count(d.people_coun) as number_of_people from (select queue_name, max(people_count) as people_coun from QueueCount  where time_stamp > DATE_SUB(CURRENT_TIMESTAMP(),INTERVAL @interval MINUTE) group by queue_name) d group by d.people_coun having d.people_coun >= @threshhold";
                //string sqlquery1 = "select count(d.people_coun) as number_of_people from (select Queue_Name, max(people_count) as people_coun from dbo.QueueOne  where time_stamp > DATEADD(MINUTE, @interval, GetDate()) group by Queue_Name) d group by d.people_coun having d.people_coun >= @threshhold";
                var cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlquery, conn);
                // SqlCommand command = new SqlCommand(sqlquery, cnn);
                cmd.Parameters.AddWithValue("@interval", newintervalss[i]);
                cmd.Parameters.AddWithValue("@threshhold", threshold);
                //SqlDataReader dr = command.ExecuteReader();
                //if(dr.Read())
                //{
                //     result = dr.GetInt32(0);
                //}
                //dr.Read();

                //int result = command.ExecuteNonQuery();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var someValue = reader[0];


                    }
                }

                //DataSet dss = new DataSet();
                //SqlDataAdapter da = new SqlDataAdapter();
                //da.Fill(dss);
                //if (dss.Tables[0].Rows.Count > 0)
                //{
                //    result = Convert.ToInt32(dss.Tables[0].Rows[0][0].ToString());
                //}
                rs.intervals = intervalss[i];
                rs.number = result;
                ds.Add(rs);
            }
            tque.inter = ds;




            conn.Close();
            return tque;



        }

        public Queue Results(SqlCommand command,string interval,int threshold)
        {
            DataSet ds = new DataSet();
            Queue qresult = new Queue();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);    
            int count = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                List<int> countarray = new List<int>();
                List<int> countarray1 = new List<int>();
                List<Data> ldata = new List<Data>();
                string qtext = string.Empty;
                string qtext1 = string.Empty;
              

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    
                    string que_name = ds.Tables[0].Rows[i]["Queue_Name"].ToString();
                    int peop_coun = Convert.ToInt32(ds.Tables[0].Rows[i]["People_Coun"]);
                    
                    if (peop_coun >= threshold)
                        count = count + 1;
                  
                    



                }
                Data data = new Data();
                data.Queue_Name = interval;
                data.count_peop = count;
                ldata.Add(data);
// return ldata;



            }
            return qresult;
        }
        //[HttpGet]
        //[Route("~/api/analyticsqueu")]
        //public ThresholdQueue APIAnalyticsQueu(int threshold)
        //{
        //    int result = 0;
        //    ThresholdQueue tque = new ThresholdQueue();
        //    List<intervalres> ds = new List<intervalres>();
        //    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        //    //string mainconnec = ConfigurationManager.ConnectionStrings["feedback"].ConnectionString;
        //    //string mainconnec = "Server = tcp:idcdbserver.database.windows.net,1433; Initial Catalog = IDCDB; Persist Security Info = False; User ID = idclogin; Password =Idc@login; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
        //    string mainconnec = "Server = 10.130.6.149; Initial Catalog = IDCDB; Persist Security Info = False; User ID = idclogin; Password =Idc@login; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
        //    SqlConnection connection = new SqlConnection(mainconnec);
        //    int[] intervals = { 4, 5, 6, 7 };
        //    int[] newintervals = { 326, 325, 324, 323 };
        //    List<int> intervalss = new List<int>();
        //    List<int> newintervalss = new List<int>();
        //    intervalss.AddRange(intervals);
        //    newintervalss.AddRange(newintervals);
        //    connection.Open();
        //    for (int i = 0; i < intervalss.Count; i++)
        //    {
        //        intervalres rs = new intervalres();
        //        string sqlquery = "select count(d.people_coun) as number_of_people from (select Queue_Name, max(people_count) as people_coun from dbo.QueueOne  where time_stamp > DATEADD(MINUTE, @interval, GetDate()) group by Queue_Name) d group by d.people_coun having d.people_coun >= @threshhold";
        //        //string sqlquery1 = "select count(d.people_coun) as number_of_people from (select Queue_Name, max(people_count) as people_coun from dbo.QueueOne  where time_stamp > DATEADD(MINUTE, @interval, GetDate()) group by Queue_Name) d group by d.people_coun having d.people_coun >= @threshhold";

        //        SqlCommand command = new SqlCommand(sqlquery, connection);
        //        command.Parameters.AddWithValue("@interval", newintervalss[i]);
        //        command.Parameters.AddWithValue("@threshhold", threshold);
        //        //SqlDataReader dr = command.ExecuteReader();
        //        //if(dr.Read())
        //        //{
        //        //     result = dr.GetInt32(0);
        //        //}
        //        //dr.Read();

        //        //int result = command.ExecuteNonQuery();

        //        DataSet dss = new DataSet();
        //        SqlDataAdapter da = new SqlDataAdapter(command);
        //        da.Fill(dss);
        //        if (dss.Tables[0].Rows.Count > 0)
        //        {
        //            result = Convert.ToInt32(dss.Tables[0].Rows[0][0].ToString());
        //        }
        //        rs.intervals = intervalss[i];
        //        rs.number = result;
        //        ds.Add(rs);
        //    }
        //    tque.inter = ds;




        //    connection.Close();
        //    return tque;



        //}

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
