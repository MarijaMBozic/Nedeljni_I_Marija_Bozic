using Nedeljni_I_Marija_Bozic.Helpers;
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
        public List<Sector> GettAllSectors()
        {
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
                            sectorList.Add(r);
                        }
                        return sectorList;
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

        public bool CheckUsernameClinicUser(string userName)
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
    }
}
