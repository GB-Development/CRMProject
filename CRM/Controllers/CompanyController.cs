using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CRM.Models;

namespace CRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CompanyController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string[] prop = {
            "CompanyName",
            "CompanyINN",
            "CompanyKPP",
            "CompanyOGRN",
            "CompanyDirectorName",
            "CompanyDirectorINN",
            "CompanyDirectorPost",
            "CompanyAdress",
            "CompanyWeb",
            "CompanyFocus",
            "CompanyStatus",
            "CompanyDateReg",
            "CompanyMSP",
            "CompanyRevenue",
            "CompanyBalance",
            "CompanyArbitrage",
            "CompanyProfit",
            "CompanyTaxMode",
            "CompanyTax",
            "CompanyMainActivity",
            "CompanyOtherActivity",
            "CompanyOKPD2",
            "CompanyRegionReg",
            "CompanyLicenses",
            "CompanyVacancies",
            "CompanyLeasing",
            "CompanyLeasingCategory",
            "CompanyCollateral",
            "CompanyEmployeesNum",
            "CompanyBranches",
            "CompanyBranchesNum",
            "CompanySource",
            "CompanySegmentName"};

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select
	                *
                from Company
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnetion");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Company comp)
        {
            string query = @"insert into Company(";
            foreach (string item in prop)
            {
                query = query + item + ",";
            }
            query = query.Remove(query.Length - 1);
            query = query + ") values (";
            foreach (string item in prop)
            {
                query = query + "@" + item + ",";
            }
            query = query.Remove(query.Length - 1);
            query = query + ")";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnetion");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    foreach (string item in prop)
                    {
                        if (item == "CompanyDateReg")
                        {
                            myCommand.Parameters.AddWithValue("@" + item, Convert.ToDateTime(comp.GetType().GetProperty(item).GetValue(comp, null)));
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@" + item, comp.GetType().GetProperty(item).GetValue(comp, null));
                        }
                    }

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Company comp)
        {
            string query = @"update Company set ";
            foreach (string item in prop)
            {
                query = query + item + " = @" + item + ",";
            }
            query = query.Remove(query.Length - 1);
            query = query + " where CompanyId = @CompanyId";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnetion");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CompanyId", comp.CompanyId);
                    foreach (string item in prop)
                    {
                        if (item == "CompanyDateReg")
                        {
                            myCommand.Parameters.AddWithValue("@" + item, Convert.ToDateTime(comp.GetType().GetProperty(item).GetValue(comp, null)));
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@" + item, comp.GetType().GetProperty(item).GetValue(comp, null));
                        }
                    }

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                delete from Company
                where CompanyId = @CompanyId
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnetion");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CompanyId", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }
    }
}
