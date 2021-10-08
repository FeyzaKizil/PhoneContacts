using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BLL
    {

        DatabaseLogicLayer.DLL dll;
        public BLL()
        {
            dll = new DatabaseLogicLayer.DLL();
        }

        public int LoginCheck(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                return dll.LoginCheck(new Entities.myUser()
                {
                    Username = username,
                    Password = password
                });
            }
            else
            {
                return -1;  //missing parameter
            }
        }

        public int AddContact(string name, string lastname, string phoneNumber1, string phoneNumber2, string phoneNumber3, 
            string emailAddress, string webAddress, string address, string info)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(lastname) && !string.IsNullOrEmpty(phoneNumber1))
            {
                return dll.AddContact(new Entities.Contacts()
                {
                    ID = Guid.NewGuid(),
                    Name = name,
                    Lastname = lastname,
                    PhoneNumber1 = phoneNumber1,
                    PhoneNumber2 = phoneNumber2,
                    PhoneNumber3 = phoneNumber3,
                    EmailAddress = emailAddress,
                    WebAddress = webAddress,
                    Address = address,
                    Info = info
                });
            }
            else
            {
                return -1;
            }
        }

        public int EditContact(Guid Id, string name, string lastname, string phoneNumber1, string phoneNumber2, string phoneNumber3,
            string emailAddress, string webAddress, string address, string info)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(lastname) && !string.IsNullOrEmpty(phoneNumber1))
            {
                return dll.EditContact(new Entities.Contacts() 
                {
                    ID = Id,
                    Name = name,
                    Lastname = lastname,
                    PhoneNumber1 = phoneNumber1,
                    PhoneNumber2 = phoneNumber2,
                    PhoneNumber3 = phoneNumber3,
                    EmailAddress = emailAddress,
                    WebAddress = webAddress,
                    Address = address,
                    Info = info
                });
            }
            else
            {
                return -1;
            }
        }

        public int DeleteContact(Guid Id)
        {
            if (Id != Guid.Empty)
            {
                return dll.DeleteContact(Id);
            }
            else
            {
                return -1;
            }
        }

        public List<Contacts> ShowContacts()
        {
            List<Contacts> ContactsList = new List<Contacts>();
            try
            {
                SqlDataReader ContactsReader = dll.ShowContacts();
                while (ContactsReader.Read())
                {
                    ContactsList.Add(new Contacts()
                    {
                        ID = ContactsReader.IsDBNull(0) ? Guid.Empty : ContactsReader.GetGuid(0),
                        Name = ContactsReader.IsDBNull(1) ? string.Empty : ContactsReader.GetString(1),
                        Lastname = ContactsReader.IsDBNull(2) ? string.Empty : ContactsReader.GetString(2),
                        PhoneNumber1 = ContactsReader.IsDBNull(3) ? string.Empty : ContactsReader.GetString(3),
                        PhoneNumber2 = ContactsReader.IsDBNull(4) ? string.Empty : ContactsReader.GetString(4),
                        PhoneNumber3 = ContactsReader.IsDBNull(5) ? string.Empty : ContactsReader.GetString(5),
                        EmailAddress = ContactsReader.IsDBNull(6) ? string.Empty : ContactsReader.GetString(6),
                        WebAddress = ContactsReader.IsDBNull(7) ? string.Empty : ContactsReader.GetString(7),
                        Address = ContactsReader.IsDBNull(8) ? string.Empty : ContactsReader.GetString(8),
                        Info = ContactsReader.IsDBNull(9) ? string.Empty : ContactsReader.GetString(9),
                    });           
                }
                ContactsReader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dll.ConnectionSet();
            }
            return ContactsList;
        }

        public Contacts ShowContactID(Guid Id)
        {
            Contacts C = new Contacts();
            try
            {
                SqlDataReader CReader = dll.ShowContactID(Id);
                while (CReader.Read())
                {
                    C = (new Entities.Contacts()
                    {
                        ID = CReader.IsDBNull(0) ? Guid.Empty : CReader.GetGuid(0),
                        Name = CReader.IsDBNull(1) ? string.Empty : CReader.GetString(1),
                        Lastname = CReader.IsDBNull(2) ? string.Empty : CReader.GetString(2),
                        PhoneNumber1 = CReader.IsDBNull(3) ? string.Empty : CReader.GetString(3),
                        PhoneNumber2 = CReader.IsDBNull(4) ? string.Empty : CReader.GetString(4),
                        PhoneNumber3 = CReader.IsDBNull(5) ? string.Empty : CReader.GetString(5),
                        EmailAddress = CReader.IsDBNull(6) ? string.Empty : CReader.GetString(6),
                        WebAddress = CReader.IsDBNull(7) ? string.Empty : CReader.GetString(7),
                        Address = CReader.IsDBNull(8) ? string.Empty : CReader.GetString(8),
                        Info = CReader.IsDBNull(9) ? string.Empty : CReader.GetString(9),
                    });                    
                }
                CReader.Close();               
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dll.ConnectionSet();
            }
            return C;
        }

    }
}
