using DotNetTestWebApi.Data.Contract;
using DotNetTestWebApi.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DotNetTestWebApi.Data.Implementation
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IConfiguration _configuration;

        public ProjectRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Project> GetAllProjects()
        {
            List<Project> projects = new List<Project>();
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("mydb")))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Projects", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            foreach (DataRow row in dt.Rows)
            {
                Project project = new Project
                {
                    ProjectId = Convert.ToInt32(row["ProjectId"]),
                    ProjectName = row["ProjectName"].ToString(),
                    Description = row["Description"].ToString(),
                    Deadline = row["Deadline"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["Deadline"]),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    CreatedBy = Convert.ToInt32(row["CreatedBy"])
                };
                projects.Add(project);
            }

            return projects;
        }

        public Project GetProjectById(int projectId)
        {
            Project project = null;
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("mydb")))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Projects WHERE ProjectId = @ProjectId", con);
                cmd.Parameters.AddWithValue("@ProjectId", projectId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    project = new Project
                    {
                        ProjectId = Convert.ToInt32(row["ProjectId"]),
                        ProjectName = row["ProjectName"].ToString(),
                        Description = row["Description"].ToString(),
                        Deadline = row["Deadline"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["Deadline"]),
                        CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                        CreatedBy = Convert.ToInt32(row["CreatedBy"])
                    };
                }
            }

            return project;
        }

        public bool AddProject(Project project)
        {
            bool result = false;

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("mydb")))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Projects (ProjectName, Description, Deadline, CreatedBy) VALUES (@ProjectName, @Description, @Deadline, @CreatedBy)", con);
                cmd.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                cmd.Parameters.AddWithValue("@Description", project.Description);
                cmd.Parameters.AddWithValue("@Deadline", project.Deadline ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CreatedBy", project.CreatedBy);

                con.Open();
                result = cmd.ExecuteNonQuery() > 0;
                con.Close();
            }

            return result;
        }

        public bool UpdateProject(Project project)
        {
            bool result = false;

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("mydb")))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Projects SET ProjectName = @ProjectName, Description = @Description, Deadline = @Deadline WHERE ProjectId = @ProjectId", con);
                cmd.Parameters.AddWithValue("@ProjectId", project.ProjectId);
                cmd.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                cmd.Parameters.AddWithValue("@Description", project.Description);
                cmd.Parameters.AddWithValue("@Deadline", project.Deadline ?? (object)DBNull.Value);

                con.Open();
                result = cmd.ExecuteNonQuery() > 0;
                con.Close();
            }

            return result;
        }

        public bool DeleteProject(int projectId)
        {
            bool result = false;

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("mydb")))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Projects WHERE ProjectId = @ProjectId", con);
                cmd.Parameters.AddWithValue("@ProjectId", projectId);

                con.Open();
                result = cmd.ExecuteNonQuery() > 0;
                con.Close();
            }

            return result;
        }
    }
}
