﻿using Nedeljni_I_Marija_Bozic.Helpers;
using Nedeljni_I_Marija_Bozic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_I_Marija_Bozic.Service
{
    public class ServiceCode
    {
        public static User CurrentUser = new User();
        public User LoginMaster(string username, string password)
        {
            CurrentUser = null;
            password = HashPasswordHelper.HashPassword(password);
            try
            {
                using (SqlConnection conn = ConnectionHelper.GetNewConnection())
                { 
                    conn.Open();
                    try
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "Login_MasterUser";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Username", username);
                            cmd.Parameters.AddWithValue("@Password", password);
                            SqlDataAdapter adapter = new SqlDataAdapter();
                            adapter.SelectCommand = cmd;
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            foreach (DataRow row in dt.Rows)
                            {
                                CurrentUser= new User
                                {                                    
                                    Username = row[0].ToString(),
                                };                                
                            }
                            return CurrentUser;
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                        return null;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        public User LoginUserPass(string username, string password)
        {
            CurrentUser = null;
            password = HashPasswordHelper.HashPassword(password);
            try
            {
                using (SqlConnection conn = ConnectionHelper.GetNewConnection())
                {
                    conn.Open();
                    try
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "Login_User";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Username", username);
                            cmd.Parameters.AddWithValue("@Password", password);
                            SqlDataAdapter adapter = new SqlDataAdapter();
                            adapter.SelectCommand = cmd;
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            foreach (DataRow row in dt.Rows)
                            {
                                CurrentUser = new User
                                {
                                    UserId= int.Parse(row[0].ToString()),
                                    FirstName = row[1].ToString(),
                                    LastName= row[2].ToString(),
                                    Username = row[3].ToString(),
                                    RoleId = int.Parse(row[4].ToString())
                                };
                            }
                            return CurrentUser;
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                        return null;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        public User LoginManagerBackUpPass(string username, string password)
        {
            CurrentUser = null;
            password = HashPasswordHelper.HashPassword(password+"WPF");
            try
            {
                using (SqlConnection conn = ConnectionHelper.GetNewConnection())
                {
                    conn.Open();
                    try
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "Login_UserBackupPass";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Username", username);
                            cmd.Parameters.AddWithValue("@Password", password);
                            SqlDataAdapter adapter = new SqlDataAdapter();
                            adapter.SelectCommand = cmd;
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            foreach (DataRow row in dt.Rows)
                            {
                                CurrentUser = new User
                                {
                                    UserId = int.Parse(row[0].ToString()),
                                    FirstName = row[1].ToString(),
                                    LastName = row[2].ToString(),
                                    Username = row[3].ToString(),
                                    RoleId = int.Parse(row[4].ToString())
                                };
                            }
                            return CurrentUser;
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                        return null;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<Gender> GettAllGender()
        {
            List<Gender> genderList = new List<Gender>();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_AllGender";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            Gender r = new Gender
                            {
                                GenderId = int.Parse(row[0].ToString()),
                                Name = row[1].ToString(),
                            };
                            genderList.Add(r);
                        }
                        return genderList;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public List<MaritalStatus> GettAllMaritalStatus()
        {
            List<MaritalStatus> maritalStatusList = new List<MaritalStatus>();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_AllMaritalStatus";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            MaritalStatus r = new MaritalStatus
                            {
                                MaritalStatusId = int.Parse(row[0].ToString()),
                                Name = row[1].ToString(),
                            };
                            maritalStatusList.Add(r);
                        }
                        return maritalStatusList;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public List<AdministratorType> GettAllAdminType()
        {
            List<AdministratorType> admintTypeList = new List<AdministratorType>();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_AllAdministratorType";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            AdministratorType r = new AdministratorType
                            {
                                AdministratorTypeId = int.Parse(row[0].ToString()),
                                Name = row[1].ToString(),
                            };
                            admintTypeList.Add(r);
                        }
                        return admintTypeList;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public List<Qualifications> GettAllQualificationLevels()
        {
            List<Qualifications> qualificationLevelList = new List<Qualifications>();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_AllQualifications";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            Qualifications r = new Qualifications
                            {
                                QualificationsId = int.Parse(row[0].ToString()),
                                Name = row[1].ToString(),
                            };
                            qualificationLevelList.Add(r);
                        }
                        return qualificationLevelList;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public List<Position> GettAllPositions()
        {
            List<Position> positionList = new List<Position>();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_AllPositions";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            Position r = new Position
                            {
                                PositionId = int.Parse(row[0].ToString()),
                                Name = row[1].ToString(),
                                Description = row[2].ToString()
                            };
                            positionList.Add(r);
                        }
                        return positionList;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public List<Sector> GettAllSectors(out Sector sector)
        {
            Sector newSector = new Sector();            
            List<Sector> sectorList = new List<Sector>();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_AllSectors";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            Sector r = new Sector
                            {
                                SectorId = int.Parse(row[0].ToString()),
                                Name = row[1].ToString(),
                                Description = row[2].ToString()
                            };
                            if(r.Name!= "Default")
                            {
                                sectorList.Add(r);
                            }
                            else
                            {
                                newSector = r;
                                
                            }
                        }
                        sector = newSector;
                        return sectorList;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    sector = null;
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public List<LevelOfResponsibility> GettAllLevelsOfResponsibility()
        {
            List<LevelOfResponsibility> responsibilityList = new List<LevelOfResponsibility>();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_AllLevelOfResponsibility";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            LevelOfResponsibility r = new LevelOfResponsibility
                            {
                                LevelOfResponsibilityId = int.Parse(row[0].ToString()),
                                Name = row[1].ToString()                               
                            };
                            responsibilityList.Add(r);
                        }
                        return responsibilityList;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }         
        public List<Menager> GetAllMenagers()
        {
            List<Menager> menagerList = new List<Menager>();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_AllMenagers";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            Menager r = new Menager
                            {
                                ManagerId = int.Parse(row[0].ToString())
                            };
                            menagerList.Add(r);
                        }
                        return menagerList;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    return menagerList;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public Menager GetMenagerByUserId(int userId)
        {
            Menager res = new Menager();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        int levelResp;
                        cmd.CommandText = "Get_MenagerByUserId";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CompanyUserId", userId);

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row[9].ToString() == string.Empty)
                            {
                                levelResp = 4;
                            }
                            else
                            {
                                levelResp = int.Parse(row[9].ToString());
                            }
                            Menager r = new Menager
                            {
                                UserId = int.Parse(row[0].ToString()),
                                FirstName = row[1].ToString(),
                                LastName = row[2].ToString(),
                                Jmbg = long.Parse(row[3].ToString()),
                                GenderName = row[4].ToString(),
                                Address = row[5].ToString(),
                                MaritalStatusName = row[6].ToString(),
                                Username = row[7].ToString(),
                                Email = row[8].ToString(),
                                LevelOfResponsibility = levelResp,
                                NumOfSuccessfulProjects = int.Parse(row[10].ToString()),
                                NumberOfOffice = int.Parse(row[11].ToString()),
                                ManagerId = int.Parse(row[12].ToString())
                            };
                            res= r;
                        }
                        return res;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public Worker GetWorkerByUserId(int userId)
        {
            Worker res = new Worker();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        string positionName;
                        cmd.CommandText = "Get_WorkerByUserId";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CompanyUserId", userId);

                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr.IsDBNull(9))
                            {
                                positionName = "";
                            }
                            else
                            {
                                positionName = rdr[9].ToString();
                            }

                            Worker r = new Worker
                            {
                                UserId = int.Parse(rdr[0].ToString()),
                                FirstName = rdr[1].ToString(),
                                LastName = rdr[2].ToString(),
                                Jmbg = long.Parse(rdr[3].ToString()),
                                GenderName = rdr[4].ToString(),
                                Address = rdr[5].ToString(),
                                MaritalStatusName = rdr[6].ToString(),
                                Username = rdr[7].ToString(),
                                SectorName = rdr[8].ToString(),
                                PositionName = positionName,
                                YearsOfService= int.Parse(rdr[10].ToString()),
                                QualificationName = rdr[11].ToString()
                            };
                            res = r;
                        }
                        return res;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public Administrator GetAdminByUserId(int userId)
        {
            Administrator res = new Administrator();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_AdminByUserId";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CompanyUserId", userId);

                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            Administrator r = new Administrator
                            {
                                UserId = int.Parse(rdr[0].ToString()),
                                FirstName = rdr[1].ToString(),
                                LastName = rdr[2].ToString(),
                                Jmbg = long.Parse(rdr[3].ToString()),
                                GenderName = rdr[4].ToString(),
                                Address = rdr[5].ToString(),
                                MaritalStatusName = rdr[6].ToString(),
                                Username = rdr[7].ToString(),
                                AdministratorTypeName = rdr[8].ToString(),
                                ExpirationDate = DateTime.Parse(rdr[9].ToString())
                            };
                            res = r;
                        }
                        return res;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public List<Worker> GetAllWorkerByMenagerId(int menagerId)
        {
            List<Worker> workerList = new List<Worker>();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        string positionName;
                        cmd.CommandText = "Get_AllWorkersByMenagerId";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MenagerId", menagerId);

                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr.IsDBNull(9))
                            {
                                positionName = "";
                            }
                            else
                            {
                                positionName = rdr[9].ToString();
                            }

                            Worker r = new Worker
                            {
                                UserId = int.Parse(rdr[0].ToString()),
                                FirstName = rdr[1].ToString(),
                                LastName = rdr[2].ToString(),
                                Jmbg = long.Parse(rdr[3].ToString()),
                                GenderName = rdr[4].ToString(),
                                Address = rdr[5].ToString(),
                                MaritalStatusName = rdr[6].ToString(),
                                Username = rdr[7].ToString(),
                                SectorName = rdr[8].ToString(),
                                PositionName = positionName,
                                YearsOfService = int.Parse(rdr[10].ToString()),
                                QualificationName = rdr[11].ToString(),
                                
                            };
                            workerList.Add(r);
                        }
                        return workerList;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        
        public List<Worker> GetAllWorkers()
        {
            List<Worker> workerList = new List<Worker>();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        string positionName;
                        cmd.CommandText = "Get_AllWorkers";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr.IsDBNull(9))
                            {
                                positionName = "";
                            }
                            else
                            {
                                positionName = rdr[9].ToString();
                            }

                            Worker r = new Worker
                            {
                                UserId = int.Parse(rdr[0].ToString()),
                                FirstName = rdr[1].ToString(),
                                LastName = rdr[2].ToString(),
                                Jmbg = long.Parse(rdr[3].ToString()),
                                GenderName = rdr[4].ToString(),
                                Address = rdr[5].ToString(),
                                MaritalStatusName = rdr[6].ToString(),
                                Username = rdr[7].ToString(),
                                SectorName = rdr[8].ToString(),
                                PositionName = positionName,
                                YearsOfService = int.Parse(rdr[10].ToString()),
                                QualificationName = rdr[11].ToString(),

                            };
                            workerList.Add(r);
                        }
                        return workerList;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        
        public List<Menager> GetAllMenagersList()
        {
            List<Menager> menagerList = new List<Menager>();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        int levelResp;
                        cmd.CommandText = "Get_AllMenagerList";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row[9].ToString() == string.Empty)
                            {
                                levelResp = 4;
                            }
                            else
                            {
                                levelResp = int.Parse(row[9].ToString());
                            }
                            Menager r = new Menager
                            {
                                UserId = int.Parse(row[0].ToString()),
                                FirstName = row[1].ToString(),
                                LastName = row[2].ToString(),
                                Jmbg = long.Parse(row[3].ToString()),
                                GenderName = row[4].ToString(),
                                Address = row[5].ToString(),
                                MaritalStatusName = row[6].ToString(),
                                Username = row[7].ToString(),
                                Email = row[8].ToString(),
                                LevelOfResponsibility = levelResp,
                                NumOfSuccessfulProjects = int.Parse(row[10].ToString()),
                                NumberOfOffice = int.Parse(row[11].ToString()),
                                ManagerId = int.Parse(row[12].ToString())
                            };
                            menagerList.Add(r);
                        }
                        return menagerList;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public List<Menager> GetAllMenagersWithoutLevelOfResponsibility()
        {
            List<Menager> menagerList = new List<Menager>();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        int levelResp;
                        cmd.CommandText = "Get_AllMenagerWithoutLevelOfResponsibility";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row[9].ToString() == string.Empty)
                            {
                                levelResp = 4;
                            }
                            else
                            {
                                levelResp = int.Parse(row[9].ToString());
                            }
                            Menager r = new Menager
                            {
                                UserId = int.Parse(row[0].ToString()),
                                FirstName = row[1].ToString(),
                                LastName = row[2].ToString(),
                                Jmbg = long.Parse(row[3].ToString()),
                                GenderName = row[4].ToString(),
                                Address = row[5].ToString(),
                                MaritalStatusName = row[6].ToString(),
                                Username = row[7].ToString(),
                                Email = row[8].ToString(),
                                LevelOfResponsibility = levelResp,
                                NumOfSuccessfulProjects = int.Parse(row[10].ToString()),
                                NumberOfOffice = int.Parse(row[11].ToString()),
                                ManagerId = int.Parse(row[12].ToString())
                            };
                            menagerList.Add(r);
                        }
                        return menagerList;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public bool UpdateMenager(Menager menager)
        {
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Update_LevelOfResponsibility";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LevelId", menager.LevelOfResponsibility);
                        cmd.Parameters.AddWithValue("@MenagerId", menager.ManagerId);
                        SqlDataReader reader = cmd.ExecuteReader();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    Logging.LoggAction("AddNewUser", "Error", ex.ToString());
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public int AddCompanyUser(User user)
        {
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Insert_CompaniUser";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", user.LastName);
                        cmd.Parameters.AddWithValue("@JMBG", user.Jmbg);
                        cmd.Parameters.AddWithValue("@GenderId", user.GenderId);
                        cmd.Parameters.AddWithValue("@Address", user.Address);
                        cmd.Parameters.AddWithValue("@MaritalStatusId", user.MaritalStatusId);
                        cmd.Parameters.AddWithValue("@Username", user.Username);
                        cmd.Parameters.AddWithValue("@Password", HashPasswordHelper.HashPassword(user.Password));
                        cmd.Parameters.AddWithValue("@RoleId", user.RoleId);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            user.UserId = int.Parse(reader.GetValue(0).ToString());
                        }                       
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    Logging.LoggAction("AddNewUser", "Error", ex.ToString());
                    return 0;
                }
                finally
                {
                    conn.Close();
                }
            }
            return user.UserId;
        }

        public int AddAdminUser(Administrator user)
        {
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Insert_AdminUser";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CompanyUserId", user.CompanyUserId);
                        cmd.Parameters.AddWithValue("@AdministratorTypeId", user.AdministratorTypeId);
                        cmd.Parameters.AddWithValue("@ExpirationDate", user.ExpirationDate);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            user.UserId = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    Logging.LoggAction("AddNewAdminViewModel", "Error", ex.ToString());
                    return 0;
                }
                finally
                {
                    conn.Close();
                }
            }
            return user.UserId;
        }

        public int AddMenagerUser(Menager user)
        {
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Insert_Menager";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CompanyUserId", user.UserId);
                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.Parameters.AddWithValue("@BackupPassword", HashPasswordHelper.HashPassword(user.BackupPassword));
                        cmd.Parameters.AddWithValue("@NumOfSuccessfulProjects", user.NumOfSuccessfulProjects);
                        cmd.Parameters.AddWithValue("@NumberOfOffice", user.NumberOfOffice);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            user.ManagerId = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    Logging.LoggAction("RegistrationMenager", "Error", ex.ToString());
                    return 0;
                }
                finally
                {
                    conn.Close();
                }
            }
            return user.ManagerId;
        }

        public int AddWorkerUser(Worker user)
        {
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Insert_Worker";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CompanyUserId", user.UserId);
                        cmd.Parameters.AddWithValue("@ManagerId", user.ManagerId);
                        cmd.Parameters.AddWithValue("@SectorId", user.SectorId);
                        cmd.Parameters.AddWithValue("@PositionId", user.PositionId);
                        cmd.Parameters.AddWithValue("@YearsOfService", user.YearsOfService);
                        cmd.Parameters.AddWithValue("@QualificationsId", user.QualificationsId);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            user.WorkerId = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    Logging.LoggAction("RegistrationMenager", "Error", ex.ToString());
                    return 0;
                }
                finally
                {
                    conn.Close();
                }
            }
            return user.WorkerId;
        }

        public int AddSector(Sector sector)
        {
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Insert_Sector";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", sector.Name.ToUpper());
                        cmd.Parameters.AddWithValue("@Description", sector.Description);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            sector.SectorId = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    Logging.LoggAction("Add new sector", "Error", ex.ToString());
                    return 0;
                }
                finally
                {
                    conn.Close();
                }
            }
            return sector.SectorId;
        }

        public int AddPosition(Position position)
        {
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Insert_Position";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", position.Name.ToUpper());
                        cmd.Parameters.AddWithValue("@Description", position.Description);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            position.PositionId = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    Logging.LoggAction("Add new sector", "Error", ex.ToString());
                    return 0;
                }
                finally
                {
                    conn.Close();
                }
            }
            return position.PositionId;
        }

        public bool CheckUsernameUser(string userName)
        {
            bool result=false;
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Check_UniqueUsername";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", userName);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                           result=true;
                        }                        
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());                    
                    result = false;
                }
                finally
                {
                    conn.Close();
                }               
            }
            return result;
        }

        public bool CheckUsernameMasterUser(string userName)
        {
            bool result = false;
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Check_UniqueUsernameMaster";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", userName);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            result = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());                    
                    result = false;
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }
                
        public bool CheckUniqueEmail(string email)
        {
            bool result = false;
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Check_UniqueEmail";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Email", email);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            result = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    result = false;
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }

        public bool CheckJmbg(long jmbg)
        {
            bool result = false;
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Check_UniqueJmbg";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@JMBG", jmbg);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            result = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    result = false;
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }

        public bool CheckPositionName(string name)
        {
            bool result = false;
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Check_UniquePositionName";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", name.ToUpper());
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            result = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    result = false;
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }

        public bool CheckSectorName(string name)
        {
            bool result = false;
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Check_UniqueSectorName";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", name.ToUpper());
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            result = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                    result = false;
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }

    }
}
