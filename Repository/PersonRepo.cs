using DapperApi.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApi.Repository
{
    public class PersonRepo : IPersonRepo
    {
        private readonly IConfiguration Configuration;

        public PersonRepo(IConfiguration _configuration)
        {
            Configuration = _configuration;


        }

        public string DeletePerson(int Personid)
        {
            try
            {
                string pr;
                using (SqlConnection conn = new SqlConnection(this.Configuration.GetConnectionString("DefaultConnection")))
                {
                    SqlCommand sqlComm = new SqlCommand("D_PersonInfo_P", conn);
                    sqlComm.Parameters.AddWithValue("@Personid", Personid);


                    pr = Personid.ToString()+"Deleted SuccessFully";

                    sqlComm.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    sqlComm.ExecuteNonQuery();
                    return pr;
                }
            }
            catch (Exception e)
            {
                
                throw;
            }
        }

        public PersonInfo GetPerson(int Personid)
        {
            PersonInfo pr = new PersonInfo();
            using (SqlConnection conn = new SqlConnection(this.Configuration.GetConnectionString("DefaultConnection")))
            {
                SqlCommand sqlComm = new SqlCommand("S_GetPersonInfo_P", conn);
                sqlComm.Parameters.AddWithValue("@Personid", Personid);


                sqlComm.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = sqlComm.ExecuteReader();
                while (dr.Read())
                {
                    pr.Personid = (int)dr["Personid"];
                    pr.Name = dr["Name"].ToString();
                    pr.Phoneno = dr["Phoneno"].ToString();
                    pr.Address = dr["Address"].ToString();
                    pr.Pincode = (int)dr["Pincode"];
                }

            }


            return pr;
        }

        public IEnumerable<PersonInfo> GetPersonDetails()
        {
            List<PersonInfo> PIList = new List<PersonInfo>();
            using (SqlConnection conn = new SqlConnection(this.Configuration.GetConnectionString("DefaultConnection")))
            {
                SqlCommand sqlComm = new SqlCommand("S_PersonInfo_P", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader dr = sqlComm.ExecuteReader();
                while (dr.Read())
                {
                    PersonInfo person = new PersonInfo
                    {
                        Personid = (int)dr["Personid"],
                        Name = dr["Name"].ToString(),
                        Phoneno = dr["Phoneno"].ToString(),
                        Address = dr["Address"].ToString(),
                        Pincode = (int)dr["Pincode"]

                    };
                    PIList.Add(person);
                }

            }


            return PIList;
        }

        public PersonInfo InsertPersonDetails(PersonInfo person)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.Configuration.GetConnectionString("DefaultConnection")))
                {
                    SqlCommand sqlComm = new SqlCommand("I_PersonInfo_P", conn);
                    sqlComm.Parameters.AddWithValue("@Name", person.Name);
                    sqlComm.Parameters.AddWithValue("@Phoneno", person.Phoneno);
                    sqlComm.Parameters.AddWithValue("@Address", person.Address);
                    sqlComm.Parameters.AddWithValue("@pincode", person.Pincode);



                    sqlComm.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    sqlComm.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {

                
            }
            return person;
        }

        public PersonInfo UpdatePersonDetails(int Persionid, PersonInfo person)
        {
            if (Persionid != person.Personid)
            {
                return null;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(this.Configuration.GetConnectionString("DefaultConnection")))
                {
                    SqlCommand sqlComm = new SqlCommand("U_PersonInfo_P", conn);
                    sqlComm.Parameters.AddWithValue("@Name", person.Name);
                    sqlComm.Parameters.AddWithValue("@Phoneno", person.Phoneno);
                    sqlComm.Parameters.AddWithValue("@Address",person.Address);
                    sqlComm.Parameters.AddWithValue("@pincode", person.Pincode);
                   
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    sqlComm.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                    throw;
                
            }




            return person;//success
        }
    }
    }

