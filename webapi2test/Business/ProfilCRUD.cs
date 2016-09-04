
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapi2test.Models;

namespace webapi2test.Business
{
    public class ProfilCRUD : IProfilCRUD<Profile>
    {
        private List<Profile> _list;
        private static ProfilCRUD profil;
        private ProfilCRUD()
        {
            _list = new List<Profile>();

            _list.Add(new Profile() { Id = 1, Name = "Lokman", Email = "Lbozan@outlook.com" });
            _list.Add(new Profile() { Id = 2, Name = "Baris", Email = "Baris@hotmail.com" });
            _list.Add(new Profile() { Id = 3, Name = "Hüseyin", Email = "huseyin@msn.com" });
        }
        public static ProfilCRUD Instans
        {
            get
            {
                if (profil == null)
                {
                    profil = new ProfilCRUD();
                }
                return profil;
            }
        }

        public List<Profile> List()
        {
            return _list.ToList();
        }

        public Profile Details(Profile data)
        {
            return _list.FirstOrDefault(x => x.Id == data.Id);
        }

        public bool Delete(Profile data)
        {
            try
            {
                var del = _list.FirstOrDefault(x => x.Id == data.Id);
                _list.Remove(del);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Add(Profile data)
        {
            if (data!=null)
            {
                data.Id = _list.Max(x => x.Id) + 1;
                _list.Add(data);
                return true;
            }
            return false;
        }

        public bool Update(Profile data)
        {
            try
            {
                if (data == null) return false;

                var detay = Details(data);
                detay.Name = data.Name;
                detay.Email = data.Email;

                return true;
            }
            catch 
            {
                return false;
            }
        }
    }

}