using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLogicLayer
{
    public class DLL
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        int ReturnValue;

        public DLL()
        {
            con = new SqlConnection("data source=MYLOVE\\SQLEXPRESS01; initial catalog=PhoneContacts; user Id=sa; password=1234;");
            //Sql Connection Address
        }

        public void ConnectionSet()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            else
            {
                con.Close();
            }
        }

        public int LoginCheck(myUser U)
        {
            try
            {
                cmd = new SqlCommand("select count(*) from myUser where Username = @Username and Password = @Password", con);
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = U.Username;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = U.Password;
                ConnectionSet();
                ReturnValue = (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ConnectionSet();
            }
            return ReturnValue;
        }

        public int AddContact(Contacts C)
        {
            try
            {
                cmd = new SqlCommand("insert into Contacts (ID, Name, Lastname, PhoneNumber1, PhoneNumber2, PhoneNumber3, EmailAddress, WebAddress, Address, Info) " +
                    "values (@ID, @Name, @Lastname, @PhoneNumber1, @PhoneNumber2, @PhoneNumber3, @EmailAddress, @WebAddress, @Address, @Info)", con);
                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = C.ID;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = C.Name;
                cmd.Parameters.Add("@Lastname", SqlDbType.NVarChar).Value = C.Lastname;
                cmd.Parameters.Add("@PhoneNumber1", SqlDbType.NVarChar).Value = C.PhoneNumber1;
                cmd.Parameters.Add("@PhoneNumber2", SqlDbType.NVarChar).Value = C.PhoneNumber2;
                cmd.Parameters.Add("@Phonenumber3", SqlDbType.NVarChar).Value = C.PhoneNumber3;
                cmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = C.EmailAddress;
                cmd.Parameters.Add("@WebAddress", SqlDbType.NVarChar).Value = C.WebAddress;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = C.Address;
                cmd.Parameters.Add("@Info", SqlDbType.NVarChar).Value = C.Info;
                ConnectionSet();
                ReturnValue = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ConnectionSet();
            }
            return ReturnValue;
        }

        public int EditContact(Contacts C)
        {
            try
            {
                cmd = new SqlCommand(@"update Contacts
Set 
Name =  @Name,
Lastname =  @Lastname,
PhoneNumber1 = @PhoneNumber1,
PhoneNumber2 = @PhoneNumber2,
PhoneNumber3 = @PhoneNumber3,
EmailAddress = @EmailAddress,
WebAddress = @WebAddress,
Address = @Address,
Info = @Info
where
ID =  @ID", con);
                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = C.ID;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = C.Name;
                cmd.Parameters.Add("@Lastname", SqlDbType.NVarChar).Value = C.Lastname;
                cmd.Parameters.Add("@PhoneNumber1", SqlDbType.NVarChar).Value = C.PhoneNumber1;
                cmd.Parameters.Add("@PhoneNumber2", SqlDbType.NVarChar).Value = C.PhoneNumber2;
                cmd.Parameters.Add("@Phonenumber3", SqlDbType.NVarChar).Value = C.PhoneNumber3;
                cmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = C.EmailAddress;
                cmd.Parameters.Add("@WebAddress", SqlDbType.NVarChar).Value = C.WebAddress;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = C.Address;
                cmd.Parameters.Add("@Info", SqlDbType.NVarChar).Value = C.Info;
                ConnectionSet();
                ReturnValue = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ConnectionSet();
            }
            return ReturnValue;
        }

        public int DeleteContact(Guid ID)
        {            
            try
            {
                cmd = new SqlCommand(@"delete Contacts where ID = @ID", con);
                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
                ConnectionSet();
                ReturnValue = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ConnectionSet();
            }
            return ReturnValue;
        }

        public SqlDataReader ShowContacts()
        {
            cmd = new SqlCommand("select * from Contacts", con);
            ConnectionSet();
            return cmd.ExecuteReader();
        }
        public SqlDataReader ShowContactID(Guid ID)
        {
            cmd = new SqlCommand("select * from Contacts where ID = @ID", con);
            cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
            ConnectionSet();
            return cmd.ExecuteReader();
        }

    }
}
