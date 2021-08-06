using DapperApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApi.Repository
{
    public interface IPersonRepo
    {
      
        IEnumerable<PersonInfo> GetPersonDetails();

         PersonInfo GetPerson(int Personid);

        PersonInfo InsertPersonDetails(PersonInfo person);

        PersonInfo UpdatePersonDetails(int Persionid,PersonInfo person);


        string DeletePerson(int Personid);

    }
}
