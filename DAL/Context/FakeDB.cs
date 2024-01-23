using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class FakeDB
    {
        public static List<User> Users { get; set; } = new List<User>()
        {
            new User(0, "Spirou", "spirou@mail.be", "test1234="),
            new User(1, "Fantasio", "fantasio@mail.be", "test1234="),
            new User(2, "Lambique", "lambique@mail.be", "test1234="),
            new User(3, "Gaston Lagaffe", "gaston@mail.be", "test1234="),
            new User(4, "Seccotine", "seccotine@mail.be", "test1234="),
            new User(5, "Mademoiselle Jeanne", "mademoiselle.jeanne@mail.be", "test1234="),
            new User(6, "Spip", "spip@mail.be", "test1234="),
            new User(7, "Zorglub", "zorglub@mail.be", "test1234="),
            new User(8, "Papyrus", "papyrus@mail.be", "test1234="),
            new User(9, "Asterix", "asterix@mail.be", "test1234="),
            new User(10, "Schtrouph Farceur", "sch_farceur@mail.be", "test1234=")
        };
    }
}
