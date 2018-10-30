using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CentralHRService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CentralHRService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstancesController : ControllerBase
    {
        [HttpPost]
        public void InstancePing(InstanceViewModel instanceViewModel) {
            using (SqlConnection connection = new SqlConnection("RICHARD I NEED CONNECTION STRING"))
            {
                String query = "INSERT INTO [dbo].[HRInstances]"+
                        "([InstanceName]"+
                           ",[LicenseGuid]"+
                           ",[LastRunSSUGuid]"+
                           ",[VersionMajor]"+
                           ",[VersionMinor]"+
                           ",[Build]"+
                           ",[Revision]"+
                           ",[LastPing])"+
                     "VALUES"+
                           "(@InstanceName"+
                           ", @LicenseGuid"+
                           ", @LastRunSSUGuid"+
                           ", @VersionMajor"+
                           ", @VersionMinor"+
                           ", @Build"+
                           ", @Revision"+
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
        }
    }
}