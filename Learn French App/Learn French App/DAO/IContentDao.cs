using Learn_French_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn_French_App.DAO
{
    internal interface IContentDao
    {
        //contains methods required in DAO
        public Content GetVocab();
    }
}
