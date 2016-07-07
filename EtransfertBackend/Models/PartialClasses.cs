using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtransfertBackend.Models
{
    public partial class Transactions
    {
        public eTransferttestEntities model;
        public string Benef
        {
            get
            {
                string ret = string.Empty;
               
               ret +=Convert.ToString((Montant * (Pourcentage + 3)) / 100);
               
                return ret;
            }
        }

        //public string Email
        //{
        //    get
        //    {
        //        string ret = string.Empty;

        //        var rep=model.AspNetUsers.Where(c=>c.Id==)
        //        ret += Convert.ToString(CompteUnite);
        //        //if (!String.IsNullOrEmpty(Prenoms))
        //        //    ret += " " + Prenoms;
        //        if (!String.IsNullOrEmpty(Email))
        //            ret += " (" + Email + ")";
        //        return ret;
        //    }
        //}

    }

    //public partial class Inscription
    //{

    //    public string FullName
    //    {
    //        get
    //        {
    //            string ret = string.Empty;
    //            if (AspNetUsers != null)
    //                ret += AspNetUsers.FullName;
    //            return ret;
    //        }
    //    }

    //}

    //public partial class Enfants
    //{

    //    public string FullName
    //    {
    //        get
    //        {
    //            string ret = string.Empty;
    //            if (!String.IsNullOrEmpty(Nom))
    //                ret += Nom;
    //            if (!String.IsNullOrEmpty(Prenoms))
    //                ret += " " + Prenoms;
    //            return ret;
    //        }
    //    }

    //}

    //public partial class Utilisateurs
    //{

    //    public string FullName
    //    {
    //        get
    //        {
    //            string ret = string.Empty;
    //            if (!String.IsNullOrEmpty(Nom))
    //                ret += Nom;
    //            if (!String.IsNullOrEmpty(Prenoms))
    //                ret += " " + Prenoms;
    //            return ret;
    //        }
    //    }

    //}

}
