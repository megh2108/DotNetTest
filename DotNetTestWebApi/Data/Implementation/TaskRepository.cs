using DotNetTestWebApi.Data.Contract;
using DotNetTestWebApi.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DotNetTestWebApi.Data.Implementation
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IConfiguration _configuration;

        public TaskRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Tasks> GetAllTasks()
        {
            List<Tasks> tasks = new List<Tasks>();
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("mydb")))
            {
                string query = @"
            SELECT 
                t.TaskId,
                t.ProjectId,
                p.ProjectName,
                t.Title,
                t.Description,
                t.Priority,
                t.Status,
                t.DueDate,
                t.AssignedTo,
                u_assigned.Username AS AssignedToUsername,
                t.CreatedAt,
                t.CreatedBy,
                u_created.Username AS CreatedByUsername
            FROM 
                Tasks t
            JOIN 
                Projects p ON t.ProjectId = p.ProjectId
            LEFT JOIN 
                Users u_assigned ON t.AssignedTo = u_assigned.UserId
            JOIN 
                Users u_created ON t.CreatedBy = u_created.UserId";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            foreach (DataRow row in dt.Rows)
            {
                Tasks task = new Tasks
                {
                    TaskId = Convert.ToInt32(row["TaskId"]),
                    ProjectId = Convert.ToInt32(row["ProjectId"]),
                    Title = row["Title"].ToString(),
                    Description = row["Description"].ToString(),
                    Priority = row["Priority"].ToString(),
                    Status = row["Status"].ToString(),
                    DueDate = row["DueDate"] == DBNull.Value ? null : (DateTime?)row["DueDate"],
                    AssignedTo = row["AssignedTo"] == DBNull.Value ? null : Convert.ToInt32(row["AssignedTo"]),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    CreatedBy = Convert.ToInt32(row["CreatedBy"]),
                    Project = new Project
                    {
                        ProjectId = Convert.ToInt32(row["ProjectId"]),
                        ProjectName = row["ProjectName"].ToString()
                    },
                    AssignedUser = row["AssignedToUsername"] == DBNull.Value ? null : new User
                    {
                        UserId = Convert.ToInt32(row["AssignedTo"]),
                        Username = row["AssignedToUsername"].ToString()
                    },
                    CreatedByUser = new User
                    {
                        UserId = Convert.ToInt32(row["CreatedBy"]),
                        Username = row["CreatedByUsername"].ToString()
                    }
                };
                tasks.Add(task);
            }

            return tasks;
        }


        public Tasks GetTaskById(int taskId)
        {
            Tasks task = null;
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("mydb")))
            {
                string query = @"
            SELECT 
                t.TaskId,
                t.ProjectId,
                p.ProjectName,
                t.Title,
                t.Description,
                t.Priority,
                t.Status,
                t.DueDate,
                t.AssignedTo,
                u_assigned.Username AS AssignedToUsername,
                t.CreatedAt,
                t.CreatedBy,
                u_created.Username AS CreatedByUsername
            FROM 
                Tasks t
            JOIN 
                Projects p ON t.ProjectId = p.ProjectId
            LEFT JOIN 
                Users u_assigned ON t.AssignedTo = u_assigned.UserId
            JOIN 
                Users u_created ON t.CreatedBy = u_created.UserId
            WHERE 
                t.TaskId = @TaskId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TaskId", taskId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    task = new Tasks
                    {
                        TaskId = Convert.ToInt32(row["TaskId"]),
                        ProjectId = Convert.ToInt32(row["ProjectId"]),
                        Title = row["Title"].ToString(),
                        Description = row["Description"].ToString(),
                        Priority = row["Priority"].ToString(),
                        Status = row["Status"].ToString(),
                        DueDate = row["DueDate"] == DBNull.Value ? null : (DateTime?)row["DueDate"],
                        AssignedTo = row["AssignedTo"] == DBNull.Value ? null : Convert.ToInt32(row["AssignedTo"]),
                        CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                        CreatedBy = Convert.ToInt32(row["CreatedBy"]),
                        Project = new Project
                        {
                            ProjectId = Convert.ToInt32(row["ProjectId"]),
                            ProjectName = row["ProjectName"].ToString()
                        },
                        AssignedUser = row["AssignedToUsername"] == DBNull.Value ? null : new User
                        {
                            UserId = Convert.ToInt32(row["AssignedTo"]),
                            Username = row["AssignedToUsername"].ToString()
                        },
                        CreatedByUser = new User
                        {
                            UserId = Convert.ToInt32(row["CreatedBy"]),
                            Username = row["CreatedByUsername"].ToString()
                        }
                    };
                }
            }

            return task;
        }

        public List<Tasks> GetTaskByProjectId(int projectId)
        {
            List<Tasks> tasks = new List<Tasks>();
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("mydb")))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Tasks WHERE ProjectId = @ProjectId", con);
                cmd.Parameters.AddWithValue("@ProjectId", projectId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

            }

            foreach (DataRow row in dt.Rows)
            {
                Tasks task = new Tasks
                {
                    TaskId = Convert.ToInt32(row["TaskId"]),
                    ProjectId = Convert.ToInt32(row["ProjectId"]),
                    Title = row["Title"].ToString(),
                    Description = row["Description"].ToString(),
                    Priority = row["Priority"].ToString(),
                    Status = row["Status"].ToString(),
                    DueDate = row["DueDate"] == DBNull.Value ? null : (DateTime?)row["DueDate"],
                    AssignedTo = Convert.ToInt32(row["AssignedTo"]),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    CreatedBy = Convert.ToInt32(row["CreatedBy"])
                };
                tasks.Add(task);
            }

            return tasks;
        }

        public bool AddTask(Tasks task)
        {
            bool result = false;
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("mydb")))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Tasks (ProjectId, Title, Description, Priority, Status, DueDate, AssignedTo, CreatedAt, CreatedBy) VALUES (@ProjectId, @Title, @Description, @Priority, @Status, @DueDate, @AssignedTo, @CreatedAt, @CreatedBy)", con);
                cmd.Parameters.AddWithValue("@ProjectId", task.ProjectId);
                cmd.Parameters.AddWithValue("@Title", task.Title);
                cmd.Parameters.AddWithValue("@Description", task.Description);
                cmd.Parameters.AddWithValue("@Priority", task.Priority);
                cmd.Parameters.AddWithValue("@Status", task.Status);
                cmd.Parameters.AddWithValue("@DueDate", task.DueDate ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@AssignedTo", task.AssignedTo);
                cmd.Parameters.AddWithValue("@CreatedAt", task.CreatedAt);
                cmd.Parameters.AddWithValue("@CreatedBy", task.CreatedBy);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                result = rowsAffected > 0;
            }
            return result;
        }

        public bool UpdateTask(Tasks task)
        {
            bool result = false;
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("mydb")))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Tasks SET ProjectId = @ProjectId, Title = @Title, Description = @Description, Priority = @Priority, Status = @Status, DueDate = @DueDate, AssignedTo = @AssignedTo, CreatedBy = @CreatedBy WHERE TaskId = @TaskId", con);
                cmd.Parameters.AddWithValue("@TaskId", task.TaskId);
                cmd.Parameters.AddWithValue("@ProjectId", task.ProjectId);
                cmd.Parameters.AddWithValue("@Title", task.Title);
                cmd.Parameters.AddWithValue("@Description", task.Description);
                cmd.Parameters.AddWithValue("@Priority", task.Priority);
                cmd.Parameters.AddWithValue("@Status", task.Status);
                cmd.Parameters.AddWithValue("@DueDate", task.DueDate ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@AssignedTo", task.AssignedTo);
                cmd.Parameters.AddWithValue("@CreatedBy", task.CreatedBy);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                result = rowsAffected > 0;
            }
            return result;
        }

        public bool DeleteTask(int taskId)
        {
            bool result = false;
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("mydb")))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Tasks WHERE TaskId = @TaskId", con);
                cmd.Parameters.AddWithValue("@TaskId", taskId);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                result = rowsAffected > 0;
            }
            return result;
        }
    }
}
