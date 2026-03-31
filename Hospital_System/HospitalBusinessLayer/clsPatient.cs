using HospitalDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBusinessLayer
{
    public class clsPatient
    {
        enum enMode { AddNew, Update};
        enMode Mode;
        public int ID { get; set; }
        public string Name { get; set; }

        public bool Gender { get; set; }
        public DateTime BirthDate { get; set; }

        public bool isSmoke { get; set; }
        public bool isFat { get; set; }


        public clsPatient() 
        {
            this.ID = -1;
            this.Name = "";
            this.Gender = false;
            this.isSmoke = false;
            this.isFat = false;
            this.BirthDate = DateTime.Now;

            Mode = enMode.AddNew;
        }

        public clsPatient(int ID, string Name, bool Gender, DateTime BirthDate, bool isSmoke, bool isFat)
        {
            this.ID = ID;
            this.Name = Name;
            this.Gender = Gender;
            this.isSmoke = isSmoke;
            this.isFat = isFat;
            this.BirthDate = DateTime.Now;
            Mode = enMode.Update;
        }

        public static DataTable GetAllPatient()
        {
            return clsDataPatient.GetAllPatient();
        }

        public bool _AddNewPatient()
        {
            this.ID = clsDataPatient.AddNewPatient(this.Name, this.Gender, this.BirthDate, this.isSmoke, this.isFat);
            return this.ID != -1;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPatient())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;             
            }
            return false;
        }
    }
}
