using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CentralHRService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CentralHRService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstancesController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public InstancesController(IConfiguration config)
        {
            configuration = config;
        }
        [HttpPost]
        public string InstancePing(InstanceViewModel instanceViewModel) {
            try
            {
                using (SqlConnection connection = new SqlConnection("Server=tcp:centralhr.database.windows.net,1433;Initial Catalog=CentralHR;Persist Security Info=False;User ID=centralhr;Password=Patrick@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    String query = "INSERT INTO [dbo].[HRInstances]" +
                            "([InstanceName]" +
                               ",[LicenseGuid]" +
                               ",[LastRunSSUGuid]" +
                               ",[VersionMajor]" +
                               ",[VersionMinor]" +
                               ",[Build]" +
                               ",[Revision]" +
                               ",[LastPing])" +
                         "VALUES" +
                               "(@InstanceName" +
                               ", @LicenseGuid" +
                               ", @LastRunSSUGuid" +
                               ", @VersionMajor" +
                               ", @VersionMinor" +
                               ", @Build" +
                               ", @Revision" +
                               ", @LastPing)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InstanceName", instanceViewModel.InstanceName);
                        command.Parameters.AddWithValue("@LicenseGuid", instanceViewModel.LicenseGuid);
                        command.Parameters.AddWithValue("@LastRunSSUGuid", instanceViewModel.LastRunSSUGuid);
                        command.Parameters.AddWithValue("@VersionMajor", instanceViewModel.VersionMajor);
                        command.Parameters.AddWithValue("@VersionMinor", instanceViewModel.VersionMinor);
                        command.Parameters.AddWithValue("@Build", instanceViewModel.Build);
                        command.Parameters.AddWithValue("@Revision", instanceViewModel.Revision);
                        command.Parameters.AddWithValue("@LastPing", instanceViewModel.LastPing);

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                            Console.WriteLine("Error inserting data into Database!");
                    }
                }
                return "";
            }
            catch (Exception x) {
                return x.Message + x.StackTrace + x.InnerException?.Message;
            }
        }
    }
}