using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LabDTO.Models;
using RestEase;

namespace Lab.DTO.Api
{
    interface IPeopleClient
    {
        [Post("people")]
        Task AddPersonAsync([Body] Person person);

        [Get("people/{id}")]
        Task GetPersonAsync();
    }
}
