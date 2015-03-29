using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbcBookIt.Repository
{
    partial interface IBookRequestR {
        string GetMaxRequestForYear(int Year);
    }
    public partial class BookRequestR
    {

        public const int THIS_SHOULD_BE_ELSEWHERE = 10000;

        public string GetMaxRequestForYear(int Year)
        {
            // FRAGILE: ASSUME: we don't create later requests for previous days or years
            DateTime nextYear = new DateTime(Year+1,1,1);
            string max = (
                from r in _Db.BookRequestDb
                where r.RequestDate < nextYear
                orderby r.RequestNumber descending
                select r.RequestNumber
            ).FirstOrDefault();
            if (string.IsNullOrEmpty(max))
            {
                max = (Year * THIS_SHOULD_BE_ELSEWHERE).ToString();
            }
            return max;
        }
    }
}
